using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class GameController : MonoBehaviour
{
    public GameObject characterPrefabs;
    public GameObject manas;
    private int[] charas = {1,2,3,5,5};
    private GameObject characterIcon;
    private GameObject manaIcon;
    private GameObject[] manaIcons;

    private Mana[] manascripts;

    public ParameterLoad parameterLoader;
    private Character[] charaParameters;

    public Text hpMax;
    public Text hpNow;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine (LoadAsync());
    }
    // Update is called once per frame
    void Update(){
    }
    //非同期でロードする
    private IEnumerator LoadAsync(){
        //非同期ロード開始
        ResourceRequest resourceRequest_chara = Resources.LoadAsync<GameObject> ("Prefabs/Chara");
        ResourceRequest resourceRequest_mana = Resources.LoadAsync<GameObject> ("Prefabs/Mana");
        ResourceRequest resourceRequest_param_chara = Resources.LoadAsync<TextAsset> ("Parameter/characters");

        //ロードが終わるまで待機(resourceRequest.progressで進捗率を確認出来る)
        while(!resourceRequest_chara.isDone||!resourceRequest_mana.isDone||!resourceRequest_param_chara.isDone) {
            Debug.Log("ロード待ち");
            yield return 0;
        }
        Debug.Log("ロード完了！");
        //ロード完了、resourceRequest.assetからロードしたアセットを取得
        characterIcon = resourceRequest_chara.asset as GameObject;
        manaIcon = resourceRequest_mana.asset as GameObject;
        TextAsset csv = resourceRequest_param_chara.asset as TextAsset;
        var strReader = new StringReader(csv.text);
        var csvReader = new CsvHelper.CsvReader(strReader, System.Globalization.CultureInfo.CreateSpecificCulture("ja-JP"));
        csvReader.Configuration.RegisterClassMap<CharacterMapper>();
        charaParameters = csvReader.GetRecords<Character>().ToArray();
        yield return new WaitForSeconds (0.5f);
        Debug.Log("セットアップ開始！");
        SetUp();
    }
    ///セットアップ
    void SetUp(){
        for(int i=0;i<5;i++){
            GameParameter.is_set[i] = false;
        }
        CharacterCreate(charas);
        ManaCreateInit();
    }
    ///キャラアイコンの生成とHp
    void CharacterCreate(int[] num){
        int hpSum = 0;
        for(int i=0;i<5;i++){
            var obj = Create(characterIcon);
            obj.transform.parent = characterPrefabs.transform;
            var rect = obj.GetComponent<RectTransform> ();
            rect.sizeDelta = new Vector2((int)GameParameter.iconHW,(int)GameParameter.iconHW);
            rect.localPosition = new Vector3((int)GameParameter.iconHW * (i - 2),0,0);
            var character = obj.GetComponent<Character> ();
            character.SetUp(charaParameters[num[i]-1]);
            hpSum += charaParameters[num[i]-1].Hp;
        }
        hpMax.text = hpSum.ToString();
        hpNow.text = hpSum.ToString();
    }
    ///マナの生成（初期）
    void ManaCreateInit(){
        manaIcons = new GameObject[10];
        manascripts = new Mana[10];
        for(int j=0;j<2;j++){
            for(int i=0;i<5;i++){
                var obj = Create(manaIcon);
                obj.transform.parent = manas.transform;
                var rect = obj.GetComponent<RectTransform> ();
                var image = obj.GetComponent<Image> ();
                var mana = obj.GetComponent<Mana> ();
                int att = Random.Range(1, 6 + 1);
                image.color = mana.ColorImage(att);
                rect.sizeDelta = new Vector2((int)GameParameter.manaHW,(int)GameParameter.manaHW);
                rect.localPosition = new Vector3((int)GameParameter.manaHW * (i - 2),(int)GameParameter.manaHW * j,0);
                manaIcons[j * 5 + i] = obj;
                manascripts[j * 5 + i] = mana;
            }
        }
    }
    ///マナの生成
    public void ManaCreate(){
        for(int j=0;j<2;j++){
            for(int i=0;i<5;i++){
                if(manascripts[j * 5 + i].isSet){
                    manaIcons[j * 5 + i].SetActive(false);
                    manaIcons[j * 5 + i].transform.localPosition = new Vector3((int)GameParameter.manaHW * (i - 2),(int)GameParameter.manaHW * j,0);
                    int att = Random.Range(1, 6 + 1);
                    manascripts[j * 5 + i].ColorImage(att);
                    manaIcons[j * 5 + i].SetActive(true);
                }
            }
        }
    }
    ///オブジェクト生成
    GameObject Create(GameObject prefab){
        GameObject obj = Instantiate(prefab, new Vector3(0,0,0), new Quaternion(0, 0, 0, 1));
        return obj;
    }
    GameObject LoadObject(string name){
        return (GameObject)Resources.Load("Prefabs/" + name);
    }
}
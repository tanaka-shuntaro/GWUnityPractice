using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mana : MonoBehaviour
{
    public int myHighNum{get;set;}
    public int myWidthNum{get;set;}
    public Vector3 myPosition{get;set;}
    public int myElement{get;set;}
    public Image image;

    public bool isSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color ColorImage(int num){
        myElement = num;
        Color oriColor;
        switch(num){
            case 1:
                oriColor = GameParameter.chara_fire;
                break;
            case 2:
                oriColor = GameParameter.chara_water;
                break;
            case 3:
                oriColor = GameParameter.chara_leaf;
                break;
            case 4:
                oriColor = GameParameter.chara_right;
                break;
            case 5:
                oriColor = GameParameter.chara_dark;
                break;
            case 6:
                oriColor = GameParameter.heel;
                break;
            case 7:
                oriColor = GameParameter.all_mana;
                break;
            default:
                oriColor = new Color(255, 255, 255);
                break;
        }
        image.color = oriColor;
        return oriColor;
    }
}

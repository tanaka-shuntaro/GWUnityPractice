using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TapDrag : MonoBehaviour, IDragHandler, IEndDragHandler,IPointerClickHandler
{
    public RectTransform m_rectTransform = null;
    public Mana mana;
    private Vector2 start_position;
    private bool isSet = false;
    private int setNum = 99;
    private bool isDrag = false;

    void Start(){
        start_position = this.transform.localPosition;
    }
    
    private void Reset()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }
    
    public void OnDrag( PointerEventData e )
    {
        m_rectTransform.position += new Vector3( e.delta.x, e.delta.y, 0f );
        isDrag = true;
    }
    public void OnEndDrag(PointerEventData pointerEventData)
    {
        m_rectTransform = GetComponent<RectTransform>();
        int empty_num = 99;
        for(int i=0;i<5;i++){
            if(!GameParameter.is_set[i]){
                empty_num = i;
                break;
            }
        }
        if(this.transform.localPosition.y < -100 && empty_num != 99){
            if(mana.isSet){
                this.transform.localPosition = new Vector3((int)GameParameter.iconHW * (setNum - 2),-250,0);
            }else{
                this.transform.localPosition = new Vector3((int)GameParameter.iconHW * (empty_num - 2),-250,0);
                GameParameter.is_set[empty_num] = true;
                GameParameter.set_nums[empty_num] = mana.myElement;
                setNum = empty_num;
                mana.isSet = true;
            }
        }else{
            this.transform.localPosition = start_position;
            if(mana.isSet){
                GameParameter.is_set[setNum] = false;
                GameParameter.set_nums[empty_num] = 0;
                setNum = 99;
                mana.isSet = false;
            }
        }
        isDrag = false;
        //gameObject.GetComponent<Image>().color = Vector4.one;
        //Destroy(draggingObject);
    }
    public void OnPointerClick(PointerEventData pointerData){
        if(!isDrag){
            m_rectTransform = GetComponent<RectTransform>();
            int empty_num = 99;
            for(int i=0;i<5;i++){
                if(!GameParameter.is_set[i]){
                    empty_num = i;
                    break;
                }
            }
            if(mana.isSet){
                this.transform.localPosition = start_position;
                GameParameter.is_set[setNum] = false;
                GameParameter.set_nums[empty_num] = 0;
                setNum = 99;
                mana.isSet = false;
            }else{
                this.transform.localPosition = new Vector3((int)GameParameter.iconHW * (empty_num - 2),-250,0);
                GameParameter.is_set[empty_num] = true;
                GameParameter.set_nums[empty_num] = mana.myElement;
                setNum = empty_num;
                mana.isSet = true;
            }
        }
	}
}

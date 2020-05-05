using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameter : MonoBehaviour
{
    public static float iconHW = 160f;
    public static float manaHW = 160f;
    public static Color chara_fire = Color.red;
    public static Color chara_water = Color.blue;
    public static Color chara_leaf = Color.green;
    public static Color chara_right = Color.yellow;
    public static Color chara_dark = Color.magenta;
    public static Color heel = Color.white;
    public static Color all_mana = Color.grey;

    public static bool[] is_set = {false,false,false,false,false};
    public static int[] set_nums = {0,0,0,0,0};
    public GameObject attButton;
    // 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

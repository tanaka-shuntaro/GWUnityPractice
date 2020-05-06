using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int No { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Att { get; set; }
    public int Hp { get; set; }
    public int Atk { get; set; }
    public int Rec { get; set; }
    public int Skill { get; set; }
    public int SkillCost { get; set; }
    public int refR { get; set; }
    public int refW { get; set; }
    public int refL { get; set; }
    public int refS { get; set; }
    public int refD { get; set; }

    public Mana manaIcon;
    public Text mananum;
    public Image image;

    public void SetUp(Character character){
        this.No = character.No;
        this.Name = character.Name;
        this.Type = character.Type;
        this.Att = character.Att;
        image.color = manaIcon.ColorImage(ToAttribute(Att));
        this.Hp = character.Hp;
        this.Atk = character.Atk;
        this.Rec = character.Rec;
        this.Skill = character.Skill;
        this.SkillCost = character.SkillCost;
        mananum.text = SkillCost.ToString();
        this.refR = character.refR;
        this.refW = character.refW;
        this.refL = character.refL;
        this.refS = character.refS;
        this.refD = character.refD;
    }
    int ToAttribute(string att){
        switch(att){
            case "Fire":
                return 1;
                break;
            case "Water":
                return 2;
                break;
            case "Leaf":
                return 3;
                break;
            case "Shine":
                return 4;
                break;
            case "Dark":
                return 5;
                break;
            default:
                return 0;
                break;
        }
    }
}

public class CharacterMapper : CsvHelper.Configuration.ClassMap<Character>
{
    public CharacterMapper()
    {
        Map(x => x.No).Index(0);
        Map(x => x.Name).Index(1);
        Map(x => x.Type).Index(2);
        Map(x => x.Att).Index(3);
        Map(x => x.Hp).Index(4);
        Map(x => x.Atk).Index(5);
        Map(x => x.Rec).Index(6);
        Map(x => x.Skill).Index(7);
        Map(x => x.SkillCost).Index(8);
        Map(x => x.refR).Index(9);
        Map(x => x.refW).Index(10);
        Map(x => x.refL).Index(11);
        Map(x => x.refS).Index(12);
        Map(x => x.refD).Index(13);
    }
}
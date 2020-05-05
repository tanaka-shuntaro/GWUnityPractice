using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ParameterLoad : MonoBehaviour
{
    
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

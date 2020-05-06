using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
/*--------------------------------
https://www.nuget.org/packages/CsvHelper/15.0.5 から最新のnupkgをダウンロード
拡張子の.nupkgを.zipに変更し解凍（macのみ）
dillのCsvHelper.dllをAssets配下におく
---------------------------------*/
public class CsvLoader : MonoBehaviour
{
    public static (T[],IEnumerable<T>) Reader<T,M>(TextAsset csv) where M : CsvHelper.Configuration.ClassMap<T>
    {
        var strReader = new StringReader(csv.text);
        var csvReader = new CsvHelper.CsvReader(strReader, System.Globalization.CultureInfo.CreateSpecificCulture("ja-JP"));
        csvReader.Configuration.RegisterClassMap<M>();
        var csvList = csvReader.GetRecords<T>();
        var csvArray = csvList.ToArray();
        return (csvArray,csvList);
    }
}

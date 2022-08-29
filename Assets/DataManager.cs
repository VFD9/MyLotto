using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class DataManager : MonoBehaviour
{
    private string URL = "https://docs.google.com/spreadsheets/d/1zqz-tHkamd4bBExwBqCOuBdRu0k2DwlQOBYE_YB-C9s/export?format=tsv&range=N5:T";

    static string LINE_SPLIT = @"\r\n|\n\r|\n|\r\t";

    private Test t = new Test();
    
    private IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);

        yield return www.SendWebRequest();

        string Data = www.downloadHandler.text;

        string[] lines = Regex.Split(Data, LINE_SPLIT);

        t.Initialize(lines);
    }
}

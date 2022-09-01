using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class MyUi
{
    public Text[] str = new Text[7];
}

public class Test : MonoBehaviour
{
    public List<MyUi> Numbers = new List<MyUi>();

    public void Initialize(string[] _lines)
    {
        (new GameObject("NumberList")).transform.parent = GameObject.Find("Canvas").transform;

        for (int i = 0; i < _lines.Length; ++i)
        {
            string[] lines = Regex.Split(_lines[i], @"' '|\t");

            GameObject Obj = new GameObject((i + 1).ToString());
            Obj.transform.parent = GameObject.Find("NumberList").transform;

            for(int j = 0; j < 7; ++j)
			{
                GameObject go = new GameObject();
                go.name = "Lotto Number " + (j + 1);
                go.transform.parent = GameObject.Find((i + 1).ToString()).transform;

                go.AddComponent<Text>();
                Text t = go.GetComponent<Text>();
                t.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                t.fontSize = 500;
                t.rectTransform.sizeDelta = new Vector2(300.0f, 570.0f);
                t.text = lines[j].ToString();
			}
        }
    }

    void Start()
    {
        //tString.text = "10";
        //tString.rectTransform.anchoredPosition = new Vector3(0, 0);
    }
    
    void Update()
    {
        
    }
}

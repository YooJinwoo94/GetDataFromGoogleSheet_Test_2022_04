using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class GetGoogleSpreadSheets : MonoBehaviour
{
    const string url ="https://docs.google.com/spreadsheets/d/1b9nHzGV-Ucu6RXc6lF-n-eA1SoxttAgpe8oypmTiNI4/export?format=tsv&range=A2:D4";

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();   // 통신을 함

        string data = www.downloadHandler.text; // 데이터 받아옴
        print("받기 끝");
        setText(www.downloadHandler.text);
    }


    void setText(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');

            for (int j = 0; j< columSize; j ++)
            {
                Debug.Log(column[j]);
            }
        }
    }
}

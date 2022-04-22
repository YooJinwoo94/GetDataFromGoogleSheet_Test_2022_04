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
        //가로 기준으로 나눈다.
        string[] row = tsv.Split('\n');
        //  열 = 세로의 양
        int rowSize = row.Length;
        // 오 = 가로의 양
        int columSize = row[0].Split('\t').Length;

        // 열의 길이로 가로로 나눈다.
        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');

            // 오의 길이로 세로로 나눈다.
            for (int j = 0; j< columSize; j ++)
            {
                Debug.Log(column[j]);
            }
        }
    }
}

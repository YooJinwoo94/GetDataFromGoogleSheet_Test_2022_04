using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class GetGoogleSpreadSheets : MonoBehaviour
{
    [SerializeField]
    TextUIDataBase textUIDataBase;

    const string url ="https://docs.google.com/spreadsheets/d/1b9nHzGV-Ucu6RXc6lF-n-eA1SoxttAgpe8oypmTiNI4/export?format=tsv&range=A2:D4";

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();   // 통신을 함

        string data = www.downloadHandler.text; // 데이터 받아옴
        print("받기 끝");
        //  setText(www.downloadHandler.text);
        checkNameAndChange(data);
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
        //ㅁㅁㅁㅁㅁ
        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');

            // 오의 길이로 세로로 나눈다.
            //ㅁ
            //ㅁ
            //ㅁ
            //ㅁ
            //ㅁ
            for (int j = 0; j< columSize; j ++)
            {
                Debug.Log(column[j]);
            }
        }
    }



    void checkNameAndChange(string tsv)
    {
        //가로 기준으로 나눈다.
        string[] row = tsv.Split('\n');
        //  열 = 세로의 양
        int rowSize = row.Length;
        // 오 = 가로의 양
        int columSize = row[0].Split('\t').Length;

        // 열의 길이로 가로로 나눈다.
        //ㅁㅁㅁㅁㅁ
        string[] column = new string [columSize-1];
        for (int i = 0; i < rowSize; i++)
        {
            column = row[i].Split('\t');

            Debug.Log(column[0]);

            for (int j = 0; j < textUIDataBase.names.Length; j++)
            {
                if (column[0] == textUIDataBase.names[j].text)
                {
                    textUIDataBase.qty[j].text = column[1];
                    textUIDataBase.price[j].text = column[2];
                    textUIDataBase.priceUSD[j].text = column[3];
                }
            }
        } 
    }
}

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
        yield return www.SendWebRequest();   // 搭重聖 敗

        string data = www.downloadHandler.text; // 汽戚斗 閤焼身
        print("閤奄 魁");
        //  setText(www.downloadHandler.text);
        checkNameAndChange(data);
    }


    void setText(string tsv)
    {
        //亜稽 奄層生稽 蟹勧陥.
        string[] row = tsv.Split('\n');
        //  伸 = 室稽税 丞
        int rowSize = row.Length;
        // 神 = 亜稽税 丞
        int columSize = row[0].Split('\t').Length;

        // 伸税 掩戚稽 亜稽稽 蟹勧陥.
        //けけけけけ
        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');

            // 神税 掩戚稽 室稽稽 蟹勧陥.
            //け
            //け
            //け
            //け
            //け
            for (int j = 0; j< columSize; j ++)
            {
                Debug.Log(column[j]);
            }
        }
    }



    void checkNameAndChange(string tsv)
    {
        //亜稽 奄層生稽 蟹勧陥.
        string[] row = tsv.Split('\n');
        //  伸 = 室稽税 丞
        int rowSize = row.Length;
        // 神 = 亜稽税 丞
        int columSize = row[0].Split('\t').Length;

        // 伸税 掩戚稽 亜稽稽 蟹勧陥.
        //けけけけけ
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

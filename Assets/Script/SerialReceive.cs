using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialReceive : MonoBehaviour
{
    //https://qiita.com/yjiro0403/items/54e9518b5624c0030531
    //上記URLのSerialHandler.cのクラス
    public SerialHandler serialHandler;
    public int[] stock = new int[5]; //ひずみアンプで取得した直近5個分の値をストックして差を比較する
    public bool input_check = false;
    int i = 0;

    void Start()
    {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void Update()
    {
        for (int j = 0; j < 5; j++)
        {
            //Debug.Log(stock[j]);
            
        }

        if (stock[0] != 0 && stock[1] != 0 && stock[2] != 0 && stock[3] != 0 && stock[4] != 0)
            if (stock[4] - stock[3] > 300)
            {
                //Debug.Log("ひずみ曲がり:" + (stock[4] - stock[0]));
                input_check = true;

                Debug.Log(input_check);

            }
            else if(stock[4] - stock[3] < -300)
            {
                input_check = false;
                Debug.Log(input_check);
            }
    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
        if (i > 4)
            i = 0;

        try
        {
            //Debug.Log(data[0]);//Unityのコンソールに受信データを表示
            stock[i] = int.Parse(data[0]);
            i++;
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);//エラーを表示
        }
    }
}
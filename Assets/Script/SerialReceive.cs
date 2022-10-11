using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialReceive : MonoBehaviour
{
    //https://qiita.com/yjiro0403/items/54e9518b5624c0030531
    //��LURL��SerialHandler.c�̃N���X
    public SerialHandler serialHandler;
    public int[] stock = new int[5]; //�Ђ��݃A���v�Ŏ擾��������5���̒l���X�g�b�N���č����r����
    public bool input_check = false;
    int i = 0;

    void Start()
    {
        //�M������M�����Ƃ��ɁA���̃��b�Z�[�W�̏������s��
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
                //Debug.Log("�Ђ��݋Ȃ���:" + (stock[4] - stock[0]));
                input_check = true;

                Debug.Log(input_check);

            }
            else if(stock[4] - stock[3] < -300)
            {
                input_check = false;
                Debug.Log(input_check);
            }
    }

    //��M�����M��(message)�ɑ΂��鏈��
    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
        if (i > 4)
            i = 0;

        try
        {
            //Debug.Log(data[0]);//Unity�̃R���\�[���Ɏ�M�f�[�^��\��
            stock[i] = int.Parse(data[0]);
            i++;
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);//�G���[��\��
        }
    }
}
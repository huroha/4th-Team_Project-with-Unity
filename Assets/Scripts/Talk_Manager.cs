using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_Manager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        // ��ȭ data
        // NPC : 1000 ����
        // �繰 : 100 ����

        talkData.Add(1000, new string[] { "1��° ���:1", "2��° ���:2" });
        talkData.Add(2000, new string[] { "1��° ���:0", "2��° ���:1" });

        talkData.Add(100, new string[] { "carpet" });
        talkData.Add(200, new string[] { "key1" });
        talkData.Add(300, new string[] { "key2" });
        talkData.Add(400, new string[] { "num3" });
        talkData.Add(500, new string[] { "num4" });
        talkData.Add(600, new string[] { "���� ������." });

        talkData.Add(0+3000, new string[] { "���� �ʹ� ��ο��.....:1", "���� �Ӹ��� �� ������..?:0" });
        // quest data


        talkData.Add(10 + 1000, new string[] { "quest ��ȭ 1:0", "quest ��ȭ 2:1" });

        talkData.Add(11 + 2000, new string[] { "quest��ȭ Ȯ��1:0", "quest��ȭ Ȯ��2:1" });
        talkData.Add(30 + 2000, new string[] { "����������1:0", "����������2:1" });
        talkData.Add(100 + 2000, new string[] { "�ٽ� �õ�quest��ȭ Ȯ��1:0", "�ٽ� �õ�quest��ȭ Ȯ��2:1" });
        // �ʻ�ȭ data
        portraitData.Add(1000 + 0,portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);

        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);

        
        portraitData.Add(3000 + 1, portraitArr[1]);         // ȥ�㸻 �κ� test
        portraitData.Add(3000 + 0, portraitArr[0]);

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id- id%10))
            {
                // ����Ʈ �� ó�� ��縶�� ���� ��,
                // �⺻ ��� ������ ��
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //�ش� ����Ʈ ���� ���� ��簡 ���� ��,
                // ����Ʈ �� ó�� ��縦 ������ ��.
                if (talkIndex == talkData[id - id % 10].Length)
                    return null;
                else
                    return talkData[id - id % 10][talkIndex];
            }
        }
        if (talkIndex == talkData[id].Length){
            return null;
        }


        else
            return talkData[id][talkIndex];
    }
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}

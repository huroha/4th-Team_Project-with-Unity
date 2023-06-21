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
        // 대화 data
        // NPC : 1000 번대
        // 사물 : 100 번대

        talkData.Add(1000, new string[] { "1번째 대사:1", "2번째 대사:2" });
        talkData.Add(2000, new string[] { "1번째 대사:0", "2번째 대사:1" });

        talkData.Add(100, new string[] { "carpet" });
        talkData.Add(200, new string[] { "key1" });
        talkData.Add(300, new string[] { "key2" });
        talkData.Add(400, new string[] { "num3" });
        talkData.Add(500, new string[] { "num4" });
        talkData.Add(600, new string[] { "불이 켜졌다." });

        talkData.Add(0+3000, new string[] { "여긴 너무 어두운걸.....:1", "불을 켤만한 게 있을까..?:0" });
        // quest data


        talkData.Add(10 + 1000, new string[] { "quest 대화 1:0", "quest 대화 2:1" });

        talkData.Add(11 + 2000, new string[] { "quest대화 확인1:0", "quest대화 확인2:1" });
        talkData.Add(30 + 2000, new string[] { "선택지성공1:0", "선택지성공2:1" });
        talkData.Add(100 + 2000, new string[] { "다시 시도quest대화 확인1:0", "다시 시도quest대화 확인2:1" });
        // 초상화 data
        portraitData.Add(1000 + 0,portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);

        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);

        
        portraitData.Add(3000 + 1, portraitArr[1]);         // 혼잣말 부분 test
        portraitData.Add(3000 + 0, portraitArr[0]);

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id- id%10))
            {
                // 퀘스트 맨 처음 대사마저 없을 때,
                // 기본 대사 가지고 옴
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //해당 퀘스트 진행 순서 대사가 없을 때,
                // 퀘스트 맨 처음 대사를 가지고 옴.
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

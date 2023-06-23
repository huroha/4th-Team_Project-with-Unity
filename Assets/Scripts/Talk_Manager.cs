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
        talkData.Add(300, new string[] { "움직이는 노트가 재료칸에 들어갔을 때 스페이스바를 눌러 재료를 담아보자!" });
        talkData.Add(400, new string[] { "가운데에 온도 조절 버튼을 눌러 온도를 맞춰보자!" });
        talkData.Add(500, new string[] { "num4" });

        // InnerRoom 전용 30000번대

        talkData.Add(0+30000, new string[] { "여긴 너무 어두운걸.....:1", "불을 켤만한 게 있을까..?:0" });       
        talkData.Add(100+30000, new string[] { "방이 밝아졌다." });
        talkData.Add(200 + 30000, new string[] { "침대에 무언가가...?:1","확인해볼까?:0" });

        talkData.Add(35100, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35200, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35300, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35400, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35500, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35600, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35700, new string[] { "토끼 인형을 발견했다." });
        // InnerRoom quest

        talkData.Add(40 + 35400, new string[] { "다음으로 넘어가자.:0" });
        talkData.Add(41 + 35500, new string[] { "다음으로 넘어가자.:0" });

        talkData.Add(50 + 35200, new string[] { "다음으로 넘어가자.:0" });
        talkData.Add(51 + 35300, new string[] { "다음으로 넘어가자.:0" });

        talkData.Add(60 + 35600, new string[] { "다음으로 넘어가자.:0" });
        talkData.Add(61 + 35100, new string[] { "무언가가 있는거 같아.:0" });
        talkData.Add(70 + 35100, new string[] { "인형이 놓여있던 장소야.:0" });

        // Boss 40000번대
        talkData.Add(0 + 40000, new string[] { "중앙에 무언가가 있어...:1", "확인해보자:0" });
        talkData.Add(0 + 41000, new string[] { "제단이 나왔어...:0" });
        talkData.Add(0 + 40100, new string[] { "아이템 올려두었따." });
        // Boss quest data  1000번대 활용

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

        // InnerRoom 초상화
        portraitData.Add(30000 + 1, portraitArr[1]);         // 진입 혼잣말
        portraitData.Add(30000 + 0, portraitArr[0]);

        portraitData.Add(30200 + 0, portraitArr[1]);        // 불켜짐
        portraitData.Add(30200 + 1, portraitArr[1]);

        //InnerRoom quest 초상화
        portraitData.Add(35100 + 0, portraitArr[0]);
        portraitData.Add(35200 + 0, portraitArr[0]);
        portraitData.Add(35300 + 0, portraitArr[0]);
        portraitData.Add(35400 + 0, portraitArr[0]);
        portraitData.Add(35500 + 0, portraitArr[0]);
        portraitData.Add(35600 + 0, portraitArr[0]);

        //Boss 초상화
        portraitData.Add(40000 + 0, portraitArr[0]);
        portraitData.Add(40000 + 1, portraitArr[1]);
        portraitData.Add(41000 + 0, portraitArr[0]);




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

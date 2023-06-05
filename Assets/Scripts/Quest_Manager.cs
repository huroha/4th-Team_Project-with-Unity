using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Manager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    Dictionary<int, QuestData> questList;

    public static Quest_Manager instance;
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
        if (Quest_Manager.instance == null)
        {
            Quest_Manager.instance = this;
        }
    }


    void GenerateData()
    {
        questList.Add(10, new QuestData("첫번째 퀘스트", new int[] { 1000,2000 }));
        questList.Add(20, new QuestData("두번째 퀘스트", new int[] { 5000,2000 }));
        questList.Add(30, new QuestData("마무리", new int[] { 5000, 2000 }));

        questList.Add(120, new QuestData("퀘스트 확인용", new int[] { 5000, 2000 }));
    }

    public int GetQuestTalkIndex(int id)                //npc id 받고 퀘스트 번호 반환
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if(id ==  questList[questId].npcId[questActionIndex])
            questActionIndex++;

        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public void NextQuest()
    {
        if (questId > 100)
        {
            questId = 20;
        }
        questId += 10;
        questActionIndex = 0;
    }
    public void PrevQuest()
    {
        questId = 120;
        questActionIndex = 0;
    }
    public void NoneQuest()
    {

    }
}


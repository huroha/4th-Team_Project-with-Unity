using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Manager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    Dictionary<int, QuestData> questList;
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("ù��° ����Ʈ", new int[] { 1000,2000 }));
        questList.Add(20, new QuestData("�ι�° ����Ʈ", new int[] { 5000,2000 }));
    }

    public int GetQuestTalkIndex(int id)                //npc id �ް� ����Ʈ ��ȣ ��ȯ
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

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
}


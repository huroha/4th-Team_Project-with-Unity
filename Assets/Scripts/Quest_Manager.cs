using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Manager : MonoBehaviour
{
    public int questId;                     // �������� ����Ʈ
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
        questList.Add(10, new QuestData("ù��° ����Ʈ", new int[] { 1000,3000 }));
        questList.Add(20, new QuestData("�ι�° ����Ʈ", new int[] { 5000,2000 }));
        questList.Add(30, new QuestData("������", new int[] { 5000, 2000 }));

        questList.Add(120, new QuestData("����Ʈ Ȯ�ο�", new int[] { 5000, 2000 }));


        questList.Add(40, new QuestData("ħ��Ȯ��1", new int[] { 35400, 35500 }));
        questList.Add(50, new QuestData("ħ��Ȯ��2", new int[] { 35200, 35300 }));
        questList.Add(60, new QuestData("ħ��Ȯ��3", new int[] { 35600, 35100 }));
        questList.Add(70, new QuestData("ħ��Ȯ�� ��", new int[] { 35600, 30000 }));
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public Talk_Manager talkManager;                        // 스크립트 참조
    public GameObject talkPanel;
    public GameObject selectPanel;
    public Text talkText;
    public Image portraitImg;                   // 초상화
    public Quest_Manager questManager;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public void Action(GameObject scanObj)
    {
        isAction = true;
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        // 대화창 on off 처리
        talkPanel.SetActive(isAction);
        if (!isAction)
        {
            Solo_Talk.instance.DestoyThis();
        }
    }
    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        // 대화 data set
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        if(talkData == null)
        {
            
            isAction = false;
            talkIndex = 0;
            questManager.CheckQuest(id);
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];


            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }
        if (talkData == "quest대화 확인2:1" || talkData == "다시 시도quest대화 확인2:1") // 대화 내용에 따라 조건을 변경.
        {
            selectPanel.SetActive(true);
        }
        else
        {
            selectPanel.SetActive(false);
        }
        if(talkData == "확인해볼까?:0")
        {
            Bed_Event.instance.actionSwitch = 0;
        }
        if(talkData == "무언가가 있는거 같아.:0")
        {
            
            InnerRoom_Rabbit.instance.dollcheck = true;
        }
        if(talkData == "토끼 인형을 발견했다.")
        {
            InnerRoom_Rabbit.instance.keycheck = true;
        }


        isAction = true;
        talkIndex++;
    }
}

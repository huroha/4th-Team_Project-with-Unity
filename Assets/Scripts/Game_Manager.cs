using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    public Camera mainCamera;   // 카메라 접근
    public Color newColor;
    public Color newColor2;
    public Talk_Manager talkManager;                        // 스크립트 참조
    public GameObject talkPanel;
    public GameObject selectPanel;
    public GameObject selectPanel2;
    public GameObject selectPanel3;
    public Text talkText;
    public Image portraitImg;                   // 초상화
    public Quest_Manager questManager;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

   
    
  
    public void ChangeBackgroundColor(Color newColor)
    {
        mainCamera.backgroundColor = newColor;
    }
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
        if (talkData == "우울? [나는 네가 만들어 주는 간식을 좋아했어. 둘중 무엇을 더 좋아했었지?]:3" || talkData == "우울? [아니, 다시 처음 문제부터 다시 생각해봐 내가 좋아하는 간식은?]:3") // 대화 내용에 따라 조건을 변경.
        {
            selectPanel.SetActive(true);
        }
        else
        {
            selectPanel.SetActive(false);
        }
        if(talkData == "우울? [이것은 뭐일까?]:3")
        {
            selectPanel2.SetActive(true);
        }
        else
        {
            selectPanel2.SetActive(false);
        }
        if(talkData == "우울? [네가 준 수많은 인형들 중 유독 한 인형을 좋아했는데, 무슨 인형이지?]:3")
        {
            selectPanel3.SetActive(true);
        }
        else
        {
            selectPanel3.SetActive(false);
        }
        if (talkData == "확인해볼까?:0")
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
            ChangeBackgroundColor(newColor);
        }
        if(talkData== "개껌을 올려두었다.")
        {
            Boss_EventController.instance.keycheck_1 = true;
            Boss_EventController.instance.patternHide();
            ChangeBackgroundColor(newColor);
            Boss_EventController.instance.bossActivate.SetActive(true);
            Boss_EventController.instance.bosshide.SetActive(false);
        }
        else if (talkData == "오리 인형을 올려두었다.")
        {
            Boss_EventController.instance.keycheck_2 = true;
            ChangeBackgroundColor(newColor2);
            Boss_EventController.instance.bossPatternhide2.SetActive(false);
            Boss_EventController.instance.bossActivate2.SetActive(true);
            Boss_EventController.instance.bosshide2.SetActive(false);
        }

        if(talkData == "토끼 인형을 올려두었다.")
        {
            Boss_EventController.instance.keycheck_3 = true;
            Boss_EventController.instance.White.SetActive(true);
            Boss_EventController.instance.getout.SetActive(true);
            Boss_EventController.instance.final_text = true;

        }
        if(talkData == "하나 [난 영원히 네 마음 속에서 행복하게 존재할거야.]:3")
        {
            Boss_EventController.instance.last_altar.SetActive(true);
        }



        isAction = true;
        talkIndex++;
    }
}

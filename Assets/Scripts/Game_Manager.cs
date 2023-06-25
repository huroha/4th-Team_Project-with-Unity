using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    public Camera mainCamera;   // ī�޶� ����
    public Color newColor;
    public Color newColor2;
    public Talk_Manager talkManager;                        // ��ũ��Ʈ ����
    public GameObject talkPanel;
    public GameObject selectPanel;
    public GameObject selectPanel2;
    public GameObject selectPanel3;
    public Text talkText;
    public Image portraitImg;                   // �ʻ�ȭ
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

        // ��ȭâ on off ó��
        talkPanel.SetActive(isAction);
        if (!isAction)
        {
            Solo_Talk.instance.DestoyThis();
        }
    }
    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        // ��ȭ data set
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
        if (talkData == "���? [���� �װ� ����� �ִ� ������ �����߾�. ���� ������ �� �����߾���?]:3" || talkData == "���? [�ƴ�, �ٽ� ó�� �������� �ٽ� �����غ� ���� �����ϴ� ������?]:3") // ��ȭ ���뿡 ���� ������ ����.
        {
            selectPanel.SetActive(true);
        }
        else
        {
            selectPanel.SetActive(false);
        }
        if(talkData == "���? [�̰��� ���ϱ�?]:3")
        {
            selectPanel2.SetActive(true);
        }
        else
        {
            selectPanel2.SetActive(false);
        }
        if(talkData == "���? [�װ� �� ������ ������ �� ���� �� ������ �����ߴµ�, ���� ��������?]:3")
        {
            selectPanel3.SetActive(true);
        }
        else
        {
            selectPanel3.SetActive(false);
        }
        if (talkData == "Ȯ���غ���?:0")
        {
            Bed_Event.instance.actionSwitch = 0;
        }
        if(talkData == "���𰡰� �ִ°� ����.:0")
        {
            
            InnerRoom_Rabbit.instance.dollcheck = true;
        }
        if(talkData == "�䳢 ������ �߰��ߴ�.")
        {
            InnerRoom_Rabbit.instance.keycheck = true;
            ChangeBackgroundColor(newColor);
        }
        if(talkData== "������ �÷��ξ���.")
        {
            Boss_EventController.instance.keycheck_1 = true;
            Boss_EventController.instance.patternHide();
            ChangeBackgroundColor(newColor);
            Boss_EventController.instance.bossActivate.SetActive(true);
            Boss_EventController.instance.bosshide.SetActive(false);
        }
        else if (talkData == "���� ������ �÷��ξ���.")
        {
            Boss_EventController.instance.keycheck_2 = true;
            ChangeBackgroundColor(newColor2);
            Boss_EventController.instance.bossPatternhide2.SetActive(false);
            Boss_EventController.instance.bossActivate2.SetActive(true);
            Boss_EventController.instance.bosshide2.SetActive(false);
        }

        if(talkData == "�䳢 ������ �÷��ξ���.")
        {
            Boss_EventController.instance.keycheck_3 = true;
            Boss_EventController.instance.White.SetActive(true);
            Boss_EventController.instance.getout.SetActive(true);
            Boss_EventController.instance.final_text = true;

        }
        if(talkData == "�ϳ� [�� ������ �� ���� �ӿ��� �ູ�ϰ� �����Ұž�.]:3")
        {
            Boss_EventController.instance.last_altar.SetActive(true);
        }



        isAction = true;
        talkIndex++;
    }
}

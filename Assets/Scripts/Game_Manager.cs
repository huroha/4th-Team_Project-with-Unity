using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public Talk_Manager talkManager;                        // ��ũ��Ʈ ����
    public GameObject talkPanel;
    public GameObject selectPanel;
    public Text talkText;
    public Image portraitImg;                   // �ʻ�ȭ
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
        if (talkData == "quest��ȭ Ȯ��2:1" || talkData == "�ٽ� �õ�quest��ȭ Ȯ��2:1") // ��ȭ ���뿡 ���� ������ ����.
        {
            selectPanel.SetActive(true);
        }
        else
        {
            selectPanel.SetActive(false);
        }
        if(talkData == "Ȯ���غ���?:0")
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
        }


        isAction = true;
        talkIndex++;
    }
}

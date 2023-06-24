using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection_Button : MonoBehaviour
{
    public Button ebutton;
    public Button ebutton2;

    public int count = 0;
    public static Selection_Button instance;
    private void Start()
    {
        ebutton.onClick.AddListener(keyAction_1);
        ebutton2.onClick.AddListener(keyAction_2);
    }

    private void Awake()
    {
        if (Selection_Button.instance == null)
        {
            Selection_Button.instance = this;
        }
    }

    public void keyAction_1()
    {
         Debug.Log("정답");
         PlayerActor.instance.PressEKey();
        if(Quest_Manager.instance.questId != 20)
        {
            Quest_Manager.instance.NextQuest();
        }
        else
        {
            Quest_Manager.instance.NextQuest2();
        }
        
    }
    public void keyAction_2()
    {
        Debug.Log("오답");
        PlayerActor.instance.PressEKey();

        Quest_Manager.instance.PrevQuest();
        count = 0;
        count++;

    }

}

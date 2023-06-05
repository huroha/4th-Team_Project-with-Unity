using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection_Button : MonoBehaviour
{
    public Button ebutton;
    public Button ebutton2;
    public Button ebutton3;

 
    private void Start()
    {
        ebutton.onClick.AddListener(keyAction_1);
        ebutton2.onClick.AddListener(keyAction_2);
        ebutton3.onClick.AddListener(keyAction_3);
    }



    public void keyAction_1()
    {
         Debug.Log("1번 눌림");
         PlayerActor.instance.PressEKey();
         Quest_Manager.instance.NextQuest();
    }
    public void keyAction_2()
    {
        Debug.Log("2번 눌림");
        PlayerActor.instance.PressEKey();
        Quest_Manager.instance.PrevQuest();
    }
    public void keyAction_3()
    {
        Debug.Log("3번 눌림");
        PlayerActor.instance.PressEKey();
        Quest_Manager.instance.PrevQuest();
    }
}

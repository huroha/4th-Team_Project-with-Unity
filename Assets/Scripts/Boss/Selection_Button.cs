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


    // 여기서 시바 e키 누른 처리하고 quest 분기점 만들어서? 지랄하고? 해야됨?

    public void keyAction_1()
    {
         Debug.Log("1번 눌림");
    }
    public void keyAction_2()
    {
        Debug.Log("2번 눌림");
    }
    public void keyAction_3()
    {
        Debug.Log("3번 눌림");
    }
}

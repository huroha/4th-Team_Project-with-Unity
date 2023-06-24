using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_EventController : MonoBehaviour
{
    public GameObject bossPattern1;
    public GameObject bossPattern2;
    public GameObject bossPatternhide;
    public GameObject bossPatternhide2;
    public GameObject key1;             //��� ����
    public GameObject key2;
    public GameObject key3;

    public GameObject last_altar;
    public GameObject White;
    public GameObject getout;

    public GameObject bossActivate;     // 2��° ���Ͽ�
    public GameObject bosshide;

    public GameObject bossActivate2;    // 3��° ���Ͽ�
    public GameObject bosshide2;

    public GameObject bossActivate3;    // ������ ��������.
    public GameObject bosshide3;



    public GameObject playerObj;        // �������� �۵���
    public GameObject playerObj2;

    private int hidecount = 0;
    public bool keycheck_1 = false;
    public bool keycheck_2 = false;
    public bool keycheck_3 = false;
    private bool pattern2check = true;

    public static Boss_EventController instance;

    void Start()
    {
        playerObj = GameObject.Find("Player");
        playerObj2 = GameObject.Find("Player");

    }
    private void Awake()
    {
        if (Boss_EventController.instance == null)
        {
            Boss_EventController.instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Quest_Manager.instance.questActionIndex + Quest_Manager.instance.questId == 1)
        {
            bossPattern1.SetActive(true);
        }

        else if (Quest_Manager.instance.questActionIndex + Quest_Manager.instance.questId == 10)
        {
            bossPattern2.SetActive(true);
            if (pattern2check)
            {
                playerObj.GetComponent<Boss_pattern1>().enabled = true;
                pattern2check = false;
            }
            

        }
        if (keycheck_1)
        {
            key1.SetActive(true);
            keycheck_1 = false;
        }
        else if (keycheck_2)
        {
            key2.SetActive(true);
            keycheck_2 = false;
        }
        else if (keycheck_3)
        {
            key3.SetActive(true);
            keycheck_3 = false;
        }
        if(Quest_Manager.instance.questId == 40)
        {
            bosshide3.SetActive(false);
            bossActivate3.SetActive(true);
            last_altar.SetActive(true);
        }



    }
    public void patternHide()
    {
        if(hidecount == 0)
        {
            bossPatternhide.SetActive(false);
            hidecount++;
        }
 
      
    }
}

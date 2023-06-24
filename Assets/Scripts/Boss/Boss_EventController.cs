using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_EventController : MonoBehaviour
{
    public GameObject bossPattern1;
    public GameObject bossPattern2;
    public GameObject bossPatternhide;
    public GameObject key1;

    public GameObject bossActivate;
    public GameObject bosshide;

    public GameObject playerObj;

    public bool keycheck_1 = false;
    public static Boss_EventController instance;

    void Start()
    {
        playerObj = GameObject.Find("Player");
        
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
        if(Quest_Manager.instance.questActionIndex + Quest_Manager.instance.questId == 11)
        {
            bossPattern1.SetActive(true);
        }

        else if (Quest_Manager.instance.questActionIndex + Quest_Manager.instance.questId == 20)
        {
            bossPattern2.SetActive(true);
            playerObj.GetComponent<Boss_pattern1>().enabled = true;
        }
        if (keycheck_1)
        {
            key1.SetActive(true);
            keycheck_1 = false;
        }


    }
    public void patternHide()
    {
        bossPatternhide.SetActive(false);
    }
}

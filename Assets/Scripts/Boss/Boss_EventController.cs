using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_EventController : MonoBehaviour
{
    public GameObject bossPattern1;
    public GameObject key1;
    public GameObject StunObj;

    public bool stuncheck = false;
    public bool keycheck_1 = false;
    public static Boss_EventController instance;

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

        if (keycheck_1)
        {
            key1.SetActive(true);
            keycheck_1 = false;
        }

        if (stuncheck)
        {
            StunObj.SetActive(true);
        }
        
    }

}

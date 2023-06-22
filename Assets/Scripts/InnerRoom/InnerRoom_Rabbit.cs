using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRoom_Rabbit : MonoBehaviour
{
    public static InnerRoom_Rabbit instance;
    public bool dollcheck = false;
    public bool keycheck = false;
    public GameObject rabbit;
    public GameObject hidecover;
    public GameObject rabbit2;
    public GameObject hidecover2;

    private void Awake()
    {
        if (InnerRoom_Rabbit.instance == null)
        {
            InnerRoom_Rabbit.instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dollcheck)
        {
            rabbit.SetActive(true);
            hidecover.SetActive(false);
            dollcheck = false;
        }
        if (keycheck)
        {
            rabbit2.SetActive(false);
            hidecover2.SetActive(true);
            keycheck = false;
        }
    }
}

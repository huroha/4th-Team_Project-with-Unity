using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_pattern1: MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject zone_object;
    public GameObject zone_object2;

    public GameObject AltarObj;


    public int clear_count = 0;
    private bool check = false;
    private bool check_once = true;

    SoundManager soundManager;
    IEnumerator ActivateObject1()
    {
        while (true)
        {
            check = false;
            object1.SetActive(false);
            zone_object.SetActive(false);
            zone_object2.SetActive(false);
            check_once = true;
            yield return new WaitForSeconds(4f);
            object1.SetActive(true);
            if(clear_count == 0)
            {
                 zone_object.SetActive(true);
            }
            else if(clear_count == 1)
            {
                zone_object2.SetActive(true);
            }
            yield return new WaitForSeconds(6f);
            
        }
    }

    IEnumerator ActivateObject2()
    {
        while (true)
        {
            object2.SetActive(false);
            yield return new WaitForSeconds(8f);
            object2.SetActive(true);
            yield return new WaitForSeconds(2f);
            
        }
    }

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.setSource("rain");
        StartCoroutine(ActivateObject1());
        StartCoroutine(ActivateObject2());
    }
    private void Update()
    {
        if(object1.activeSelf && object2.activeSelf)
        {
            if (check_once)
            {
                if (check)
                {
                    Debug.Log("safe zone clear");
                    check_once = false;
                    clear_count++;
                    PlayerActor.instance.PressEKey();
                }
                else
                {
                    Debug.Log("safe zone fail");
                    check_once = false;
                    //PlayerActor.instance.PressEKey();
                }
            }
          
        }
        if(clear_count == 2)
        {
            soundManager.getCh().Stop();
            object1.SetActive(false);
            object2.SetActive(false);
            AltarObj.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        {
            check = true;
        }
           
    }
}

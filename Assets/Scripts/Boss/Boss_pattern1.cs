using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_pattern1: MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject zone_object;

    private bool check = false;
    private bool check_once = true;
    private IEnumerator ActivateObject1()
    {
        while (true)
        {
            check = false;
            object1.SetActive(false);
            zone_object.SetActive(false);
            check_once = true;
            yield return new WaitForSeconds(6f);
            object1.SetActive(true);
            zone_object.SetActive(true);
            yield return new WaitForSeconds(9f);
            
        }
    }

    private IEnumerator ActivateObject2()
    {
        while (true)
        {
            object2.SetActive(false);
            yield return new WaitForSeconds(12f);
            object2.SetActive(true);
            yield return new WaitForSeconds(3f);
            
        }
    }

    private void Start()
    {
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
                    PlayerActor.instance.PressEKey();
                }
                else
                {
                    Debug.Log("safe zone fail");
                    check_once = false;
                    PlayerActor.instance.PressEKey();
                }
            }
          
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

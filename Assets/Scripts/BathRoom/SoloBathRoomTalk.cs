using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloBathRoomTalk : MonoBehaviour
{
    public int is_first = 0;
    public GameObject obj;
    public GameObject obj2;
    public int obj_count = 0;
    public bool isTrigger = false;

    public static SoloBathRoomTalk instance;
    private void Awake()
    {
        if (SoloBathRoomTalk.instance == null)
        {
            SoloBathRoomTalk.instance = this;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (is_first == 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("È¥Àã¸» ½ÇÇà");
                PlayerActor.instance.PressEKey();
            }
            //is_first++;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.name == "w")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("¸Â´ê¾ÆÀÖ´ÂÁß");
                isTrigger = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == "w")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("¸Ö¾îÁø´Ù");
                isTrigger = false;
                obj2.SetActive(false);
                obj.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if(isTrigger)
        {
            gameObject.transform.Translate(Vector3.up * 0.0001f);
        }
    }
    public void DestoyThis()
    {
        if (obj_count == 0)
        {
            obj.SetActive(false);
            obj_count++;
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solo_Talk : MonoBehaviour
{
    public bool is_first = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (is_first)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("»•¿„∏ª Ω««‡");
                PlayerActor.instance.PressEKey();
                is_first = false;
            }
        }
    }
}

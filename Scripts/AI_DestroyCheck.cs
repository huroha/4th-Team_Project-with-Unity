using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_DestroyCheck : MonoBehaviour
{
    public GameObject objectToActivate;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("goal"))
        {
            Debug.Log("Ai destroy");
            Destroy(other.gameObject);
            objectToActivate.SetActive(true);
        }
    }
}

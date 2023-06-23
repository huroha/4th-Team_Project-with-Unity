using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_DestroyCheck : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject Clear;

    public static AI_DestroyCheck instance;
    private void Awake()
    {
        if (AI_DestroyCheck.instance == null)
        {
            AI_DestroyCheck.instance = this;
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("goal"))
        {
            Debug.Log("Ai destroy");
            Destroy(other.gameObject);
            objectToActivate.SetActive(true);
            PlayerActor.instance.PressEKey();
            
        }
    }
}

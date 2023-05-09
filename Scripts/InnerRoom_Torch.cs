using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRoom_Torch : MonoBehaviour
{
    // Start is called before the first frame
    [SerializeField] private GameObject objectToActivate; // 활성화할 오브젝트
    [SerializeField] private string triggerTag = "Player"; // Trigger를 발생시키는 오브젝트의 태그

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(triggerTag))
        {
            Debug.Log("torch on");
            objectToActivate.SetActive(true);
        }
    }
}

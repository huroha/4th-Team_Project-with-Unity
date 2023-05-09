using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRoom_Torch : MonoBehaviour
{
    // Start is called before the first frame
    [SerializeField] private GameObject objectToActivate; // Ȱ��ȭ�� ������Ʈ
    [SerializeField] private string triggerTag = "Player"; // Trigger�� �߻���Ű�� ������Ʈ�� �±�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(triggerTag))
        {
            Debug.Log("torch on");
            objectToActivate.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRoom_Torch : MonoBehaviour
{
    // Start is called before the first frame
    public GameObject objectToActivate; // Ȱ��ȭ�� ������Ʈ
    public GameObject objectToActivate2;
    [SerializeField] private string triggerTag = "Player"; // Trigger�� �߻���Ű�� ������Ʈ�� �±�
    public GameObject objectToDeAtivate;    // ��Ȱ��ȭ ������Ʈ

    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(triggerTag))
        {
            Debug.Log("torch on");
            objectToActivate.SetActive(true);
            objectToActivate2.SetActive(true);
            objectToDeAtivate.SetActive(false);
            soundManager.setSource("torch");

        }
    }
}

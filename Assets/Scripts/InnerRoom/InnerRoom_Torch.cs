using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRoom_Torch : MonoBehaviour
{
    // Start is called before the first frame
    public GameObject objectToActivate; // 활성화할 오브젝트
    public GameObject objectToActivate2;
    [SerializeField] private string triggerTag = "Player"; // Trigger를 발생시키는 오브젝트의 태그
    public GameObject objectToDeAtivate;    // 비활성화 오브젝트

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

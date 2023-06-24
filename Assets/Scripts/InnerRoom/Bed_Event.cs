using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 잠깐동안 모습이 바뀌는거 구현
public class Bed_Event : MonoBehaviour
{
    public GameObject[] objects;
    public float inactiveDuration = 0.5f;
    public float activeDuration = 1f;
    public int coroutineCount = 6;
    private int currentIndex = 0;
    private bool routinecheck = false;
    public int actionSwitch = 1;
    public static Bed_Event instance;
    SoundManager soundManager;

    private void Awake()
    {
        if (Bed_Event.instance == null)
        {
            Bed_Event.instance = this;
        }
    }
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
    }

    void Update()
    {
        if (!routinecheck && Input.GetKeyDown(KeyCode.E) && actionSwitch == 0)       // E 키 and 한번만 실행되도록 설정
        {
            StartCoroutine(ActivateObjects());
            
        }
    }

    IEnumerator ActivateObjects()
    {
        routinecheck = true;
       
        for (int i = 0; i < coroutineCount; i++)
        {
            objects[currentIndex].SetActive(true);
            yield return new WaitForSeconds(activeDuration);
            soundManager.setSource("ebul");
            objects[currentIndex].SetActive(false);
            currentIndex++;

            if (currentIndex >= objects.Length)
            {
                currentIndex = 0;
            }

            yield return new WaitForSeconds(inactiveDuration);
        }

        
        routinecheck = false;
        actionSwitch = 1;
    }
}


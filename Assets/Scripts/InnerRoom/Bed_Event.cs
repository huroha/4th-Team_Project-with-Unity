using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 잠깐동안 모습이 바뀌는거 구현
public class Bed_Event : MonoBehaviour
{
    public GameObject[] objects;
    public int timeInterval = 1;                       
    private int currentIndex = 0;                          
    private bool routinecheck = false;                   

    void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
    }

    void Update()
    {
        if (!routinecheck && Input.GetKeyDown(KeyCode.E))       // E 키 and 한번만 실행되도록 설정
        {
            StartCoroutine(ActivateObjects());
        }
    }

    IEnumerator ActivateObjects()
    {
        routinecheck = true;
        objects[currentIndex].SetActive(true);
        currentIndex++;

        if (currentIndex >= objects.Length)
        {
            currentIndex = 0;
        }

        yield return new WaitForSeconds(timeInterval);

        objects[currentIndex].SetActive(true);
        currentIndex++;

        if (currentIndex >= objects.Length)
        {
            currentIndex = 0;
        }

        yield return new WaitForSeconds(timeInterval);

        objects[currentIndex].SetActive(true);
        routinecheck = false;
    }
}


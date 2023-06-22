using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRoom_Dark : MonoBehaviour
{
    public GameObject Controller;
    public GameObject[] activateObjects; // 활성화할 오브젝트들을 배열로 저장
    public GameObject deactivateObject; // 비활성화할 오브젝트
    public GameObject EventStart;
    public GameObject Twinkle;
    public int once_check = 1;
    public bool errorcheck = true; // 지속 인덱스 증가 방지용


    private int i = 0;

    private int activatedCount = 0; // 활성화된 오브젝트 수를 추적

    private bool isFadingOut = false; // 페이드아웃이 진행 중인지 확인
    private float fadeDuration = 1.5f; // 페이드아웃 효과의 지속 시간
    private void Update()
    {
        // 각 오브젝트마다 검사하고 활성화된 오브젝트 수 증가
        if (errorcheck)
        {
            if (activateObjects[i].activeSelf)
            {
                activatedCount++;
                Debug.Log("활성화");
                i++;
            }
        }
           
        // 만약 활성화된 오브젝트 수가 3개라면 페이드아웃 효과 시작
        if (activatedCount >= 3 && !isFadingOut)
        {
            StartCoroutine(FadeOutObject());
            isFadingOut = true;
            errorcheck = false;
        }




    }
    private IEnumerator FadeOutObject()
    {
        // 초기 오브젝트 투명도 가져오기
        float startOpacity = deactivateObject.GetComponent<Renderer>().material.color.a;

        // 목표 투명도 계산 (완전 투명)
        float targetOpacity = 0f;

        // 페이드아웃 중 경과 시간 추적
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // 경과 시간에 따라 새로운 투명도 계산
            float newOpacity = Mathf.Lerp(startOpacity, targetOpacity, elapsedTime / fadeDuration);

            // 오브젝트의 재질 색상 업데이트 (새로운 투명도 적용)
            Color newColor = deactivateObject.GetComponent<Renderer>().material.color;
            newColor.a = newOpacity;
            deactivateObject.GetComponent<Renderer>().material.color = newColor;

            // 경과 시간 증가
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 페이드아웃 완료 후 오브젝트 비활성화
        Twinkle.SetActive(true);
        EventStart.SetActive(true);
        deactivateObject.SetActive(false);
        Controller.GetComponent<InnerRoom_Dark>().enabled = false;

    }

}

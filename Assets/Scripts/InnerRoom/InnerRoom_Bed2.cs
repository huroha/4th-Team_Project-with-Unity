using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 순서대로 상호작용 미니게임 구현
public class InnerRoom_Bed2 : MonoBehaviour
{
    // 상호작용 대상들
    public GameObject[] interactionObjects;

    // 상호작용 순서
    private GameObject[] interactionOrder;

    // 현재 상호작용 인덱스
    private int currentInteractionIndex = 0;

    public static InnerRoom_Bed2 instance;
    public bool e_Check = false;
    private void Awake()
    {
        if (InnerRoom_Bed2.instance == null)
        {
           InnerRoom_Bed2.instance = this;
        }
    }
    void Start()
    {
        // 상호작용 순서 설정
        interactionOrder = new GameObject[] { interactionObjects[0], interactionObjects[1], interactionObjects[2] };
    }

    // 상호작용 감지 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (e_Check)
        {
            // 상호작용 대상이 아닌 경우 무시
            if (!other.gameObject.CompareTag("Bed"))
            {
                return;
            }


            // 현재 상호작용 대상과 다음 상호작용 대상이 맞는지 체크
            if (other.gameObject == interactionOrder[currentInteractionIndex])
            {

                // 상호작용 대상에 대한 처리
                Debug.Log("Interacting with " + other.gameObject.name);

                // 다음 상호작용 대상으로 인덱스 증가
                currentInteractionIndex++;

                // 모든 상호작용이 끝나면 초기화
                if (currentInteractionIndex >= interactionOrder.Length)
                {
                    ResetInteraction();
                }
            }
            else
            {
                // 순서가 맞지 않을 때의 처리
                Debug.Log("Wrong interaction order! 잘못된 순서" + interactionOrder[currentInteractionIndex].name + " 번으로 현재 상호작용 : " + other.gameObject.name);
            }
        }
        e_Check = false;
    }

    // 상호작용 초기화 함수
    public void ResetInteraction()
    {
        // 인덱스 초기화
        currentInteractionIndex = 0;

        // 처리할 작업 추가
        Debug.Log("Interaction completed!");

        // 상호작용 순서 재설정
        interactionOrder = new GameObject[] { interactionObjects[0], interactionObjects[1], interactionObjects[2] };
    }
}
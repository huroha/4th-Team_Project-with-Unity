using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void CinemachineFinishedEventHandler();
    public static event CinemachineFinishedEventHandler OnCinemachineFinished;

    private void CinemachineDone()
    {
        // 이벤트를 트리거
        OnCinemachineFinished?.Invoke();
        // ?. 는 null을 check 하는 C# 연산자. 만약 OnCine 뭐시기가 null이 아니면 Invoke() 를 발동, null이면 스킵
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

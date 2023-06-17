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
        // �̺�Ʈ�� Ʈ����
        OnCinemachineFinished?.Invoke();
        // ?. �� null�� check �ϴ� C# ������. ���� OnCine ���ñⰡ null�� �ƴϸ� Invoke() �� �ߵ�, null�̸� ��ŵ
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

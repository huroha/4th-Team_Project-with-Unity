using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ������� ��ȣ�ۿ� �̴ϰ��� ����
public class InnerRoom_Bed2 : MonoBehaviour
{
    // ��ȣ�ۿ� ����
    public GameObject[] interactionObjects;

    // ��ȣ�ۿ� ����
    private GameObject[] interactionOrder;

    // ���� ��ȣ�ۿ� �ε���
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
        // ��ȣ�ۿ� ���� ����
        interactionOrder = new GameObject[] { interactionObjects[0], interactionObjects[1], interactionObjects[2] };
    }

    // ��ȣ�ۿ� ���� �Լ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (e_Check)
        {
            // ��ȣ�ۿ� ����� �ƴ� ��� ����
            if (!other.gameObject.CompareTag("Bed"))
            {
                return;
            }


            // ���� ��ȣ�ۿ� ���� ���� ��ȣ�ۿ� ����� �´��� üũ
            if (other.gameObject == interactionOrder[currentInteractionIndex])
            {

                // ��ȣ�ۿ� ��� ���� ó��
                Debug.Log("Interacting with " + other.gameObject.name);

                // ���� ��ȣ�ۿ� ������� �ε��� ����
                currentInteractionIndex++;

                // ��� ��ȣ�ۿ��� ������ �ʱ�ȭ
                if (currentInteractionIndex >= interactionOrder.Length)
                {
                    ResetInteraction();
                }
            }
            else
            {
                // ������ ���� ���� ���� ó��
                Debug.Log("Wrong interaction order! �߸��� ����" + interactionOrder[currentInteractionIndex].name + " ������ ���� ��ȣ�ۿ� : " + other.gameObject.name);
            }
        }
        e_Check = false;
    }

    // ��ȣ�ۿ� �ʱ�ȭ �Լ�
    public void ResetInteraction()
    {
        // �ε��� �ʱ�ȭ
        currentInteractionIndex = 0;

        // ó���� �۾� �߰�
        Debug.Log("Interaction completed!");

        // ��ȣ�ۿ� ���� �缳��
        interactionOrder = new GameObject[] { interactionObjects[0], interactionObjects[1], interactionObjects[2] };
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRoom_Dark : MonoBehaviour
{
    public GameObject Controller;
    public GameObject[] activateObjects; // Ȱ��ȭ�� ������Ʈ���� �迭�� ����
    public GameObject deactivateObject; // ��Ȱ��ȭ�� ������Ʈ
    private int i = 0;

    private int activatedCount = 0; // Ȱ��ȭ�� ������Ʈ ���� ����

    private bool isFadingOut = false; // ���̵�ƿ��� ���� ������ Ȯ��
    private float fadeDuration = 1.5f; // ���̵�ƿ� ȿ���� ���� �ð�
    private void Update()
    {
        // �� ������Ʈ���� �˻��ϰ� Ȱ��ȭ�� ������Ʈ �� ����

            if (activateObjects[i].activeSelf)
            {
                activatedCount++;
                Debug.Log("Ȱ��ȭ");
                i++;
            }
        // ���� Ȱ��ȭ�� ������Ʈ ���� 3����� ���̵�ƿ� ȿ�� ����
        if (activatedCount >= 3 && !isFadingOut)
        {
            StartCoroutine(FadeOutObject());
            isFadingOut = true;
        }


        // ���� Ȱ��ȭ�� ������Ʈ ���� 3����� ��Ȱ��ȭ�� ������Ʈ�� ��Ȱ��ȭ
        if (activatedCount >= 3)
        {
            StartCoroutine(FadeOutObject());
            isFadingOut = true;
        }

    }
    private IEnumerator FadeOutObject()
    {
        // �ʱ� ������Ʈ ���� ��������
        float startOpacity = deactivateObject.GetComponent<Renderer>().material.color.a;

        // ��ǥ ���� ��� (���� ����)
        float targetOpacity = 0f;

        // ���̵�ƿ� �� ��� �ð� ����
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // ��� �ð��� ���� ���ο� ���� ���
            float newOpacity = Mathf.Lerp(startOpacity, targetOpacity, elapsedTime / fadeDuration);

            // ������Ʈ�� ���� ���� ������Ʈ (���ο� ���� ����)
            Color newColor = deactivateObject.GetComponent<Renderer>().material.color;
            newColor.a = newOpacity;
            deactivateObject.GetComponent<Renderer>().material.color = newColor;

            // ��� �ð� ����
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ���̵�ƿ� �Ϸ� �� ������Ʈ ��Ȱ��ȭ
        deactivateObject.SetActive(false);
        Controller.GetComponent<InnerRoom_Dark>().enabled = false;
    }

}

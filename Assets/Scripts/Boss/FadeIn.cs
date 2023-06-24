using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float fadeSpeed = 1.0f; // ���̵� �� �ӵ�

    public SpriteRenderer spriteRenderer;
    private bool isColliding = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(
            spriteRenderer.color.r,
            spriteRenderer.color.g,
            spriteRenderer.color.b,
            0f); // �ʱ� ���� ���� 0���� �����Ͽ� ������Ʈ�� �����ϰ� �����ϵ��� �մϴ�.
    }

    private void Update()
    {
        if (isColliding)
        {
            FadeInEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void FadeInEvent()
    {
        Color currentColor = spriteRenderer.color;
        float newAlpha = Mathf.Lerp(currentColor.a, 1f, fadeSpeed * Time.deltaTime); // ������ ���� ���� 1�� ������ŵ�ϴ�.
        spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

        if (newAlpha >= 0.99f) // ���� ���� ���� 1�� �����ϸ� �浹 ó���� �����մϴ�.
        {
            isColliding = false;
        }
    }
}

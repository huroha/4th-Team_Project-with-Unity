using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float fadeSpeed = 1.0f; // 페이드 인 속도

    public SpriteRenderer spriteRenderer;
    private bool isColliding = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(
            spriteRenderer.color.r,
            spriteRenderer.color.g,
            spriteRenderer.color.b,
            0f); // 초기 알파 값을 0으로 설정하여 오브젝트가 투명하게 시작하도록 합니다.
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
        float newAlpha = Mathf.Lerp(currentColor.a, 1f, fadeSpeed * Time.deltaTime); // 서서히 알파 값을 1로 증가시킵니다.
        spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

        if (newAlpha >= 0.99f) // 알파 값이 거의 1에 도달하면 충돌 처리를 종료합니다.
        {
            isColliding = false;
        }
    }
}

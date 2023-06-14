using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{   
    public float fadeDuration = 1f; // ���̵� ���� �Ϸ�Ǵ� �� �ɸ��� �ð�
    private Image fadeImage;
    private float fadeTimer;
    private bool fadeInStart = false;
    private bool fadeOutStart = false;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        fadeTimer = 0f;
    }

    void Update()
    {
        if (fadeInStart)
        {
            Debug.Log("���̵��� ����");
            fadeTimer += Time.deltaTime;

            fadeImage.color = Color.clear;
            float t = fadeTimer / fadeDuration;
            fadeImage.color = Color.Lerp(Color.black, Color.clear, t);

            if (fadeTimer >= fadeDuration)
            {
                fadeTimer = 0f;
                fadeInStart = false;
            }
        }
        else if(fadeOutStart)
        {
            Debug.Log("���̵�ƿ� ����");
            fadeTimer += Time.deltaTime;

            fadeImage.color = Color.black;
            float t = fadeTimer / fadeDuration;
            fadeImage.color = Color.Lerp(Color.clear, Color.black, t);
            if (fadeTimer >= fadeDuration)
            {
                fadeTimer = 0f;
                fadeOutStart = false;
            }
        }
    }

    public void FadeIn()
    {
        fadeInStart = true;
        fadeOutStart = false; // ������ �κ�: FadeIn() ȣ�� �ÿ��� FadeOut()�� ������
    }

    public void FadeOut()
    {
        fadeOutStart = true;
        fadeInStart = false; // ������ �κ�: FadeOut() ȣ�� �ÿ��� FadeIn()�� ������
    }

    public void FadeClear()
    {
        fadeImage.color = Color.clear;
    }

    public void FadeBlack()
    {
        fadeImage.color = Color.black;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{   
    public float fadeDuration = 1f; // 페이드 인이 완료되는 데 걸리는 시간
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
            Debug.Log("페이드인 실행");
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
            Debug.Log("페이드아웃 실행");
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
        fadeOutStart = false; // 수정된 부분: FadeIn() 호출 시에는 FadeOut()을 중지함
    }

    public void FadeOut()
    {
        fadeOutStart = true;
        fadeInStart = false; // 수정된 부분: FadeOut() 호출 시에는 FadeIn()을 중지함
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
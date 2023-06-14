using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public float fadeDuration = 5f; // 페이드 인이 완료되는 데 걸리는 시간
    public float delay = 2f; // 게임 시작 후 대기 시간

    private Image fadeImage;
    private float fadeTimer;
    private Color initialColor;
    private Color targetColor;
    private bool isFadeInStarted;

    private void Start()
    {
        fadeImage = GetComponent<Image>();
        initialColor = fadeImage.color;
        targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f); // 투명한 색상으로 설정
        fadeTimer = 0f;
        isFadeInStarted = false;
        Invoke("StartFadeIn", delay);
    }

    public void Update()
    {
        if (isFadeInStarted)
        {
            fadeTimer += Time.deltaTime;

            // 점차적으로 밝아지는 로직
            float t = fadeTimer / fadeDuration;
            fadeImage.color = Color.Lerp(initialColor, targetColor, t);

            // fadeDuration 이후에 이미지를 비활성화
            if (fadeTimer >= fadeDuration)
            {
                isFadeInStarted = false;
                enabled = false; // 이 스크립트를 비활성화
            }
        }
    }

    private void StartFadeIn()
    {
        isFadeInStarted = true;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Camera mainCamera;  // ���� ī�޶�
    public Camera subCamera;   // ���� ī�޶�

    public float fadeDuration = 5f; // ���̵� ���� �Ϸ�Ǵ� �� �ɸ��� �ð�
    public float delay = 2f; // ���� ���� �� ��� �ð�

    private Image fadeImage;
    private float fadeTimer;
    private Color initialColor;
    private Color targetColor;
    private bool isFadeInStarted;

    private void Start()
    {
        fadeImage = GetComponent<Image>();
        initialColor = fadeImage.color;
        targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f); // ������ �������� ����
        fadeTimer = 0f;
        isFadeInStarted = false;
        subCamera.enabled = true;
        mainCamera.enabled = false;
        Invoke("StartFadeIn", delay);
    }

    private void Update()
    {
        if (isFadeInStarted)
        {
            fadeTimer += Time.deltaTime;

            // ���������� ������� ����
            float t = fadeTimer / fadeDuration;
            fadeImage.color = Color.Lerp(initialColor, targetColor, t);

            // fadeDuration ���Ŀ� �̹����� ��Ȱ��ȭ
            if (fadeTimer >= fadeDuration)
            {
                fadeImage.enabled = false;
                enabled = false; // �� ��ũ��Ʈ�� ��Ȱ��ȭ
            }
        }
    }

    private void StartFadeIn()
    {
        isFadeInStarted = true;
    }
}
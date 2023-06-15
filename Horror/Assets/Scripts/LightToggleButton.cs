using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;
using System.Collections;

public class LightToggleButton : MonoBehaviour
{
    public Light targetLight;
    public GameObject fadeObject;
    public GameObject targetObject;
    public GameObject screenObject;
    public GameObject doorObject;
    public VideoPlayer video;
    public VideoClip monologueClip;
    public AudioSource staticSound;
    public AudioSource switchSound;
    public Color onColor = Color.white; 
    public Color offColor = Color.black;
    private bool isLightOn = false;
    public bool event1 = false; // 911 통화 후 발생 이벤트
    private Material material;
    private Renderer renderer;


    private void Start()
    {
        renderer = targetObject.GetComponent<Renderer>(); // 대상 오브젝트의 Renderer 컴포넌트 가져오기
        material = renderer.material; // 메테리얼 가져오기
    }

    private void Click()
    {
        Debug.Log(material);
        Debug.Log("click 함수 실행");

        // 조명 상태에 따라 토글합니다.
        if (!isLightOn)
        {
            LightOn();
            if(event1 == true)
            {
                Debug.Log("조명 스위치 event1 실행 확인");
                staticSound.Stop();
                StartCoroutine(Event1Play());
            }
        }
        else
        {
            LightOff();
        }
    }

    private IEnumerator Event1Play()
    {
        event1 = false;
        Debug.Log("조명 스위치 Event1 실행");
        yield return new WaitForSeconds(3f);
        fadeObject.GetComponent<Fade>().FadeOut();
        yield return new WaitForSeconds(2f);
        screenObject.SetActive(true);
        video.enabled = true;
        video.clip = monologueClip;
        video.Play();
        fadeObject.GetComponent<Fade>().FadeClear();
        video.loopPointReached += OnVideoEnd2;
    }

    public void LightOn()
    {
        switchSound.Play();
        targetLight.enabled = true;
        isLightOn = true;
        material.SetColor("_EmissionColor", onColor * 1);
    }

    public void LightOff()
    {
        switchSound.Play();
        targetLight.enabled = false;
        isLightOn = false;
        material.SetColor("_EmissionColor", offColor * 0);
    }

    private void OnVideoEnd2(VideoPlayer vp)
    {
        if (vp == video) {

            doorObject.GetComponent<Door>().check1 = true;
            fadeObject.GetComponent<Fade>().FadeIn();
            screenObject.SetActive(false);
            video.enabled = false;
        }
    }
}
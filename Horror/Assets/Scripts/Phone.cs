using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public bool clickPhone = false;
    public bool clickPhone2 = false;
    public GameObject doorObject;
    public GameObject screenObject;
    public GameObject tvScreenObject;
    public GameObject fadeObject;
    public GameObject lightSwitchObject;
    public AudioSource staticSound;
    public AudioSource audioSource;
    public AudioClip policeCall;
    public AudioClip policeSound;
    public AudioClip konck2;
    public VideoPlayer video;
    private Color onColor = Color.white;
    private Color offColor = Color.black;
    private Renderer renderer;
    private Material material;


    private void Start()
    {
        renderer = this.GetComponent<Renderer>(); // 대상 오브젝트의 Renderer 컴포넌트 가져오기
        material = renderer.material; // 메테리얼 가져오기
    }

    private void Click()
    {
        if (clickPhone)
        {
            clickPhone = false;
            Debug.Log("테스트");
            fadeObject.GetComponent<Fade>().FadeOut();
            StartCoroutine(DelayedAction());
            IEnumerator DelayedAction()
            {
                yield return new WaitForSeconds(3f);
                screenObject.SetActive(true);
                video.enabled = true;
                fadeObject.GetComponent<Fade>().FadeClear();
                video.Play();
                audioSource.Stop();
                video.loopPointReached += DoorOn;
            }
        }
        else if (clickPhone2)
        {
            clickPhone2 = false;
            Event2();
        }
    }

    public void Event1()
    {
        material.SetColor("_EmissionColor", onColor * 1);
        audioSource.Play();
    }

    public void Event2()
    {
        Debug.Log("테스트테스트");
        audioSource.clip = policeCall;
        audioSource.loop = false;
        fadeObject.GetComponent<Fade>().FadeOut();
        audioSource.Play();

        StartCoroutine(WaitForAudioClipEnd());
    }
    public void DoorOn(VideoPlayer vp)
    {
        if (vp == video)
        {
            material.SetColor("_EmissionColor", onColor * 0);
            fadeObject.GetComponent<Fade>().FadeIn();
            video.enabled = false;
            screenObject.SetActive(false);
            doorObject.GetComponent<Door>().played = true;
        }
    }

    private IEnumerator WaitForAudioClipEnd()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        audioSource.clip = policeSound;
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        fadeObject.GetComponent<Fade>().FadeIn();
        yield return new WaitForSeconds(3f);
        tvScreenObject.GetComponent<Tv>().TvOff();
        staticSound.GetComponent<StaticSound>().Event1();
        lightSwitchObject.GetComponent<LightToggleButton>().event1 = true;
        yield return new WaitForSeconds(2f);
        doorObject.GetComponent<Door>().PlayDoorAudio(konck2);
    }
}

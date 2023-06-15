using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject fadeObject;
    public GameObject screenObject;
    public GameObject phoneObject;
    public VideoPlayer video;
    public AudioClip AudioClip;
    public VideoClip videoClip;
    public VideoClip videoClip2;
    public AudioSource audio;
    public bool check1 = false;
    public bool played = false;
    public bool eventExit = false;
    public bool isClickEventRunning = false;

    void Start()
    {

    }

    void Click()
    {
        if (isClickEventRunning)
        {
            // 클릭 이벤트가 이미 실행 중인 경우, 추가 클릭을 무시합니다.
            return;
        }

        if (played == true)
        {
            fadeObject.GetComponent<Fade>().FadeOut();
            StartCoroutine(DelayedAction());
            IEnumerator DelayedAction()
            {
                isClickEventRunning = true;
                yield return new WaitForSeconds(3f);
                fadeObject.GetComponent<Fade>().FadeClear();
                screenObject.SetActive(true);
                video.enabled = true;
                video.clip = videoClip;
                video.Play();
                video.loopPointReached += OnVideoEnd;
                isClickEventRunning = false;
                played = false;
            }
            //OnVideoEnd(video);
        }
        else if (eventExit)
        {
            EventExit();
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        played = false;
        if (vp == video)
        {
            Debug.Log("OnVideoEnd 함수 실행");
            if (check1 == true)
            {
                Debug.Log(check1);
                Debug.Log("check1 걸림");
                return;
            }
            Debug.Log("OnVideoEnd if문 통과");
            fadeObject.GetComponent<Fade>().FadeIn();
            screenObject.SetActive(false);
            video.enabled = false;
            phoneObject.GetComponent<Phone>().clickPhone2 = true;
            StartCoroutine(DelayedAction());

            IEnumerator DelayedAction()
            {
                if (check1 == true)
                {
                    yield break; // 코루틴 종료
                }
                yield return new WaitForSeconds(12f);
                if (check1 == true)
                {
                    yield break; // 코루틴 종료
                }
                audio.Play();
                yield return new WaitForSeconds(2f);
                if (check1 == true)
                {
                    yield break; // 코루틴 종료
                }
                audio.Play();
                yield return new WaitForSeconds(3f);
                if (check1 == true)
                {
                    yield break; // 코루틴 종료
                }
                audio.clip = AudioClip;
                audio.Play();
                played = false;
            }
        }
    }

    private void OnVideoEnd2(VideoPlayer vp)
    {
        if (vp == video)
        {
            fadeObject.GetComponent<Fade>().FadeOut();
            video.clip = videoClip2;
            StartCoroutine(DelayedAction2());
            IEnumerator DelayedAction2()
            {
                yield return new WaitForSeconds(3f);
                video.Play();
            }
        }
    }

    public void PlayDoorAudio(AudioClip ac)
    {
        Debug.Log("작동");
        audio.clip = ac;
        audio.Play();
    }

    public void EventExit()
    {
        fadeObject.GetComponent<Fade>().FadeOut();
        StartCoroutine(DelayedAction3());
        IEnumerator DelayedAction3()
        {
            yield return new WaitForSeconds(3f);
            fadeObject.GetComponent<Fade>().FadeClear();
            screenObject.SetActive(true);
            video.enabled = true;
            video.Play();
            video.loopPointReached -= OnVideoEnd;
            video.loopPointReached += OnVideoEnd2;
        }
    }
}
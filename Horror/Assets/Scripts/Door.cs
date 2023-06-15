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
            // Ŭ�� �̺�Ʈ�� �̹� ���� ���� ���, �߰� Ŭ���� �����մϴ�.
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
            Debug.Log("OnVideoEnd �Լ� ����");
            if (check1 == true)
            {
                Debug.Log(check1);
                Debug.Log("check1 �ɸ�");
                return;
            }
            Debug.Log("OnVideoEnd if�� ���");
            fadeObject.GetComponent<Fade>().FadeIn();
            screenObject.SetActive(false);
            video.enabled = false;
            phoneObject.GetComponent<Phone>().clickPhone2 = true;
            StartCoroutine(DelayedAction());

            IEnumerator DelayedAction()
            {
                if (check1 == true)
                {
                    yield break; // �ڷ�ƾ ����
                }
                yield return new WaitForSeconds(12f);
                if (check1 == true)
                {
                    yield break; // �ڷ�ƾ ����
                }
                audio.Play();
                yield return new WaitForSeconds(2f);
                if (check1 == true)
                {
                    yield break; // �ڷ�ƾ ����
                }
                audio.Play();
                yield return new WaitForSeconds(3f);
                if (check1 == true)
                {
                    yield break; // �ڷ�ƾ ����
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
        Debug.Log("�۵�");
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
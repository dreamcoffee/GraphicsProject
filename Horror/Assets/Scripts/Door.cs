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
    public VideoPlayer video;
    public AudioClip AudioClip;
    public VideoClip videoClip;
    public AudioSource audio;
    public bool played = false;

    void Start()
    {

    }

    void Click()
    {
        Debug.Log(played);
        if (played)
        {
            played = false;
            fadeObject.GetComponent<Fade>().FadeOut();
            StartCoroutine(DelayedAction());
            IEnumerator DelayedAction()
            {
                yield return new WaitForSeconds(3f);
                fadeObject.GetComponent<Fade>().FadeClear();
                screenObject.SetActive(true);
                video.enabled = true;
                video.clip = videoClip;
                video.Play();
                video.loopPointReached += OnVideoEnd;
            }
            //OnVideoEnd(video);
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        if (vp == video)
        {
            fadeObject.GetComponent<Fade>().FadeIn();
            screenObject.SetActive(false);
            video.enabled = false;
            StartCoroutine(DelayedAction());

            IEnumerator DelayedAction()
            {
                yield return new WaitForSeconds(12f);
                audio.Play();
                yield return new WaitForSeconds(2f);
                audio.Play();
                yield return new WaitForSeconds(3f);
                audio.clip = AudioClip;
                audio.Play();
            }
        }
    }

    public void PlayDoorAudio(AudioClip ac)
    {
        Debug.Log("¿€µø");
        audio.clip = ac;
        audio.Play();
    }
}
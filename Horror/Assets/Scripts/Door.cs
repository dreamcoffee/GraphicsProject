using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
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
            video.clip = videoClip;
            screenObject.SetActive(true);
            video.enabled = true;
            video.Play();
            video.loopPointReached += OnVideoEnd;
            //OnVideoEnd(video);
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        if (vp == video)
        {
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
}
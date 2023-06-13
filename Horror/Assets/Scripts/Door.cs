using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Door : MonoBehaviour
{
    public GameObject screenObject;
    public VideoPlayer video;
    public bool played = false;

    void Start()
    {

    }

    void Click()
    {
        Debug.Log("클릭 실행");
        Debug.Log(played);
        if (played)
        {
            screenObject.SetActive(true);
            video.enabled = true;
            video.Play();
            video.loopPointReached += OnVideoEnd;
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        if (vp == video)
        {
            screenObject.SetActive(false);
            video.enabled = false;
        }
    }
}
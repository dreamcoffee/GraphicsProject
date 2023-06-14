using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIScreen : MonoBehaviour
{
    public VideoClip monologueClip;
    public VideoClip playerDeadClip;
    public VideoClip policeClip;
    public GameObject screenObject;
    public GameObject fadeObject;
    public VideoPlayer video;

    void Start()
    {

    }

    public void Event1()
    {
        StartCoroutine(Event1Play());
    }

    private IEnumerator Event1Play()
    {
        Debug.Log("Å×½ºÆ®");
        yield return new WaitForSeconds(3f);
        fadeObject.GetComponent<Fade>().FadeOut();
        yield return new WaitForSeconds(2f);
        video.enabled = true;
        video.clip = monologueClip;
        video.Play();
        fadeObject.GetComponent<Fade>().FadeClear();
        video.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        fadeObject.GetComponent<Fade>().FadeIn();
        video.enabled = false;
    }
}
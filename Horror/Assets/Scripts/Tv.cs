using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class Tv : MonoBehaviour
{
    public GameObject screenObject;
    public AudioSource audioSource;
    public VideoPlayer video;
    public Light tvLight;
    public float maxVolume = 0.5f;
    public float volumeIncreaseRate = 0.0001f;
    public float videoPlayTime;
    public GameObject phoneObject;
    private bool tvLightOn = true;
    public bool tvClick = false;

    private void Start()
    {
        StartCoroutine(IncreaseVolumeOverTime());
        Invoke("PlayVideo", videoPlayTime);
    }

    public void Click()
    {
        if (tvClick)
        {
            if (tvLightOn) {
                TvOff();
            }
            else
            {
                TvOn();
            }
        }
    }

    private void PlayVideo()
    {
        video.Play();
        video.loopPointReached += OnVideoEnd;
    }

    private IEnumerator IncreaseVolumeOverTime()
    {
        yield return new WaitForSeconds(3f);
        while (audioSource.volume < maxVolume)
        {
            audioSource.volume += volumeIncreaseRate * Time.deltaTime;
            yield return null;
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        if (vp == video)
        {
            video.enabled = false;
            audioSource.Stop();

            Invoke("OnPhone", 10f);
        }
    }

    private void OnPhone()
    {
        phoneObject.GetComponent<Phone>().clickPhone = true;
        phoneObject.GetComponent<Phone>().Event1();
    }

    public void TvOn()
    {
        tvLightOn = true;
        tvLight.enabled = true;
    }

    public void TvOff()
    {
        tvLight.enabled = false;
        tvLightOn = false;
    }
}
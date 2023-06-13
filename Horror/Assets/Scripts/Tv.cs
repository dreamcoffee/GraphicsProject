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
    public float maxVolume = 0.5f;
    public float volumeIncreaseRate = 0.01f;
    public float videoPlayTime;

    private void Start()
    {
        StartCoroutine(IncreaseVolumeOverTime());
        Invoke("PlayVideo", videoPlayTime);
    }

    private void PlayVideo()
    {
        video.Play();
        video.loopPointReached += OnVideoEnd;
    }

    private IEnumerator IncreaseVolumeOverTime()
    {
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
        }
    }
}
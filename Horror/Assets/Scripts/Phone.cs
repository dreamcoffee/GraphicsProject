using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public bool clickPhone = false;
    public GameObject doorObject;
    public GameObject screenObject;
    public AudioSource audioSource;
    public VideoPlayer video;
    public Color onColor = Color.white;
    public Color offColor = Color.black;
    private Renderer renderer;
    private Material material;


    private void Start()
    {
    }

    private void Click()
    {
        if (clickPhone)
        {
            screenObject.SetActive(true);
            video.enabled = true;
            video.Play();
            audioSource.Stop();
            video.loopPointReached += DoorOn;
        }
    }

    public void ScreenOn()
    {
        renderer = this.GetComponent<Renderer>(); // 대상 오브젝트의 Renderer 컴포넌트 가져오기
        material = renderer.material; // 메테리얼 가져오기
        material.SetColor("_EmissionColor", onColor * 1);
        audioSource.Play();
    }

    public void DoorOn(VideoPlayer vp)
    {
        if (vp == video)
        {
            material.SetColor("_EmissionColor", onColor * 0);
            video.enabled = false;
            screenObject.SetActive(false);
            doorObject.GetComponent<Door>().played = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public GameObject gun;
    public GameObject doorObject;
    public VideoClip endClip;
    public VideoPlayer video;

    void Start()
    {
        
    }
    
    public void Click()
    {
        Debug.Log("½ÇÇà");
        gun.SetActive(false);
        video.clip = endClip;
        doorObject.GetComponent<Door>().check1 = true;
        doorObject.GetComponent<Door>().played = false;
        doorObject.GetComponent<Door>().eventExit = true;
    }
}
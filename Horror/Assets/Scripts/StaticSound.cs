using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StaticSound : MonoBehaviour
{
    public AudioClip horrorSound1;
    public AudioClip whisperSound;
    public AudioSource audio;

    void Start()
    {
        
    }

    public void Event1()
    {
        StartCoroutine(Event1Play());
    }
    public System.Collections.IEnumerator Event1Play() // 첫번째 이벤트 불 꺼지고 놀라는 소리 송출 그리고 귀신 위스퍼링 재생
    {
        Debug.Log("스테틱 사운드 소리 출력");
        audio.clip = horrorSound1;
        audio.Play();
        while (audio.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        audio.clip = whisperSound;
        audio.volume = 0.5f;
        audio.Play();
    }

    public void Play(AudioClip ac)
    {
        audio.clip = ac;
        audio.Play();
    }

    public void Stop()
    {
        audio.Stop();
    }
}

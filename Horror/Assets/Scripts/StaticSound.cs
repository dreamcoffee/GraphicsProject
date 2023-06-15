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
    public System.Collections.IEnumerator Event1Play() // ù��° �̺�Ʈ �� ������ ���� �Ҹ� ���� �׸��� �ͽ� �����۸� ���
    {
        Debug.Log("����ƽ ���� �Ҹ� ���");
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

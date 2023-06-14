using UnityEngine;
using UnityEngine.Audio;

public class LightToggleButton : MonoBehaviour
{
    public Light targetLight;
    public GameObject targetObject;
    public AudioSource staticSound;
    public AudioSource switchSound;
    public Color onColor = Color.white; 
    public Color offColor = Color.black;
    private bool isLightOn = false;
    public bool event1 = false; // 911 통화 후 발생 이벤트
    private Material material;
    private Renderer renderer;


    private void Start()
    {
        renderer = targetObject.GetComponent<Renderer>(); // 대상 오브젝트의 Renderer 컴포넌트 가져오기
        material = renderer.material; // 메테리얼 가져오기
    }

    private void Click()
    {
        Debug.Log(material);
        Debug.Log("click 함수 실행");

        // 조명 상태에 따라 토글합니다.
        if (!isLightOn)
        {
            LightOn();
            if(event1 == true)
            {
                staticSound.Stop();
            }
        }
        else
        {
            LightOff();
        }
    }

    public void LightOn()
    {
        switchSound.Play();
        targetLight.enabled = true;
        isLightOn = true;
        material.SetColor("_EmissionColor", onColor * 1);
    }

    public void LightOff()
    {
        switchSound.Play();
        targetLight.enabled = false;
        isLightOn = false;
        material.SetColor("_EmissionColor", offColor * 0);
    }
}
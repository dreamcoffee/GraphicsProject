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
    public bool event1 = false; // 911 ��ȭ �� �߻� �̺�Ʈ
    private Material material;
    private Renderer renderer;


    private void Start()
    {
        renderer = targetObject.GetComponent<Renderer>(); // ��� ������Ʈ�� Renderer ������Ʈ ��������
        material = renderer.material; // ���׸��� ��������
    }

    private void Click()
    {
        Debug.Log(material);
        Debug.Log("click �Լ� ����");

        // ���� ���¿� ���� ����մϴ�.
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
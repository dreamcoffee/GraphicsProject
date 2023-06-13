using UnityEngine;

public class LightToggleButton : MonoBehaviour
{
    public Light targetLight;
    public GameObject targetObject;
    public Color onColor = Color.white; 
    public Color offColor = Color.black;
    private bool isLightOn = false;

    private void Start()
    {
    }

    private void Click()
    {
        Renderer renderer = targetObject.GetComponent<Renderer>(); // ��� ������Ʈ�� Renderer ������Ʈ ��������
        Material material = renderer.material; // ���׸��� ��������
        Debug.Log(material);
        Debug.Log("click �Լ� ����");
        isLightOn = !isLightOn;

        // ���� ���¿� ���� ����մϴ�.
        if (isLightOn)
        {
            targetLight.enabled = true;
            material.SetColor("_EmissionColor", onColor*1);
        }
        else
        {
            targetLight.enabled = false;
            material.SetColor("_EmissionColor", offColor*0);
        }
    }
}
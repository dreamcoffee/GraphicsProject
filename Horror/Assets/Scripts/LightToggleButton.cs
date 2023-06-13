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
        Renderer renderer = targetObject.GetComponent<Renderer>(); // 대상 오브젝트의 Renderer 컴포넌트 가져오기
        Material material = renderer.material; // 메테리얼 가져오기
        Debug.Log(material);
        Debug.Log("click 함수 실행");
        isLightOn = !isLightOn;

        // 조명 상태에 따라 토글합니다.
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
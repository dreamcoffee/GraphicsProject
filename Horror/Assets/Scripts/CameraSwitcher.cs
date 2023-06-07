using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;  // 메인 카메라
    public Camera subCamera;   // 서브 카메라
    public float delay = 4f; // 게임 시작 후 대기 시간

    public Vector3 subCameraRotation;  // 서브 카메라의 원하는 각도

    private bool isSwitched = false;   // 카메라 전환 여부

    private void Start()
    {
        subCameraRotation = new Vector3(0, 90, 0);
        // 게임 시작 시 서브 카메라로 전환
        Invoke("SwitchToSubCamera", delay);
    }

    private void SwitchToSubCamera()
    {
        // 서브 카메라 활성화, 메인 카메라 비활성화
        subCamera.enabled = true;
        mainCamera.enabled = false;

        // 3초 동안 서브 카메라의 각도 변경 후 메인 카메라로 전환
        StartCoroutine(ChangeSubCameraAngle());
    }

    private System.Collections.IEnumerator ChangeSubCameraAngle()
    {
        Quaternion startRotation = subCamera.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(subCameraRotation);

        float elapsedTime = 0f;
        float duration = 3f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            subCamera.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }

        // 각도 변경이 완료되면 메인 카메라로 전환
        SwitchToMainCamera();
    }

    private void SwitchToMainCamera()
    {
        // 메인 카메라 활성화, 서브 카메라 비활성화
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }
}
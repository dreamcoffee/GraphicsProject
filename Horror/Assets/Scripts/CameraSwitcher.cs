using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;  // ���� ī�޶�
    public Camera subCamera;   // ���� ī�޶�
    public float delay = 4f; // ���� ���� �� ��� �ð�

    public Vector3 subCameraRotation;  // ���� ī�޶��� ���ϴ� ����

    private bool isSwitched = false;   // ī�޶� ��ȯ ����

    private void Start()
    {
        subCameraRotation = new Vector3(0, 90, 0);
        // ���� ���� �� ���� ī�޶�� ��ȯ
        Invoke("SwitchToSubCamera", delay);
    }

    private void SwitchToSubCamera()
    {
        // ���� ī�޶� Ȱ��ȭ, ���� ī�޶� ��Ȱ��ȭ
        subCamera.enabled = true;
        mainCamera.enabled = false;

        // 3�� ���� ���� ī�޶��� ���� ���� �� ���� ī�޶�� ��ȯ
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

        // ���� ������ �Ϸ�Ǹ� ���� ī�޶�� ��ȯ
        SwitchToMainCamera();
    }

    private void SwitchToMainCamera()
    {
        // ���� ī�޶� Ȱ��ȭ, ���� ī�޶� ��Ȱ��ȭ
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float sensitivity = 500f;
    public float rotationX;
    public float rotationY;
    public float distance = 0.1f;

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // 마우스 이동값을 받아서 rotationX, rotationY 업데이트
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveY * sensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -60f, 60f); // 회전 각도 제한

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

            if (Physics.Raycast(ray, out RaycastHit hit, distance))
            {
                GameObject targetObject = hit.collider.gameObject;
                MonoBehaviour script = targetObject.GetComponent<MonoBehaviour>();

                Debug.Log(targetObject);

                if (script != null)
                {
                    // 스크립트에 "click" 함수가 있는지 확인 후 실행
                    System.Reflection.MethodInfo clickMethod = script.GetType().GetMethod("click", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.IgnoreCase);
                    if (clickMethod != null)
                    {
                        clickMethod.Invoke(script, null);
                    }
                }
            }
        }
    }
}
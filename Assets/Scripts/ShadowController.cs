using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowArmController : MonoBehaviour
{
    public Transform playerCenter; // 중심은 Body
    public float rotationSpeed = 15f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 dir = (mousePos - playerCenter.position).normalized;

        // 회전 각도 계산
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // 부드럽게 회전
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
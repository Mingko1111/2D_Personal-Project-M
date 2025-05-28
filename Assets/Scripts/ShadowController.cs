using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowArmController : MonoBehaviour
{
    public Transform playerCenter; // �߽��� Body
    public float rotationSpeed = 15f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 dir = (mousePos - playerCenter.position).normalized;

        // ȸ�� ���� ���
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // �ε巴�� ȸ��
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
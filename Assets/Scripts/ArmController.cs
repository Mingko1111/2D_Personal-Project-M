using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public Transform targetCenter; // ĳ���� �߽� (���� ��ġ, ���� ����)
    public float rotationSpeed = 10f; // �ε巯�� ȸ��

    void Update()
    {
        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // �߽ɿ��� ���콺�� ���ϴ� ����
        Vector3 direction = (mousePos - targetCenter.position).normalized;

        // ���� ���
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // �ε巴�� ȸ�� ����
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
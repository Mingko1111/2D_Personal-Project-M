using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ���� ��� (�÷��̾�)
    public Vector3 offset = new Vector3(0, 0, -10f); // �⺻ ī�޶� �Ÿ�
    public float smoothSpeed = 5f; // ���󰡴� �ε巯�� ����

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothed;
    }
}
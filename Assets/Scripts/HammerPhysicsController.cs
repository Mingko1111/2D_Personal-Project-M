using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPhysicsController : MonoBehaviour
{
    private Rigidbody2D rb;
    private FixedJoint2D joint;

    public Transform playerBody; // �÷��̾� ��ü Rigidbody �ִ� ��
    public float forceMultiplier = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ�� ����
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            rb.position = mouseWorldPos;

            joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = playerBody.GetComponent<Rigidbody2D>();
            joint.enableCollision = true;
        }

        if (Input.GetMouseButton(0))
        {
            // ���� ���� ���� �� ���� ������ X (Physics�� ó��)
        }

        if (Input.GetMouseButtonUp(0)) // Ŭ�� ����
        {
            if (joint != null)
            {
                Destroy(joint);
            }
        }
    }
}
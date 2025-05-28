using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPhysicsController : MonoBehaviour
{
    private Rigidbody2D rb;
    private FixedJoint2D joint;

    public Transform playerBody; // 플레이어 본체 Rigidbody 있는 곳
    public float forceMultiplier = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 시작
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
            // 고정 중인 상태 → 별도 움직임 X (Physics가 처리)
        }

        if (Input.GetMouseButtonUp(0)) // 클릭 해제
        {
            if (joint != null)
            {
                Destroy(joint);
            }
        }
    }
}
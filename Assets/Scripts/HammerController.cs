using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public Rigidbody2D playerRb;              // 플레이어 Rigidbody2D
    public Transform mouseTarget;             // 마우스 위치를 따라가는 타겟 오브젝트
    public Transform playerTransform;         // 플레이어 위치 기준 Transform

    public float moveForce = 30f;             // 마우스 방향으로 힘
    public float torquePower = 5f;            // 회전력
    public float reboundForce = 5f;           // 충돌 시 반작용 힘
    public float maxRadius = 3.5f;            // 플레이어를 기준으로 허용된 최대 반경

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 0f) return; // 퍼즈 시 움직임 정지

        if (mouseTarget == null || playerTransform == null) return;

        // 1. 해머의 자연스러운 움직임 (마우스를 향한 힘, 회전)
        Vector2 toTarget = (Vector2)mouseTarget.position - rb.position;
        if (toTarget.magnitude < 0.1f) return;

        Vector2 dir = toTarget.normalized;
        rb.AddForce(dir * moveForce);

        float angle = Vector2.SignedAngle(transform.right, dir);
        rb.AddTorque(angle * torquePower);

        // 2. 해머의 위치 제한 (플레이어 기준 maxRadius 이내 유지)
        Vector2 fromPlayer = rb.position - (Vector2)playerTransform.position;
        float distance = fromPlayer.magnitude;

        if (distance > maxRadius)
        {
            Vector2 pullBack = -fromPlayer.normalized;
            float excess = distance - maxRadius;
            rb.AddForce(pullBack * excess * moveForce * 2f); // 힘으로 제한
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 3. 반작용 힘의 적용 (해머가 장애물에 닿았을 때만 반작용 발생)
        if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Ground"))
        {
            float speed = rb.velocity.magnitude;
            Vector2 contactPoint = collision.GetContact(0).point;
            float distToPlayer = Vector2.Distance(contactPoint, playerTransform.position);

            if (speed > 1f && distToPlayer <= maxRadius)
            {
                Vector2 reactionDir = (playerTransform.position - (Vector3)contactPoint).normalized;
                Vector2 reaction = reactionDir * reboundForce;

                playerRb.AddForce(reaction, ForceMode2D.Impulse);
            }
        }
    }

    // 디버깅용 범위 시각화
    void OnDrawGizmosSelected()
    {
        if (playerTransform != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(playerTransform.position, maxRadius);
        }
    }
}
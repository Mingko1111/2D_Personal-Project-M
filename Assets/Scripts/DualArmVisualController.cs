using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualArmVisualController : MonoBehaviour
{
    [Header("Left Arm")]
    public Transform leftShoulder;
    public Transform leftHand;
    public Transform leftArmVisual;  // SpriteRenderer가 붙은 오브젝트

    [Header("Right Arm")]
    public Transform rightShoulder;
    public Transform rightHand;
    public Transform rightArmVisual; // SpriteRenderer가 붙은 오브젝트

    public float armThickness = 0.2f; // 팔의 두께

    void Update()
    {
        UpdateArm(leftShoulder, leftHand, leftArmVisual);
        UpdateArm(rightShoulder, rightHand, rightArmVisual);
    }

    void UpdateArm(Transform shoulder, Transform hand, Transform arm)
    {
        if (shoulder == null || hand == null || arm == null) return;

        Vector3 dir = hand.position - shoulder.position;
        float length = dir.magnitude;

        arm.position = (shoulder.position + hand.position) / 2f;
        arm.right = dir.normalized;
        arm.localScale = new Vector3(length, armThickness, 1);
    }
}
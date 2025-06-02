using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameClearUI clearUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�浹�߻�");

        if (other.CompareTag("Player"))
        {
            clearUI.ShowClearUI();
        }
    }
}

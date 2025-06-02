using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameClearUI clearUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌발생");

        if (other.CompareTag("Player"))
        {
            clearUI.ShowClearUI();
        }
    }
}

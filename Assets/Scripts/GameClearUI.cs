using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameClearUI : MonoBehaviour
{
    public GameObject clearPanel;
    public Button retryButton;
    public Button mainMenuButton;

    private void Start()
    {
        clearPanel.SetActive(false);

        retryButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    public void ShowClearUI()
    {
        clearPanel.SetActive(true);         // 먼저 UI 띄우기
        StartCoroutine(DelayPause());       // 시간 정지는 한 프레임 뒤로 미루기
    }

    private IEnumerator DelayPause()
    {
        yield return null;                  // 한 프레임 기다림
        Time.timeScale = 0f;                // 게임 정지
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
}
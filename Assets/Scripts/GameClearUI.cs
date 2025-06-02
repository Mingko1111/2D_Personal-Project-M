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
        clearPanel.SetActive(true);         // ���� UI ����
        StartCoroutine(DelayPause());       // �ð� ������ �� ������ �ڷ� �̷��
    }

    private IEnumerator DelayPause()
    {
        yield return null;                  // �� ������ ��ٸ�
        Time.timeScale = 0f;                // ���� ����
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
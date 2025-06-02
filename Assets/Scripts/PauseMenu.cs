using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public Button resumeButton;
    public Button retryButton;
    public Button settingsButton;
    public Button mainMenuButton;
    public GameObject settingsPanel;
    public GameObject hammerObject;

    public bool isInMainMenu = false;

    private HammerController hammerController;
    private bool isPaused = false;

    private RigidbodyConstraints2D savedConstraints; // 🔒 초기 constraints 저장용

    void Start()
    {
        pausePanel.SetActive(false);
        hammerController = hammerObject.GetComponent<HammerController>();

        // 🔒 인스펙터에서 설정한 constraints 값 저장
        if (hammerController.playerRb != null)
        {
            savedConstraints = hammerController.playerRb.constraints;
        }

        resumeButton.onClick.AddListener(ResumeGame);
        retryButton.onClick.AddListener(RestartGame);
        settingsButton.onClick.AddListener(OpenSettings);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void Update()
    {
        if (isInMainMenu)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        hammerController.enabled = false;

        Rigidbody2D hammerRb = hammerObject.GetComponent<Rigidbody2D>();
        hammerRb.velocity = Vector2.zero;
        hammerRb.angularVelocity = 0f;
        hammerRb.simulated = false;

        if (hammerController.playerRb != null)
        {
            hammerController.playerRb.velocity = Vector2.zero;
            hammerController.playerRb.angularVelocity = 0f;
            hammerController.playerRb.simulated = false;
            hammerController.playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Rigidbody2D hammerRb = hammerObject.GetComponent<Rigidbody2D>();
        hammerRb.simulated = true;

        if (hammerController.playerRb != null)
        {
            hammerController.playerRb.simulated = true;
            hammerController.playerRb.constraints = savedConstraints; // 🔁 초기값 복원
        }

        hammerController.enabled = true;
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void OpenSettings()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
        SettingsMenu.openedFrom = "PauseMenu";
    }
}

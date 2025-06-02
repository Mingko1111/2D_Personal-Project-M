using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject hammerObject;
    public PauseMenu pauseMenu; // PauseMenu에 접근

    public Button startButton;
    public Button settingsButton;
    public Button quitButton;

    private HammerController hammerController;

    void Start()
    {
        hammerController = hammerObject.GetComponent<HammerController>();

        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);

        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        hammerController.enabled = false;

        if (pauseMenu != null)
            pauseMenu.isInMainMenu = true; // 처음엔 메인메뉴 상태
    }

    void Update()
    {
        if (mainMenuPanel.activeSelf || settingsPanel.activeSelf)
        {
            hammerController.enabled = false;
        }
        else
        {
            hammerController.enabled = true;
        }
    }

    void StartGame()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        hammerController.enabled = true;

        if (pauseMenu != null)
            pauseMenu.isInMainMenu = false; // 게임 시작 → 메인메뉴 상태 아님
    }

    void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        SettingsMenu.openedFrom = "MainMenu";
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
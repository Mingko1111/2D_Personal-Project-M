using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip mainMenuBGM;
    public AudioClip gameBGM;

    private GameObject mainMenuPanel; // 런타임에 동적으로 찾아 연결
    private AudioClip currentClip;

    private static BGMManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 로드될 때마다 메인메뉴 패널을 찾아서 다시 연결
        mainMenuPanel = GameObject.Find("MainMenuPanel"); // 정확한 이름 필요

        // 씬 시작할 때 바로 상태 감지
        CheckPanelAndPlayBGM();
    }

    private void Update()
    {
        CheckPanelAndPlayBGM();
    }

    private void CheckPanelAndPlayBGM()
    {
        if (mainMenuPanel == null) return;

        if (mainMenuPanel.activeInHierarchy)
        {
            if (currentClip != mainMenuBGM)
                PlayBGM(mainMenuBGM);
        }
        else
        {
            if (currentClip != gameBGM)
                PlayBGM(gameBGM);
        }
    }

    private void PlayBGM(AudioClip clip)
    {
        audioSource.clip = clip;
        currentClip = clip;
        audioSource.Play();
    }
}
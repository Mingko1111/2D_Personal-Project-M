using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip mainMenuBGM;
    public AudioClip gameBGM;

    private GameObject mainMenuPanel; // ��Ÿ�ӿ� �������� ã�� ����
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
        // ���� �ε�� ������ ���θ޴� �г��� ã�Ƽ� �ٽ� ����
        mainMenuPanel = GameObject.Find("MainMenuPanel"); // ��Ȯ�� �̸� �ʿ�

        // �� ������ �� �ٷ� ���� ����
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
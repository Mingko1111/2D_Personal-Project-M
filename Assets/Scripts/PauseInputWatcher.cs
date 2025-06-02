using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInputWatcher : MonoBehaviour
{
    public GameObject pauseManagerObject; // PauseMenu가 붙어있는 오브젝트
    public GameObject mainMenuPanel;      // 메인 메뉴 패널 오브젝트

    private PauseMenu pauseMenu;

    void Start()
    {
        pauseMenu = pauseManagerObject.GetComponent<PauseMenu>();
    }

    void Update()
    {
        // 메인메뉴 켜져 있으면 ESC 입력 무시
        if (mainMenuPanel != null && mainMenuPanel.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseManagerObject.activeSelf)
            {
                pauseManagerObject.SetActive(true);
                pauseMenu.PauseGame(); //  반드시 호출해야 실제 Pause 처리됨
            }
        }
    }
}
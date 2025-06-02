using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInputWatcher : MonoBehaviour
{
    public GameObject pauseManagerObject; // PauseMenu�� �پ��ִ� ������Ʈ
    public GameObject mainMenuPanel;      // ���� �޴� �г� ������Ʈ

    private PauseMenu pauseMenu;

    void Start()
    {
        pauseMenu = pauseManagerObject.GetComponent<PauseMenu>();
    }

    void Update()
    {
        // ���θ޴� ���� ������ ESC �Է� ����
        if (mainMenuPanel != null && mainMenuPanel.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseManagerObject.activeSelf)
            {
                pauseManagerObject.SetActive(true);
                pauseMenu.PauseGame(); //  �ݵ�� ȣ���ؾ� ���� Pause ó����
            }
        }
    }
}
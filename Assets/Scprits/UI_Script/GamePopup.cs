using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePopup : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI; // ��ͣ�˵���UI
    public GameObject deadMenuUI; // �����˵���UI
    public GameObject levelEndMenuUI; // �صײ˵���UI
    public GameObject gameVictoryMenuUI; // ��Ϸͨ�ص�UI

    void Update()
    {
        // ��Esc����ͣ������ͣʱ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(); // �л���ͣ״̬
        }
    }

    /// <summary>
    /// ��ͣ����
    /// </summary>
    public void TogglePause()// �л���ͣ״̬
    {
        if (isGamePaused)
        {
            ResumeGame(); // �����Ϸ����ͣ����رյ���������Ϸ
        }
        else
        {
            PauseGame(); // �����Ϸδ��ͣ������ͣ��Ϸ�򿪵���
        }
    }

    public void PauseGame()
    {
        Debug.Log("ֹͣ��Ϸʱ��");
        Time.timeScale = 0; // ֹͣ��Ϸʱ��
        isGamePaused = true; // ������ϷΪ��ͣ״̬
        pauseMenuUI.SetActive(true); // ��ʾ��ͣ�˵�
    }
    public void ResumeGame()
    {
        Debug.Log("�ָ���Ϸʱ��");
        if (pauseMenuUI.activeSelf == true)
        {
            Time.timeScale = 1; // �ָ���Ϸʱ��
            isGamePaused = false; // ������ϷΪ����ͣ״̬
            pauseMenuUI.SetActive(false); // ������ͣ�˵�
        }

    }

    /// <summary>
    /// ��������
    /// </summary>

    public void OpenDeadMenuUI()//����ʱ���ã��������Ե���
    {
        Time.timeScale = 0; // ֹͣ��Ϸʱ��
        isGamePaused = true; // ������ϷΪ��ͣ״̬
        deadMenuUI.SetActive(true); // ��ʾ���Ե���
    }

    public void RetryButton()//����ʱ������������
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }


    /// <summary>
    /// ��һ�ص���
    /// </summary>
    /// 

    public void OpenLevelEndMenuUI()//����ص�����ʱ�������ã�������һ��ȷ�ϵ���
    {
        Time.timeScale = 0; // ֹͣ��Ϸʱ��
        isGamePaused = true; // ������ϷΪ��ͣ״̬
        levelEndMenuUI.SetActive(true); // ��ʾ��һ�ص���
    }

    public void NextLevelButton()//�ص�ʱ����������һ��
    {
        if (SceneManager.GetActiveScene().name == "level 1")
        {
            SceneManager.LoadScene("level 2");
        }
        else if (SceneManager.GetActiveScene().name == "level 2")
        {
            SceneManager.LoadScene("level 3");
        }
        else if (SceneManager.GetActiveScene().name == "level 3")
        {
            SceneManager.LoadScene("level 4");
        }

    }

    /// <summary>
    /// ��һ�ص���
    /// </summary>
    /// 

    public void OpenGameVictoryMenuUI()//���һ��ͨ��ʱ���ã�������Ϸ��β����
    {
        gameVictoryMenuUI.SetActive(true); // ��ʾ��һ�ص���
    }

    public void BackMainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePopup : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI; // 暂停菜单的UI
    public GameObject deadMenuUI; // 死亡菜单的UI
    public GameObject levelEndMenuUI; // 关底菜单的UI
    public GameObject gameVictoryMenuUI; // 游戏通关的UI

    void Update()
    {
        // 按Esc键暂停或在暂停时继续
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(); // 切换暂停状态
        }
    }

    /// <summary>
    /// 暂停弹窗
    /// </summary>
    public void TogglePause()// 切换暂停状态
    {
        if (isGamePaused)
        {
            ResumeGame(); // 如果游戏已暂停，则关闭弹窗继续游戏
        }
        else
        {
            PauseGame(); // 如果游戏未暂停，则暂停游戏打开弹窗
        }
    }

    public void PauseGame()
    {
        Debug.Log("停止游戏时间");
        Time.timeScale = 0; // 停止游戏时间
        isGamePaused = true; // 设置游戏为暂停状态
        pauseMenuUI.SetActive(true); // 显示暂停菜单
    }
    public void ResumeGame()
    {
        Debug.Log("恢复游戏时间");
        if (pauseMenuUI.activeSelf == true)
        {
            Time.timeScale = 1; // 恢复游戏时间
            isGamePaused = false; // 设置游戏为非暂停状态
            pauseMenuUI.SetActive(false); // 隐藏暂停菜单
        }

    }

    /// <summary>
    /// 死亡弹窗
    /// </summary>

    public void OpenDeadMenuUI()//死亡时调用，弹出重试弹窗
    {
        Time.timeScale = 0; // 停止游戏时间
        isGamePaused = true; // 设置游戏为暂停状态
        deadMenuUI.SetActive(true); // 显示重试弹窗
    }

    public void RetryButton()//死亡时弹窗里点击重试
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }


    /// <summary>
    /// 下一关弹窗
    /// </summary>
    /// 

    public void OpenLevelEndMenuUI()//到达关底区域时触发调用，弹出下一关确认弹窗
    {
        Time.timeScale = 0; // 停止游戏时间
        isGamePaused = true; // 设置游戏为暂停状态
        levelEndMenuUI.SetActive(true); // 显示下一关弹窗
    }

    public void NextLevelButton()//关底时弹窗里点击下一关
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
    /// 下一关弹窗
    /// </summary>
    /// 

    public void OpenGameVictoryMenuUI()//最后一关通关时调用，进入游戏结尾画面
    {
        gameVictoryMenuUI.SetActive(true); // 显示下一关弹窗
    }

    public void BackMainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}

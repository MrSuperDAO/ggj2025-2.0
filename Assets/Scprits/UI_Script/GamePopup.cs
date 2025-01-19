using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePopup : MonoBehaviour
{
    public static GamePopup Instance { get; private set; }

    public bool isGamePaused = false;
    public GameObject pauseMenuUI; // 暂停菜单的UI
    public GameObject deadMenuUI; // 死亡菜单的UI
    //public GameObject levelEndMenuUI; // 关底菜单的UI
    public GameObject gameVictoryMenuUI; // 游戏通关的UI

    void Update()
    {
        // 按Esc键暂停或在暂停时继续
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(); // 切换暂停状态
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
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
    /// 结算弹窗
    /// </summary>
    /// 

    public void OpenGameVictoryMenuUI()//最后一关通关时调用，进入游戏结尾画面
    {
        StartCoroutine(GameEnd());
    }

    public void BackMainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    [SerializeField] public Image transitionImage;
    [SerializeField] public float fadeTime ;
    public static Color color;

    public IEnumerator LoadCoroutine(string sceneName)
    {
        transitionImage.gameObject.SetActive(true);//开启黑屏过场图片
        while (color.a < 1f)//黑屏淡入
        {
            color.a = Mathf.Clamp01(color.a + Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;
            yield return null;
        }
        transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, 1f);
        SceneManager.LoadScene(sceneName);

        transitionImage.gameObject.SetActive(false);
        while (color.a > 0f)//如果加载完毕，黑屏淡出
        {
            Time.timeScale = 1f;
            color.a = Mathf.Clamp01(color.a - Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;
            Debug.Log(color.a);
            yield return null;
        }
        transitionImage.gameObject.SetActive(false);
    }

    public IEnumerator TransitionInCoroutine()
    {
        transitionImage.gameObject.SetActive(true);//开启黑屏过场图片
        while (color.a < 1f)//黑屏渐入
        {
            color.a = Mathf.Clamp01(color.a + Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;
            if (color.a <= 0.05f)
            {
                yield return null;
            }
        }
        setPlayerPosition();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartCoroutine(TransitionOutCoroutine());
       
        DataController.Instance.dides += 1; ; 
        //Destroy(this.gameObject);
        Debug.Log("死亡次数" + DataController.Instance.dides);
    }

    public IEnumerator TransitionOutCoroutine()
    {
        while (color.a > 0f)//如果加载完毕且完全黑屏，黑屏淡出
        {
            if (color.a <= 0.05f)
            {
            }

            Time.timeScale = 1f;
            color.a = Mathf.Clamp01(color.a - Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;
            yield return null;
        }
        transitionImage.gameObject.SetActive(false);//关闭黑屏过场图片
    }

    public GameObject Player;
    public RotateTowardsMouse rotateTowardsMouse = null;

    public void setPlayerPosition()
    {
        Player.transform.position = rotateTowardsMouse.lastSaveArea.transform.position;
    }

    [SerializeField] public Image whiteImage;
    Color whitecolor;
    public IEnumerator GameEnd()
    {
        whitecolor = whiteImage.color;
        whiteImage.gameObject.SetActive(true);//开启白屏过场图片
        rotateTowardsMouse.canmove = false;
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        
        while (whitecolor.a < 1f)//白屏渐入
        {
            Time.timeScale = 1f;
            whitecolor.a = Mathf.Clamp01(whitecolor.a + Time.unscaledDeltaTime / fadeTime);
            whiteImage.color = whitecolor;
            yield return null;
        }
        gameVictoryMenuUI.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePopup : MonoBehaviour
{
    public bool isGamePaused = false;
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

    void Awake()
    {
        DontDestroyOnLoad(this);
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
        //StartCoroutine(LoadCoroutine(SceneManager.GetActiveScene().name));
        //��������
        
        //deadMenuUI.SetActive(true); // ��ʾ���Ե���
    }

    public void RetryButton()//����ʱ������������
    {
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
            StartCoroutine(LoadCoroutine("level 2"));
        }
        else if (SceneManager.GetActiveScene().name == "level 2")
        {
            StartCoroutine(LoadCoroutine("level 3"));
        }
        else if (SceneManager.GetActiveScene().name == "level 3")
        {
            StartCoroutine(LoadCoroutine("level 4"));
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

    [SerializeField] public Image transitionImage;
    [SerializeField] public float fadeTime ;
    public static Color color;

    public IEnumerator LoadCoroutine(string sceneName)
    {
        transitionImage.gameObject.SetActive(true);//������������ͼƬ
        while (color.a < 1f)//��������
        {
            color.a = Mathf.Clamp01(color.a + Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;
            yield return null;
        }
        transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, 1f);
        SceneManager.LoadScene(sceneName);

        transitionImage.gameObject.SetActive(false);
        while (color.a > 0f)//���������ϣ���������
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
        transitionImage.gameObject.SetActive(true);//������������ͼƬ
        while (color.a < 1f)//��������
        {
            color.a = Mathf.Clamp01(color.a + Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;
            if (color.a <= 0.05f)
            {
                yield return null;
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartCoroutine(TransitionOutCoroutine());
    }

    public IEnumerator TransitionOutCoroutine()
    {
        while (color.a > 0f)//��������������ȫ��������������
        {
            if (color.a <= 0.05f)
            {
            }

            Time.timeScale = 1f;
            color.a = Mathf.Clamp01(color.a - Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;
            yield return null;
        }
        transitionImage.gameObject.SetActive(false);//�رպ�������ͼƬ
    }

    public GameObject saveArea;
    public GameObject Player;

    public void setPlayerPosition()
    {
        if(saveArea.name == "�浵��ȫ��0")
        {
        }
        else if (saveArea.name == "�浵��ȫ��1")
        {

        }
        else if (saveArea.name == "�浵��ȫ��2")
        {

        }
        else if (saveArea.name == "�浵��ȫ��3")
        {

        }
    }
}

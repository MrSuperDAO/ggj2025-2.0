using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneChange : MonoBehaviour
{
    public GameObject chooseLevelUI;
    public void OpenChooseLevelUI()
    {
        chooseLevelUI.SetActive(true);  
}

    public void CloseChooseLevelUI()
    {
        chooseLevelUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    [SerializeField] Image transitionImage;
    [SerializeField] public float fadeTime;
    public static Color color;

    public void LoadLvel1()
    {
        SceneManager.LoadScene("level 1");
       // StartCoroutine(TransitionOutCoroutine());
    }

    public IEnumerator TransitionOutCoroutine()
    {
        transitionImage.gameObject.SetActive(true);//�򿪺�������ͼƬ
        transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, 1f);
        SceneManager.LoadScene("level 1");
        
        while (color.a > 0f)//��������������ȫ��������������
        {
            if (color.a <= 0.05f)
            {
                yield return null;
                //���β���
                //PlayerControl1.cantInput = false;
            }

            Time.timeScale = 1f;
            color.a = Mathf.Clamp01(color.a - Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;
            yield return null;
        }
        
        transitionImage.gameObject.SetActive(false);//�رպ�������ͼƬ
        Destroy(this);
    }

}

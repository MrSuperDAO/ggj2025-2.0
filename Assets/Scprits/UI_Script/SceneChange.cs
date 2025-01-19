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
        transitionImage.gameObject.SetActive(true);//打开黑屏过场图片
        transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, 1f);
        SceneManager.LoadScene("level 1");
        
        while (color.a > 0f)//如果加载完毕且完全黑屏，黑屏淡出
        {
            if (color.a <= 0.05f)
            {
                yield return null;
                //屏蔽操作
                //PlayerControl1.cantInput = false;
            }

            Time.timeScale = 1f;
            color.a = Mathf.Clamp01(color.a - Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;
            yield return null;
        }
        
        transitionImage.gameObject.SetActive(false);//关闭黑屏过场图片
        Destroy(this);
    }

}

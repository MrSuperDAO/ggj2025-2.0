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
    public GameObject Image01;
    public GameObject Image02;
    public GameObject Image03;
    public GameObject Image04;

    public void showPic()
    {
        if(Image01.activeSelf == false && Image02.activeSelf == false && Image03.activeSelf == false && Image04.activeSelf == false)
        {
            StartCoroutine(loadPic(Image01));
        }
        else if(Image01.activeSelf == true && Image02.activeSelf == false && Image03.activeSelf == false && Image04.activeSelf == false)
        {
            StartCoroutine(loadPic(Image02));
        }
        else if (Image01.activeSelf == true && Image02.activeSelf == true && Image03.activeSelf == false && Image04.activeSelf == false)
        {
            StartCoroutine(loadPic(Image03));
        }
        else if (Image01.activeSelf == true && Image02.activeSelf == true && Image03.activeSelf == true && Image04.activeSelf == false)
        {
            StartCoroutine(loadPic(Image04));
        }
        else if (Image01.activeSelf == true && Image02.activeSelf == true && Image03.activeSelf == true && Image04.activeSelf == true)
        {
            StopAllCoroutines();
            LoadLvel1();
            
        }

        
    }
    

    public IEnumerator loadPic(GameObject pic)
    {
        pic.SetActive(true);
        Color piccolor = pic.GetComponent<Image>().color;
        while (piccolor.a < 1f)//��������������ȫ��������������
        {
            if (color.a >= 0.95f)
            {
                yield return null;
                //���β���
                //PlayerControl1.cantInput = false;
            }
            Time.timeScale = 1f;
            piccolor.a += Mathf.Clamp01(color.a + Time.unscaledDeltaTime / fadeTime);
            pic.GetComponent<Image>().color = piccolor;
            Debug.Log(piccolor.a);
            yield return null;
        }
    }

}

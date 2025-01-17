using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadLvel1()
    {
        SceneManager.LoadScene("level 1");
    }
}

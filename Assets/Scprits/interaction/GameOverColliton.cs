using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverColliton : MonoBehaviour
{
    public GameObject UI;
    // Start is called before the first frame update
    //public GameObject retryButton;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject scoreObject = GameObject.Find("ScoreManager");
        ScoreManager score = scoreObject.GetComponent<ScoreManager>();//获调用ScoreManager

        GameObject gamePopupObjiect = GameObject.Find("游戏界面UI");
        GamePopup gamePopup = gamePopupObjiect.GetComponent<GamePopup>();//获取 调用GamePopup
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(UI.GetComponent<GamePopup>().TransitionInCoroutine());
            score.DideAdd();
            //Debug.Log("失败重新再来");
            //gamePopup.PauseGame();
        }
        //retryButton.SetActive(true);

    }


}

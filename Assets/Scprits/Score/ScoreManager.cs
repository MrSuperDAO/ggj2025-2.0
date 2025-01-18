using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;  // 当前分数
    public Text scoreText;  // 用于显示分数的Text组件
    public Text timeText;//显示时间组件

    private void Start()
    {
      
    }

    // 更新分数
    private void Update()
    {
        UpdateScoreText();
    }

    // 更新UI中的分数显示
    private void UpdateScoreText()
    {
        Debug.Log(DataController.Instance.time);
        scoreText.text = "死亡数: " + DataController.Instance.dides;
        timeText.text = "时间: " + DataController.Instance.time;
    }
    public void DideAdd()
    {

        
        FindObjectOfType<ScoreManager>().UpdateScoreText();
    }
}


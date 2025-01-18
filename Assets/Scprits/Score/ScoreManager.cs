using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;  // 当前分数
    public Text scoreText;  // 用于显示分数的Text组件

    private void Start()
    {
        // 初始化分数
        score = 0;
        UpdateScoreText();
    }

    // 更新分数
    public static void AddScore(int points)
    {
        score += points;
        // 调用UpdateScoreText方法更新UI
        FindObjectOfType<ScoreManager>().UpdateScoreText();
    }

    // 更新UI中的分数显示
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}

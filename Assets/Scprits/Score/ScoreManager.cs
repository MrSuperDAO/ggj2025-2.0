using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;  // ��ǰ����
    public Text scoreText;  // ������ʾ������Text���

    private void Start()
    {
        // ��ʼ������
        score = 0;
        UpdateScoreText();
    }

    // ���·���
    public static void AddScore(int points)
    {
        score += points;
        // ����UpdateScoreText��������UI
        FindObjectOfType<ScoreManager>().UpdateScoreText();
    }

    // ����UI�еķ�����ʾ
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}

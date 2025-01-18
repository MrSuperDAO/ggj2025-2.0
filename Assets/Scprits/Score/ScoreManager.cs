using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    public Text scoreText;  // 用于显示死亡数的Text组件
    public Text timeText;// 用于显示时间的Text组件
   
    private void Awake()
    {
            
    }
    private void Start()
    {
        // 初始化分数
       
        
    }
    private void Update()
    {
        UpdateScoreText();
    }
    // 更新UI中的分数显示
    private void UpdateScoreText()
    {
        Debug.Log(DataController.Instance.time);
        scoreText.text = "死亡次数: " + DataController.Instance.dides;
        timeText.text = "时间: " + DataController.Instance.time;
    }
    // 更新死亡数
    public  void DideAdd()
    {
       
        // 调用UpdateScoreText方法更新UI
        FindObjectOfType<ScoreManager>().UpdateScoreText();
    }

}

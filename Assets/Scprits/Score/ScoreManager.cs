using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    public Text scoreText;  // ������ʾ��������Text���
    public Text timeText;// ������ʾʱ���Text���
   
    private void Awake()
    {
            
    }
    private void Start()
    {
        // ��ʼ������
       
        
    }
    private void Update()
    {
        UpdateScoreText();
    }
    // ����UI�еķ�����ʾ
    private void UpdateScoreText()
    {
        Debug.Log(DataController.Instance.time);
        scoreText.text = "��������: " + DataController.Instance.dides;
        timeText.text = "ʱ��: " + DataController.Instance.time;
    }
    // ����������
    public  void DideAdd()
    {
       
        // ����UpdateScoreText��������UI
        FindObjectOfType<ScoreManager>().UpdateScoreText();
    }

}

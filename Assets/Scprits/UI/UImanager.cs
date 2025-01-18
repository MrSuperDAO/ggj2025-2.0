using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startButton;
    public GameObject endButton;
    public GameObject retryButton;

     void Awake()
    {
        Init();
    }  
    public void Init()
    {
        startButton.SetActive(false);
        endButton.SetActive(false);
        retryButton.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
      
    }
    public void StartButton()
    {
        Debug.Log("��ʼ��Ϸ");
    }
    public void EndButton()
    {
        Debug.Log("������Ϸ"); 
    }
    public void RetryButton()
    {
        GameObject gamePopupObjiect = GameObject.Find("��Ϸ����UI");
        GamePopup gamePopup = gamePopupObjiect.GetComponent<GamePopup>();
        gamePopup.ResumeGame();
        Debug.Log("���¿�ʼ");
    }
 }

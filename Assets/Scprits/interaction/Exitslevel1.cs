using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exitslevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("��һ��");
            GameObject gamePopupObjiect = GameObject.Find("��Ϸ����UI");
            GamePopup gamePopup = gamePopupObjiect.GetComponent<GamePopup>();
            gamePopup.OpenLevelEndMenuUI();
        }
        Debug.Log("dddd");
    }
    
   
}

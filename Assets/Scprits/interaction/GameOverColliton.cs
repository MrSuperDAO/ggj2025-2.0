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
        GameObject gamePopupObjiect = GameObject.Find("��Ϸ����UI");
        GamePopup gamePopup = gamePopupObjiect.GetComponent<GamePopup>();
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(UI.GetComponent<GamePopup>().TransitionInCoroutine());
            //Debug.Log("ʧ����������");
            //gamePopup.PauseGame();
        }
        //retryButton.SetActive(true);

    }


}

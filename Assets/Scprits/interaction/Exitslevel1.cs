using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exitslevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zeroStars;
    public GameObject oneStars;
    public GameObject twoStars;
    public GameObject threeStars;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int stars = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("下一关");
            GameObject gamePopupObjiect = GameObject.Find("游戏界面UI");
            GamePopup gamePopup = gamePopupObjiect.GetComponent<GamePopup>();
            gamePopup.OpenLevelEndMenuUI();
            switch (stars)
            {
                case 0: zeroStars.SetActive(true); break;

                case 1: oneStars.SetActive(true); break;
                case 2: twoStars.SetActive(true); break;
                case 3: threeStars.SetActive(true); break;
                default:
                    break;
            }
        }
      
    }
    public void StarAdd()
    {
        stars++;
    }

}

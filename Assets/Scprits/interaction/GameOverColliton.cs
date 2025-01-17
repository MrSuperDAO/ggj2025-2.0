using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverColliton : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject retryButton;
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
            Debug.Log("失败重新再来");
        }
        retryButton.SetActive(true);
    }


}

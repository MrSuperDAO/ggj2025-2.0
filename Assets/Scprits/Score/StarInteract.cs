using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInteract : MonoBehaviour
{
    private AudioSource audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        Transform parentTransform = transform.parent;
        audioSource =parentTransform.GetComponent<AudioSource>();
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();//“Ù∆µ≤•∑≈
           
            Exitslevel1 exitslevel1 = FindObjectOfType<Exitslevel1>();
            exitslevel1.StarAdd();
            Destroy(this.gameObject);

        }
    }

   
}

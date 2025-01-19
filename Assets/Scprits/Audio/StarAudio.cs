using UnityEngine;
using System.Collections.Generic;

public class StarAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public static StarAudio Instance { get; private set; }

    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
       
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StarAudios()
    {
        //  AudioClip audioClip = Resources.Load<AudioClip>("Assets/“Ù–ß/À¿Õˆ“Ù–ß.mp3");
        audioSource.Play();
    }

}
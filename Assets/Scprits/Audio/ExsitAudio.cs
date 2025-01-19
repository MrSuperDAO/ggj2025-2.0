using UnityEngine;
using System.Collections.Generic;

public class ExsitAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public static ExsitAudio Instance { get; private set; }

    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ExsitAudios()
    {
        //  AudioClip audioClip = Resources.Load<AudioClip>("Assets/“Ù–ß/À¿Õˆ“Ù–ß.mp3");
        audioSource.Play();
    }

}
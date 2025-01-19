using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

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

    public void PlaySound(string soundName)
    {
        if (audioSources.TryGetValue(soundName, out AudioSource audioSource))
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Sound not found: " + soundName);
        }
    }

    public void StopSound(string soundName)
    {
        if (audioSources.TryGetValue(soundName, out AudioSource audioSource))
        {
            audioSource.Stop();
        }
    }

    public void AddSound(string soundName, AudioClip clip)
    {
        GameObject audioObject = new GameObject(soundName);
        audioObject.transform.SetParent(transform);
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSources.Add(soundName, audioSource);
    }
}
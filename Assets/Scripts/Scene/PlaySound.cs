using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource SoundToPlay;

    // Use this for initialization
    void Start()
    {
        SoundToPlay = GetComponent<AudioSource>();
        Destroy(gameObject, SoundToPlay.clip.length);
        SoundToPlay.Play();
    }
}

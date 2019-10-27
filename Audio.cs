using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour

{
    public AudioClip musicClipOne;

    public AudioSource musicSource;


    void Start()
    {
        musicSource.clip = musicClipOne;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            musicSource.clip = musicClipOne;
            musicSource.Play();

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMplayer : MonoBehaviour
{

    public AudioClip[] Music = new AudioClip[1]; // 사용할 BGM
    AudioSource AS;

    void Awake()
    {
        AS = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!AS.isPlaying)
            RandomPlay();
    }

    void RandomPlay()
    {
        AS.clip = Music[Random.Range(0, Music.Length)];
        AS.Play();
    }
}
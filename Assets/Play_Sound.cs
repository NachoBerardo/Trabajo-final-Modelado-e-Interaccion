using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Sound : MonoBehaviour
{
    public AudioClip Muerte, Derretirse, Congelarse;
    AudioSource FuenteAudio;
    void Start()
    {
        FuenteAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SonidoMuerte()
    {
        FuenteAudio.clip = Muerte;
        FuenteAudio.Play();
    }

    public void SonidoDerretirse()
    {
        FuenteAudio.clip = Derretirse;
        FuenteAudio.Play();
    }

    public void SonidoCongelarse()
    {
        FuenteAudio.clip = Congelarse;
        FuenteAudio.Play();
    }
}

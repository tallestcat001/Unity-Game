using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuidoManager : Singleton<AuidoManager>
{
    [SerializeField] AudioSource effectaudioSource;
    [SerializeField] AudioSource sceneryAudioSource;

    public void Listen(AudioClip audioClip)
    {
        effectaudioSource.PlayOneShot(audioClip);
    }
}

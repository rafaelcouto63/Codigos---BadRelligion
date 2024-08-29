using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoad : MonoBehaviour
{
     public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        StartCoroutine(LoadAndPlayAudio());
    }

    IEnumerator LoadAndPlayAudio()
    {
        // Carregar o áudio em segundo plano
        ResourceRequest request = Resources.LoadAsync<AudioClip>("Path/To/Your/AudioClip");
        yield return request;

        audioClip = request.asset as AudioClip;
        audioSource.clip = audioClip;

        // Tocar o áudio após o carregamento
        audioSource.Play();
    }
}

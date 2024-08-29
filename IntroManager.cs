using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject targetObject; // O GameObject a ser desativado
    public AudioSource targetAudio; // O AudioSource a ser ativado
    public float delay = 5f; // Tempo em segundos antes de realizar a ação

    void Start()
    {
        StartCoroutine(ActivateAudio());
    }

    IEnumerator ActivateAudio()
    {
        yield return new WaitForSeconds(delay);

        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }

        if (targetAudio != null)
        {
            targetAudio.gameObject.SetActive(true);
            targetAudio.Play();
        }
    }
}

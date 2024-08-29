using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queimar : MonoBehaviour
{
    public float delayBeforeDestroy = 2.0f; // Tempo em segundos antes de destruir o objeto

    [SerializeField] public bool isBurned = false;

    public AudioSource audioSource;

   private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidido tem a tag "Vela"
        if (other.CompareTag("Vela"))
        {
            // Ativa todos os filhos com a tag "Fogo" do objeto que possui este script
            ActivateFireInChildren(transform);
        }
    }

    private void ActivateFireInChildren(Transform parent)
    {

        foreach (Transform child in parent)
        {          
            if (child.CompareTag("Fogo"))
            {
                child.gameObject.SetActive(true);
                isBurned = true;
                audioSource.Play();
                Invoke("DestroySelf", delayBeforeDestroy);
            }
            // Recursivamente ativa os filhos dos filhos
            ActivateFireInChildren(child);
        }
    }

     private void DestroySelf()
    {
        Destroy(gameObject);
    }
}

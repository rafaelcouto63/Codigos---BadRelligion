using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estatua : MonoBehaviour
{
    public float delay = 1f;
    public float delay2 = 2f;
    public bool isBroken = false;

    public AudioSource audioSource;

       void OnMouseDown()
    {
        // Get all child objects
        Rigidbody[] childRigidbodies = GetComponentsInChildren<Rigidbody>();
        
        // Set isKinematic to false for each child Rigidbody
        foreach (Rigidbody rb in childRigidbodies)
        {
            rb.isKinematic = false;
            isBroken = true;
        }
        
        audioSource.Play();
        Invoke("DestroyBoxCollider", delay);
    }

     void DestroyBoxCollider()
    {
        // Desabilita o BoxCollider do objeto pai
        BoxCollider parentCollider = GetComponent<BoxCollider>();
        if (parentCollider != null)
        {
            parentCollider.enabled = false;
        }

        // Desabilita o outline do objeto pai
        Outline outline = GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
        }

        // Chama o método para destruir os filhos após um atraso
        Invoke("DestroyChildren", delay2);
    }

    void DestroyChildren()
    {
        // Destroi todos os objetos filhos
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}

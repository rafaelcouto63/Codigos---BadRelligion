using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frasco : MonoBehaviour
{
   public GameObject storedObject;
   public AudioSource audioSourceTirar;
   public AudioSource audioSourceColocar;

    void OnMouseDown()
    {
        // Verifica se o objeto clicado tem o script de outline habilitado
        Outline outline = GetComponent<Outline>();
        if (outline != null && outline.enabled)
        {
            // Se houver um objeto armazenado, ativa-o
            if (storedObject != null)
            {
                audioSourceColocar.Play();
                storedObject.SetActive(true);
                storedObject = null; // Limpa a referência ao objeto armazenado
            }
            else
            {
                // Procura por todos os objetos com a tag "Comprimido"
                GameObject[] compressedObjects = GameObject.FindGameObjectsWithTag("Comprimido");
                foreach (GameObject compressedObject in compressedObjects)
                {
                    // Verifica se o objeto com a tag "Comprimido" tem o outline habilitado
                    Outline compressedOutline = compressedObject.GetComponent<Outline>();
                    if (compressedOutline != null && compressedOutline.enabled)
                    {
                        // Armazena o objeto
                        storedObject = compressedObject;
                        //Toca audio
                        audioSourceTirar.Play();
                        // Desativa o objeto armazenado
                        compressedObject.SetActive(false);
                        return;
                    }
                }
            }
        }
    }
}

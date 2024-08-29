using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadeado : MonoBehaviour
{
     public string requiredKeyTag; // Tag da chave necessária, definida no Inspector
     public AudioSource audioSource;

     public GameObject objectWithAnimator; // Objeto com o Animator, definido no Inspector

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clique do mouse
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    PlayerController playerController = FindObjectOfType<PlayerController>();

                    if (playerController != null)
                    {
                        foreach (GameObject key in playerController.collectedKeys)
                        {
                            if (key.CompareTag(requiredKeyTag))
                            {
                                audioSource.Play();
                                if (objectWithAnimator != null)
                                {
                                    Animator animator = objectWithAnimator.GetComponent<Animator>();
                                    if (animator != null)
                                    {
                                        animator.enabled = true; // Ativa o Animator
                                    }
                                }
                                Destroy(this.gameObject); // Destroi o objeto
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}

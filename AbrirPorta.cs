using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPorta : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Obtém o componente Animator do objeto
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        // Ativa o Animator quando o objeto é clicado
        animator.enabled = true;
    }
}

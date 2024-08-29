using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaBiblioteca : MonoBehaviour
{
     public GameObject targetObject; // Objeto alvo a ser monitorado

    void Update()
    {
        if (targetObject == null) // Verifica se o objeto alvo foi destruído
        {
            Destroy(this.gameObject); // Destroi o objeto que contém este script
        }
    }
}

using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fase1Manager : MonoBehaviour
{
    public Cruzes[] cruzObjects; // Array público para selecionar os objetos no Inspector
    public bool isTurned = false;

    void Update()
    {
        // Verifica se todos os objetos têm isRotated como true
        bool allRotated = true;
        foreach (Cruzes cruz in cruzObjects)
        {
            if (!cruz.isRotated)
            {
                allRotated = false;
                break;
            }
        }

        // Se todos estiverem rotacionados, define isTurned como true
        if (allRotated)
        {
            isTurned = true;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase3Manager : MonoBehaviour
{
      public Queimar queimarScript; // Referência ao script Queimar

      public bool queimou = false;

    void Update()
    {
        if (queimarScript != null && queimarScript.isBurned == true)
        {
            queimou = true;
        }
    }
}

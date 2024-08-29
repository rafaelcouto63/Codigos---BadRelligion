using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstatuaManager : MonoBehaviour
{
       public bool allBroken = false;

    void Update()
    {
        Estatua[] estatuas = FindObjectsOfType<Estatua>();
        allBroken = true;

        foreach (Estatua estatua in estatuas)
        {
            if (!estatua.isBroken)
            {
                allBroken = false;
                break;
            }
        }
    }
}

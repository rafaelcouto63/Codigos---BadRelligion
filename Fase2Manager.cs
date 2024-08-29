using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase2Manager : MonoBehaviour
{
   public GameObject object1;
    public GameObject object2;

    public bool object1Check = false;
    public bool object2Check = false;

    void Update()
    {
        CheckStoredObjects();
        if (object1Check == true && object2Check == true)
        {
            // Ação a ser tomada quando a condição for verdadeira
            Debug.Log("Condição atendida: object1 armazena 'Comprimido1' e object2 armazena 'Comprimido'.");
        }
    }

    void CheckStoredObjects()
    {

        // Verifica o primeiro objeto
        if (object1 != null)
        {
            Frasco frascoScript1 = object1.GetComponent<Frasco>();
            if (frascoScript1 != null && frascoScript1.storedObject != null)
            {
                if(frascoScript1.storedObject.name == "Comprimido1")
                {
                    object1Check = true;
                }
            }
        }

        // Verifica o segundo objeto
        if (object2 != null)
        {
            Frasco frascoScript2 = object2.GetComponent<Frasco>();
            if (frascoScript2 != null && frascoScript2.storedObject != null)
            {
                if(frascoScript2.storedObject.name == "Comprimido")
                {
                    object2Check = true;
                }
            }
        }
    }
}

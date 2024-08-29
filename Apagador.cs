using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apagador : MonoBehaviour
{
    public Pentagrama pentagramaScript; // Referência ao script Pentagrama
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    audioSource.Play();
                    ResetarPentagrama();
                }
            }
        }
    }

    void ResetarPentagrama()
    {
        // Resetar todas as variáveis booleanas para falso
        pentagramaScript.Linha1 = false;
        pentagramaScript.Linha2 = false;
        pentagramaScript.Linha3 = false;
        pentagramaScript.Linha4 = false;
        pentagramaScript.Linha5 = false;
        pentagramaScript.PentagramaOn = false;

        // Apagar todas as linhas desenhadas
        GameObject[] linhas = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject linha in linhas)
        {
            if (linha.name == "Line")
            {
                Destroy(linha);
            }
        }

        Debug.Log("Pentagrama resetado e linhas apagadas");
    }
}

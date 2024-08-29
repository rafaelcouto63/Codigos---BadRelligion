using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Cruzes : MonoBehaviour
    {
        public bool isRotated = false;
    public float anguloRotacao = 30f;
    public float anguloInverter = -0.9f;
    public AudioSource[] audioSources; // Array para armazenar os três AudioSources

    void OnMouseDown()
    {
        // Rotaciona o objeto 30 graus no eixo X no sentido anti-horário
        transform.Rotate(-anguloRotacao, 0, 0); 

        // Toca um som aleatório do array de AudioSources
        if (audioSources.Length > 0)
        {
            int randomIndex = Random.Range(0, audioSources.Length);
            audioSources[randomIndex].Play();
        }
        else
        {
            Debug.LogWarning("Nenhum AudioSource atribuído!");
        }
    }

    void Update()
    {
        // Verifica se o objeto está de cabeça para baixo
        isRotated = Vector3.Dot(transform.up, Vector3.up) < anguloInverter;
    }
    }


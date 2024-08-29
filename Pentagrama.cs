using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagrama : MonoBehaviour
{
   public Color lineColor = Color.red; // Cor da linha
    public float lineWidth = 0.1f; // Largura da linha
    public bool Linha1, Linha2, Linha3, Linha4, Linha5; // Variáveis booleanas para diferentes tipos de traços
    
    public bool PentagramaOn = false;

    private GameObject[] pontos;
    private GameObject pontoAtivo;
    public AudioSource audioSource;
     // Intervalo de pitch desejado
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    void Start()
    {
        pontos = GameObject.FindGameObjectsWithTag("Ponto");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Ponto"))
                {
                    GameObject pontoClicado = hit.collider.gameObject;

                    if (pontoAtivo == null)
                    {
                        pontoAtivo = pontoClicado;
                    }
                    else
                    {
                        if (pontoClicado != pontoAtivo && pontoClicado.GetComponent<Outline>() != null)
                        {
                            VerificarLinha(pontoAtivo, pontoClicado);
                            DrawLine(pontoAtivo.transform.position, pontoClicado.transform.position);

                            // Randomiza o pitch e toca o áudio
                            audioSource.pitch = Random.Range(minPitch, maxPitch);
                            //Toca audio
                            audioSource.Play();

                            pontoAtivo = null; // Resetar o ponto ativo
                        }
                    }
                }
            }
        }

        if (Linha1 == true && Linha2 == true && Linha3 == true && Linha4 == true && Linha5 == true)
        {
            PentagramaOn = true;
        }
    }

    void VerificarLinha(GameObject pontoAtivo, GameObject pontoClicado)
    {
        int ativoID = int.Parse(pontoAtivo.name.Replace("Ponto", ""));
        int clicadoID = int.Parse(pontoClicado.name.Replace("Ponto", ""));

        if ( ((ativoID == 1 && clicadoID == 2) || (ativoID == 2 && clicadoID == 1))) Linha1 = true;

        if ( ((ativoID == 1 && clicadoID == 3) || (ativoID == 3 && clicadoID == 1))) Linha2 = true;
        
        if ( ((ativoID == 3 && clicadoID == 5) || (ativoID == 5 && clicadoID == 3))) Linha3 = true;
            
        if (((ativoID == 5 && clicadoID == 4) || (ativoID == 4 && clicadoID == 5))) Linha4 = true;
           
        if (((ativoID == 4 && clicadoID == 2) || (ativoID == 2 && clicadoID == 4))) Linha5 = true;
            
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject line = new GameObject("Line");
        LineRenderer lr = line.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = lineColor;
        lr.endColor = lineColor;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
}

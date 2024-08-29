using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
   public Fase1Manager fase1Manager;
    public Fase2Manager fase2Manager;
    public Fase3Manager fase3Manager;
    public Pentagrama pentagrama;
    public EstatuaManager estatuaManager;
    public GameObject Gate;
    public GameObject MenssagemFinal;
    public float delay = 2f;

    private bool Check1 = false;
    private bool Check2 = false;
    private bool Check3 = false;
    private bool Check4 = false;
    private bool Check5 = false;
    public bool GameWon= false;
    private bool isCheck = false;

    public AudioSource audioSource;

    public float playDuration = 1f;

    public TextMeshProUGUI[] textMeshes; // Array de TextMeshProUGUI

    void Update()
    {
        if (fase1Manager != null && fase1Manager.isTurned && Check1 == false)
        {
            // Risca o texto do primeiro TextMeshPro
            RiscarTexto(textMeshes[0]);
            StartCoroutine(PlayAudioForSeconds(playDuration));
            Check1 = true;  
        }

        if (fase2Manager != null && fase2Manager.object1Check && fase2Manager.object2Check && Check2 == false)  
        {
            // Risca o texto do segundo TextMeshPro
            RiscarTexto(textMeshes[1]);
            StartCoroutine(PlayAudioForSeconds(playDuration));
            Check2 = true;   
        }

        if (fase3Manager != null && fase3Manager.queimou && Check3 == false)
        {
            // Risca o texto do terceiro TextMeshPro
            RiscarTexto(textMeshes[2]);
            StartCoroutine(PlayAudioForSeconds(playDuration));
            Check3 = true;     
        }

        if (pentagrama != null && pentagrama.PentagramaOn && Check4 == false)
        {
            // Risca o texto do quarto TextMeshPro
            RiscarTexto(textMeshes[3]);
            StartCoroutine(PlayAudioForSeconds(playDuration));
            Check4 = true; 
        }

        if (estatuaManager != null && estatuaManager.allBroken && Check5 == false)
        {
            // Risca o texto do quinto TextMeshPro
            RiscarTexto(textMeshes[4]);
            StartCoroutine(PlayAudioForSeconds(playDuration));
            Check5 = true;       
        }

        if (Check1 && Check2 && Check3 && Check4 && Check5)
        {
            GameWon = true;
        }

        if(GameWon == true && isCheck == false)
        {
            Destroy(Gate);
            StartCoroutine(ActivateMenssagem());
        }
    }

    void RiscarTexto(TextMeshProUGUI textMesh)
    {
        if (textMesh != null)
        {
            textMesh.text = "<s>" + textMesh.text + "</s>";
        }
    }

    IEnumerator PlayAudioForSeconds(float duration)
    {
        audioSource.Play();
        yield return new WaitForSeconds(duration);
        audioSource.Stop();
    }
    IEnumerator ActivateMenssagem()
    {
        MenssagemFinal.SetActive(true);
        yield return new WaitForSeconds(delay);
        MenssagemFinal.SetActive(false); 
        isCheck = true;
    }
}

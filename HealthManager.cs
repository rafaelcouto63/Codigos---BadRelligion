using System.Diagnostics;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public GameObject[] hearts; // Array de corações que representam a vida
    public float delayBeforeGameOver = 4f; // Tempo em segundos antes de exibir a mensagem
    public GameObject TelaFim;

    void Update()
    {
        if (AreAllHeartsEnabled())
        {
            StartCoroutine(ShowGameOverMessageAfterDelay());
        }
    }

    bool AreAllHeartsEnabled()
    {
        foreach (GameObject heart in hearts)
        {
            if (!heart.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator ShowGameOverMessageAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeGameOver);
        TelaFim.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }

}

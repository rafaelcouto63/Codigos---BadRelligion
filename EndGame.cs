using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
   public string gameOverSceneName = "WonGame"; // Nome da cena de Game Over

    void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            WonGame();
        }
    }

    void WonGame()
    {
        // Carrega a cena de Game Over
        SceneManager.LoadScene(gameOverSceneName);
    }
}

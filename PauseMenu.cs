using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
public static bool GameIsPaused = false;
[SerializeField] public GameObject painelControles;
[SerializeField] public GameObject painelConfiguraçoes;
 public GameObject pauseMenuUI;

 // Update is called once per frame
 void Update()
 {
     if (Input.GetKeyDown(KeyCode.Escape))
     {
         if(GameIsPaused)
         {
             Resume();

         } else {

             Pause();
         }
     }
 }

 public void Resume()
 {
     pauseMenuUI.SetActive(false);
     painelControles.SetActive(false);
     painelConfiguraçoes.SetActive(false);
     Time.timeScale = 1f;
     GameIsPaused = false;
 }

 void Pause()
 {
     pauseMenuUI.SetActive(true);
     Time.timeScale = 0f;
     GameIsPaused = true;
 }

 public void AbrirContrtoles()
{
     pauseMenuUI.SetActive(false);
     painelControles.SetActive(true);
}
public void FecharControles()
{
    painelControles.SetActive(false);
    pauseMenuUI.SetActive(true);
}
 public void AbrirConfiguracoes()
{
     pauseMenuUI.SetActive(false);
     painelConfiguraçoes.SetActive(true);
}
public void FecharConfiguracoes()
{
    painelConfiguraçoes.SetActive(false);
    pauseMenuUI.SetActive(true);
}

 public void QuitGame()
 {
     Application.Quit();
 }
}

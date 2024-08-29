using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
[SerializeField] public GameObject painelMenuInicial;
[SerializeField] public GameObject painelOpcoes;
[SerializeField] public GameObject painelCreditos;

public void Jogar()
{
   SceneManager.LoadScene("MainGame");
}
public void AbrirOpcoes()
{
     painelMenuInicial.SetActive(false);
     painelOpcoes.SetActive(true);
}
public void FecharOpcoes()
{
    painelOpcoes.SetActive(false);
    painelMenuInicial.SetActive(true);
}
public void AbrirCreditos()
{
     painelMenuInicial.SetActive(false);
     painelCreditos.SetActive(true);
}
public void FecharCreditos()
{
    painelCreditos.SetActive(false);
    painelMenuInicial.SetActive(true);
}
public void SairJogo()
{
    Debug.Log("quit");
    Application.Quit();
}
}

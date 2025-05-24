using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal: MonoBehaviour
{
    public GameObject InitialMenu;
    public GameObject Creditos;

    private void Update()
    {
        
    }

    public void StartPlaying()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

    public void ShowCredits()
    {
        InitialMenu.SetActive(false);
        Creditos.SetActive(true);
    }

    public void HideCredits()
    {
        InitialMenu.SetActive(true);
        Creditos.SetActive(false);
    }
}

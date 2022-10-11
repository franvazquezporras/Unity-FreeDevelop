using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public GameObject PanelOpciones;
    public static int NivelesDesbloqueados;
    public int nivelActual;
    public Button[] botonesNiveles;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "SelectorDeNiveles")
        {
            ActualizarBotonesNiveles();
        }
    }
    public void Cerrar(int opcion)
    {
        //volver al menu principal
        if (opcion == 0)
        {
            SceneManager.LoadScene(0);
        }
        else if (opcion == 1)
            Application.Quit();        
    }

    public void CargarEscena(int escena)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(escena);
    }


    public void Reanudar()
    {
        //reactiva el tiempo en el juego
        Time.timeScale = 1;
        PanelOpciones.SetActive(false);
    }
    public void Pause()
    {
        //parar el tiempo en el juego
        Time.timeScale = 0;
        PanelOpciones.SetActive(true);
    }

    public void DesbloquearNivel()
    {
      
        if (NivelesDesbloqueados< nivelActual)
        {
            NivelesDesbloqueados = nivelActual;
            nivelActual++;
        }
        PlayerPrefs.SetInt("NivelesDesbloqueados", NivelesDesbloqueados);
        CargarEscena(nivelActual+1);
    }
    public void ActualizarBotonesNiveles()
    {

        NivelesDesbloqueados = PlayerPrefs.GetInt("NivelesDesbloqueados");
        for(int i = 0; i <= NivelesDesbloqueados; i++)
        {
            botonesNiveles[i].interactable = true;
        }
    }

    public void BorrarPartidas()
    {
        PlayerPrefs.DeleteAll();
    }

}

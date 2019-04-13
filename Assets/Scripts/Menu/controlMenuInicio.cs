using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class controlMenuInicio : MonoBehaviour
{
    AudioManager AudioManager;
    public static string viene;
    public Text nombre;
    public Text placeholder;
    public Toggle sonido;
    public Toggle musica;

    private void Awake()
    {
        AudioManager = GetComponent<AudioManager>();
        if(SceneManager.GetActiveScene().name == "Opciones")
        {
            sonido.isOn = XmlManager.configuracion.Sonido;
            musica.isOn = XmlManager.configuracion.Music;
            nombre.text = XmlManager.configuracion.nombre;
            placeholder.text = XmlManager.configuracion.nombre;
        }
        
    }
    public void Jugar(int level)
    {
        AudioManager.playClick();
        GameManager.level = level;
        CargarNivel("Game");
    }
    public void CargarNivel(string nombreNivel)
    {
        AudioManager.playClick();
        viene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nombreNivel);
    }
    public void CargarHighScore(string nombreNivel)
    {
        AudioManager.playClick();
        viene = SceneManager.GetActiveScene().name;
        MostrarPuntuaje.nivel = nombreNivel;
        SceneManager.LoadScene("HighScore");
    }

    public void Guardar()
    {
        AudioManager.playClick();
        XmlManager.configuracion.Music = musica.isOn;
        XmlManager.configuracion.Sonido = sonido.isOn;
        XmlManager.configuracion.nombre = nombre.text;
        GameObject.Find("XmlManager").GetComponent<XmlManager>().SaveConfiguraciones();
        CargarNivel(viene);
    }

    public void volverAtras()
    {
        AudioManager.playClick();
        SceneManager.LoadScene(viene);
    }

    public void SalirJuego()
    {
        AudioManager.playClick();
        Application.Quit();
    }
}

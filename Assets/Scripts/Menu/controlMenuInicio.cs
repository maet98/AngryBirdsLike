using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class controlMenuInicio : MonoBehaviour
{
    public static string viene;
    Configuracion conf;
    public Text nombre;
    public Text placeholder;
    public Toggle sonido;
    public Toggle musica;

    private void Awake()
    {
        conf = GameObject.Find("XmlManager").GetComponent<Configuracion>();
        if(SceneManager.GetActiveScene().name == "Opciones")
        {
            sonido.isOn = conf.Sonido;
            musica.isOn = conf.Music;
            nombre.text = conf.nombre;
            placeholder.text = conf.nombre;
        }
        
    }
    public void Jugar(int level)
    {
        GameManager.level = level;
        CargarNivel("Game");
    }
    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }

    public void Guardar()
    {
        conf.Music = musica.isOn;
        conf.Sonido = sonido.isOn;
        conf.nombre = nombre.text;
        CargarNivel(viene);
    }

    public void volverAtras()
    {
        SceneManager.LoadScene(viene);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}

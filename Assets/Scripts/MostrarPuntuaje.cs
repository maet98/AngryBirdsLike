using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MostrarPuntuaje : MonoBehaviour
{
    public GameObject puntuajes;
    public static string viene;
    public static string nivel;
    List<Score> Nombres;
    void Start()
    {
        Nombres = XmlManager.highScore.scores.Where(s => s.nivel == nivel).OrderByDescending(s => s.estrellas).ToList();

        crearTexto();

    }


    public void crearTexto()
    {
        int i = 1;
        float y = 3.5f;
        if (Nombres.Count == 0)
        {
            GameObject obj = Instantiate(puntuajes, new Vector3(0, y, -6), Quaternion.identity);
            obj.GetComponent<TextMesh>().text = "No hay ningun puntaje.";
        }
        foreach (var item in Nombres)
        {
            if (i == 10)
            {
                break;
            }
            GameObject obj = Instantiate(puntuajes, new Vector3(0, y, -6), Quaternion.identity);
            obj.GetComponent<TextMesh>().text = i.ToString() + ": " + item.nombre + ": " + item.estrellas.ToString();
            y -= 0.7f;
            i++;
        }
    }
}

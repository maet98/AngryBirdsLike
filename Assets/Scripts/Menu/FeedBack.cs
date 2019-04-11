using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using TMPro;

public class FeedBack : MonoBehaviour
{
    public TextMeshProUGUI Titulo;
    public List<GameObject> estrellas;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.CurrentGameState == GameState.Won)
        {
            Titulo.text = "Ganaste";
        }
        else
        {
            Titulo.text = "Perdiste";
            foreach (var item in estrellas)
            {
                item.SetActive(false);
            }
        }
        if (calcularEstrellas() == 2)
        {
            estrellas[2].SetActive(false);
        }
        else if (calcularEstrellas() == 1)
        {
            estrellas[1].SetActive(false);
            estrellas[2].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int calcularEstrellas()
    {
        if(GameManager.marcador > 3000)
        {
            return 3;
        }
        else if (GameManager.marcador > 2000)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlMenuInicio : MonoBehaviour
{
    private void OnMouseEnter()
    {
        transform.localScale *= 1.1f;
    }

    private void OnMouseExit()
    {
        transform.localScale /= 1.1f;
    }

    private void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "Jugar":
                SceneManager.LoadScene("game");
                break;
            case "Opciones":
                break;
            case "Salir":
                Application.Quit();
                break;
            default:
                break;
        }
    }
}

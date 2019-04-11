using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    AudioManagerGame audio;
    private void Awake()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManagerGame>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>() == null) return;

        float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
        //no sonar la madera si el daño fue minimo
        if (damage >= 10)
        {
            audio.playMadera();
        }
        //Restarle la vida segun la magnitud de la velocidad que venia
        Health -= damage;
        //si la vida es menor que 0 se destruye
        if (Health <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().destruido(tag);
            Destroy(this.gameObject);
        }
    }

    public float Health = 70f;
}

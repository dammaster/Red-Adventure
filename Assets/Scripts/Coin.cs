using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public GameObject coin;
    public AudioClip Sonido = null;
    public float Volume = 1.0f;
    protected Transform Posicion = null;


    public void Start()
    {
        Posicion = transform;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            if (Sonido) AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volume);

               coin.SetActive(false);

        }
    }

    public void StartCoinAgain()
    {

        coin.SetActive(true);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


    private float scrollSpeed = -4f;
    private bool maseKontakt = false;
    public AudioClip Sonido = null;
    public float Volume = 1.0f;
    protected Transform Posicion = null;


    // Use this for initialization
    public void Start()
    {
        Posicion = transform;
    }

    // Update is called once per frame
    void Update()
    {



        if (maseKontakt == true)
        {
            runLeft();
        }
        if (maseKontakt == false)
        {
            runRight();
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ShootIn")

        {
           //    Debug.Log("collision" + other.tag);
            maseKontakt = true;

        }

        else if (other.tag == "ShootOut")

        {
          //    Debug.Log("collision" + other.tag);
            maseKontakt = false;

        }

        else if (other.tag == "Player")

        {
            if (Sonido) AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volume);
            Destroy(this.gameObject);

        }



    }

    public void runRight()
    {
        transform.Translate((new Vector3(3f, 0, 0)) * scrollSpeed * Time.deltaTime);
       
    }



    public void runLeft()
    {
        transform.Translate((new Vector3(-3f, 0, 0)) * scrollSpeed * Time.deltaTime);
      


    }
}

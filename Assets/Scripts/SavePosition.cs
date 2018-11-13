using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour {

    public GameObject savePosition;
    public AudioClip Sonido = null;
    public float Volume = 1.0f;
    protected Transform Posicion = null;
    public bool savePositionActive = false;

    public void Start()
    {
        Posicion = transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            savePositionActive = true;
           // Destroy(this.gameObject);
          //  transform.localScale = new Vector3(0, 0, 1);

            if (Sonido) AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volume);

            savePosition.SetActive(false);


        }
    }
}

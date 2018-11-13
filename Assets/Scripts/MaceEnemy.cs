using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceEnemy : MonoBehaviour
{

    private float scrollSpeed = -4f;
    private bool maseKontakt = false;



    // Use this for initialization
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {

      

        if (maseKontakt == true)
        {
            runRight();
        }
        if (maseKontakt == false)
        {
            runLeft();
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Bloque")

        {

            maseKontakt = true;


        }

        else if (other.tag == "Bloque2")

        {
          //  Debug.Log("collision" + other.tag);
            maseKontakt = false;

        }


    }

    public void runRight()
    {
        transform.Translate((new Vector3(0, 1, 0)) * scrollSpeed * Time.deltaTime);
    }



    public void runLeft()
    {
        transform.Translate((new Vector3(0, -1, 0)) * scrollSpeed * Time.deltaTime);

    }
}

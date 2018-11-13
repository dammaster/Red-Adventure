using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{

    private Player _player;
    private float scrollSpeed = -6f;
  

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_player.moveBackgroundLeft == true)
        {
            backgroundLeft();
        }
        if (_player.moveBackgroundRight == true)
        {
            backgroundRight();
        }
    }
       


    public void backgroundLeft()
    {

        transform.Translate((new Vector3(-1, 0, 0)) * scrollSpeed * Time.deltaTime);
    }

    public void backgroundRight()
    {
        transform.Translate((new Vector3(1, 0, 0)) * scrollSpeed * Time.deltaTime);
    }



    public void backgroundCollider()
    {

        transform.position = new Vector3(_player.xMovement, _player.yMovement, 0);
    }

   










}

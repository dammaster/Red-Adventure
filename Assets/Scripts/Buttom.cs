using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttom : MonoBehaviour {

   private Player _player;
//   private Coin _coin;
//   private ScrollBackground _scrollBackground;
 //  private UIManager _uiManager;
    private SoundControl _soundControl;


    // Use this for initialization
    void Start () {

       
        _player = GameObject.Find("Player").GetComponent<Player>();
 //       _scrollBackground = GameObject.Find("Background").GetComponent<ScrollBackground>();
     //   _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
     //   _coin = GameObject.Find("Coin").GetComponent<Coin>();
        _soundControl = GameObject.Find("Sound").GetComponent<SoundControl>();

    }
	
	// Update is called once per frame
	void Update () {
    

    }

    public void rightOn()
    {
            _player.Xmovement(1);
            _player.moveRight();
       //     _scrollBackground.backgroundRight();

    }

    public void rightOff()
    {
        _player.Xmovement(0);
        _player.moveStop();
    }

    public void LeftOn()
    {
        _player.Xmovement(-1);
        _player.moveLeft();
   //     _scrollBackground.backgroundLeft();
    }

    public void LeftOff()
    {
        _player.Xmovement(0);
        _player.moveStop();
    }

    public void UpOn()
    {
        _player.Ymovement(1);
        _player.moveUp();
    }

    public void UpOff()
    {
        _player.Ymovement(0);
        _player.moveStop();
    }




    public void Bquit()
    {
        SceneManager.LoadScene("GameOver");
    }



    public void soundOff()
    {
        _soundControl.stopMyAudio();
    }

   
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Text CoinText;
    public int score;
    public Text LiveText;
    public int lives;
    //public Image livesImageDisplay;


    public GameObject GameOverText;
    public GameObject Finish;



    //   private GameManager _gameManager;


    // public GameObject GameOver;
    //   public GameObject YouWin;


    public void UpdateLives(int currentLive)
    {
      //  currentLive--;
        LiveText.text = "" + currentLive;

       
    }

    public void UpdateScore()
    {
        score++;
        CoinText.text = "" + score;

        //if (score > 1)
        //{
        //    lives++;

        //}
    }

    //internal void UpdateLives(object curr)
    //{
    //    throw new NotImplementedException();
    //}

    public void ShowPlayStartScreen()
    {

        SceneManager.LoadScene("GameOver");
        //   PlayStartScreen.SetActive(true);

    }

    public void HidePlayStartScreen()
    {

     //   PlayStartScreen.SetActive(false);
        score = 0;
        CoinText.text = "0";
    }



    public void GameOverScreen()
    {
        GameOverText.SetActive(true);
    }
    public void FinishScreen()
    {
        Finish.SetActive(true);
    }




}

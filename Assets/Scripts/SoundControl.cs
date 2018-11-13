using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundControl : MonoBehaviour {


    public GameObject Sound;

    private bool control = true;

    public void stopMyAudio()
    {
        if (control == false)
        {
            Sound.SetActive(true);
            control = true;
        }
        else
        {
            Sound.SetActive(false);
            control = false;
        }
    }

}

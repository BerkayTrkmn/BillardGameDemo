using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource myMusic;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if slider value is change then volume changes(all scene volumes)
        //Note: menu button used for check volume  
        AudioListener.volume = volumeSlider.value;
	}

    //void SaveMusicVolume()
    //{
    //    PlayerPrefs.SetInt("", savedNumber);
    //}

}

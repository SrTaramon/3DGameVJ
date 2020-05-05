using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    public AudioSource backMusic;

    void Start(){
        backMusic = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }
    public void adjustVolume(float volume){
        backMusic.volume = volume;
    }
}

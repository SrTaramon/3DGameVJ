using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerController : MonoBehaviour
{
    public static AudioClip explosion;

    static AudioSource audioSrc;

    void Start(){
        explosion = Resources.Load<AudioClip>("Explosion");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string state){
        switch (state){
        case "explosion":
            audioSrc.PlayOneShot(explosion);
            break;
        }
    }
}

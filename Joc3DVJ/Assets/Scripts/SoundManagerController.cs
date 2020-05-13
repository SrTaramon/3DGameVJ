using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerController : MonoBehaviour
{
    public static AudioClip explosion;
    public static AudioClip bullet;

    static AudioSource audioSrc;

    void Start(){
        explosion = Resources.Load<AudioClip>("Explosion");
        audioSrc = GetComponent<AudioSource>();
        bullet = Resources.Load<AudioClip>("Bullet");
    }

    public static void PlaySound(string state){
        switch (state){
        case "explosion":
            audioSrc.PlayOneShot(explosion);
            break;
        case "bullet":
            audioSrc.PlayOneShot(bullet);
            break;
        }
    }
}

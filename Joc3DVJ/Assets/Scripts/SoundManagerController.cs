using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerController : MonoBehaviour
{
    public static AudioClip explosion;
    public static AudioClip bullet;

    public static AudioClip win;

    public static AudioClip gameover;

    static AudioSource audioSrc;

    void Start(){
        explosion = Resources.Load<AudioClip>("Explosion");
        audioSrc = GetComponent<AudioSource>();
        bullet = Resources.Load<AudioClip>("Bullet");
        gameover = Resources.Load<AudioClip>("GameOver");
        win = Resources.Load<AudioClip>("Win");
    }

    public static void PlaySound(string state){
        switch (state){
        case "explosion":
            audioSrc.PlayOneShot(explosion);
            break;
        case "bullet":
            audioSrc.PlayOneShot(bullet);
            break;
        case "gameover":
            audioSrc.PlayOneShot(gameover);
            break;
        case "win":
            audioSrc.PlayOneShot(win);
            break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    public GameObject explosionEffect;

    private AudioSource audio;

    void Start(){
        audio = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision c){
        if (c.gameObject.name == "Roca"){
            explosion(c.gameObject);
            audio.mute = !audio.mute;
        }
    }

    void explosion(GameObject xocat){
        GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
        SoundManagerController.PlaySound("explosion");
        Destroy(cloneExpl, 4);
        Destroy(xocat);
        gameObject.SetActive(false);
    }
}

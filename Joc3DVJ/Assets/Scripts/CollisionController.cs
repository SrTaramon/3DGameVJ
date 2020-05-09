using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    public GameObject explosionEffect;
    
    void OnCollisionEnter(Collision c){
        if (c.gameObject.name == "Roca"){
            explosion(c.gameObject);
        }
    }

    void explosion(GameObject xocat){
        Instantiate(explosionEffect, transform.position, transform.rotation);
        SoundManagerController.PlaySound("explosion");
        Destroy(xocat);
        gameObject.SetActive(false);
    }
}

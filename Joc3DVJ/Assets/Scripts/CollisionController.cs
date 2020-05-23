using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{

    public GameObject explosionEffect;

    public Slider sliderHP;

    public Image mira;

    public TextMesh text;

    private AudioSource audio;

    private float vida;

    void Start(){
        audio = GetComponent<AudioSource>();
        vida = 100;
    }

    void Update(){
        if (vida <= 0){
            gameObject.SetActive(false);
            mira.gameObject.SetActive(false);
            text.gameObject.SetActive(true);
        }
    }
    
    void OnCollisionEnter(Collision c){
        if (c.gameObject.name == "Roca"){
            explosionMuerte(c.gameObject);
            audio.mute = !audio.mute;
            vida = 0;
        }
        else if (c.gameObject.tag == "Bullet"){
            explosionBala(c.gameObject);
            vida -= 10;
            sliderHP.value = vida/100;
        }
    }

    void explosionMuerte(GameObject xocat){
        GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
        SoundManagerController.PlaySound("explosion");
        Destroy(cloneExpl, 4);
        Destroy(xocat);
        gameObject.SetActive(false);
    }

    void explosionBala(GameObject xocat){
        GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
        SoundManagerController.PlaySound("explosion");
        Destroy(cloneExpl, 4);
        Destroy(xocat);
    }

}

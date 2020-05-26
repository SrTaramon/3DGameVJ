using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{

    public GameObject explosionEffect;

    public Slider sliderHP;

    public TextMesh text;

    public TextMesh godMode;

    public Collider collider;

    private AudioSource audio;

    private float vida;

    private bool dead;

    public static bool god;

    void Start(){
        collider = GetComponent<Collider>();
        audio = GetComponent<AudioSource>();
        vida = 100;
        dead = false;
        text.gameObject.SetActive(false);
        godMode.gameObject.SetActive(false);
        god = false;
    }

    void Update(){
        if (vida <= 0 && !dead){
            gameObject.SetActive(false);
            dead = true;
        }
        if (Input.GetKeyDown(KeyCode.G)){
            god = !god;
            collider.enabled = !collider.enabled;
            godMode.gameObject.active = !godMode.gameObject.active;
        }
    }

    
    void OnCollisionEnter(Collision c){
        if (c.gameObject.tag == "Enemy"){
            Debug.Log("YESSA");
            explosionMuerte(c.gameObject);
            audio.mute = !audio.mute;
            vida = 0;
        }
        if (c.gameObject.tag == "Tower1"){
            explosionMuerte(c.gameObject);
            audio.mute = !audio.mute;
            vida = 0;
        }
        if (c.gameObject.tag == "Tower2"){
            explosionMuerte(c.gameObject);
            audio.mute = !audio.mute;
            vida = 0;
            
        }
        if (c.gameObject.tag == "Roca"){
            explosionMuerteSoloNave(c.gameObject);
            audio.mute = !audio.mute;
            vida = 0;
        }
        else if (c.gameObject.tag == "Bullet"){
            explosionBala(c.gameObject);
            vida -= 10;
            if (vida <= 0){
                explosionMuerte(c.gameObject);
            }
        }
        sliderHP.value = vida/100;
    }

    void explosionMuerte(GameObject xocat){
        GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
        SoundManagerController.PlaySound("explosion");
        Destroy(cloneExpl, 4);
        Destroy(xocat);
        gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        SoundManagerController.PlaySound("gameover");
    }

    void explosionBala(GameObject xocat){
        GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
        SoundManagerController.PlaySound("explosion");
        Destroy(cloneExpl, 4);
        Destroy(xocat);
    }

    void explosionMuerteSoloNave(GameObject xocat){
        GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
        SoundManagerController.PlaySound("explosion");
        Destroy(cloneExpl, 4);
        gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        SoundManagerController.PlaySound("gameover");
    }

}

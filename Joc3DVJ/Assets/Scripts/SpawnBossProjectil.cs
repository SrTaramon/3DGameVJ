using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossProjectil : MonoBehaviour
{
    public GameObject explosionEffect;

    public GameObject firePoint1;

    public GameObject projectil;

    public GameObject projectilOrientation1;

    public float despawnTime;

    private Vector3 direction;

    public float rafagaTimer;
    private float lastShot;
    private bool modorafaga;

    private int vida;

    // Start is called before the first frame update
    void Start()
    {
        vida = 20;
        modorafaga = false;
    }

    // Update is called once per frame
    void Update()
    {   

        if (modorafaga){
            FSpawnProjectil();
            SoundManagerController.PlaySound("bullet");
        }
        if ((Time.time > rafagaTimer + lastShot) ){ // ficar un and amb la distacia la qual començara a disparar
            modorafaga = !modorafaga;
            lastShot = Time.time;
        }
        
        
    }

    void FSpawnProjectil() {
        GameObject proj, proj2;


        proj = Instantiate(projectil, firePoint1.transform.position, Quaternion.identity);
        direction = projectilOrientation1.transform.position - firePoint1.transform.position;
        proj.transform.localRotation = Quaternion.LookRotation(direction);

        Destroy (proj, despawnTime);
    }

    void OnCollisionEnter(Collision c){
        // Fer que tingui vida no nomes 1 hit
        if (c.gameObject.tag == "FriendBullet"){
            GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
            SoundManagerController.PlaySound("explosion");
            vida = vida - 1;
            switch (vida){
                case 18:
                    GameObject.Find("HPB10").SetActive(false);
                    break;
                case 16:
                    GameObject.Find("HPB9").SetActive(false);
                    break;
                case 14:
                    GameObject.Find("HPB8").SetActive(false);
                    break;
                case 12:
                    GameObject.Find("HPB7").SetActive(false);
                    break;
                case 10:
                    GameObject.Find("HPB6").SetActive(false);
                    break;
                case 8:
                    GameObject.Find("HPB5").SetActive(false);
                    break;
                case 6:
                    GameObject.Find("HPB4").SetActive(false);
                    break;
                case 4:
                    GameObject.Find("HPB3").SetActive(false);
                    break;
                case 2:
                    GameObject.Find("HPB2").SetActive(false);
                    break;
                case 0:
                    GameObject.Find("HPB1").SetActive(false);
                    Destroy(cloneExpl, 4);
                    Destroy(c.gameObject);
                    gameObject.SetActive(false);
                    break;
            }
            
        }
        else if (c.gameObject.name == "Player"){
            Debug.Log("Hola");
        }
    }
}

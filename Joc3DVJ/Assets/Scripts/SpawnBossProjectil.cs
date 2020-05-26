using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnBossProjectil : MonoBehaviour
{
    public GameObject explosionEffect;

    public GameObject firePoint1;

    public GameObject projectil;

    public GameObject projectilOrientation1;

    public float despawnTime;

    public TextMesh win;

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
        win.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   

        if (modorafaga){
            FSpawnProjectil();
           //SoundManagerController.PlaySound("bullet");
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
            vida = vida - 1;
            switch (vida){
                case 18:
                    GameObject.Find("HPB10").SetActive(false);
                    SoundManagerController.PlaySound("explosion");
                    break;
                case 16:
                    GameObject.Find("HPB9").SetActive(false);
                    SoundManagerController.PlaySound("explosion");
                    break;
                case 14:
                    GameObject.Find("HPB8").SetActive(false);
                    SoundManagerController.PlaySound("explosion");
                    break;
                case 12:
                    GameObject.Find("HPB7").SetActive(false);
                    SoundManagerController.PlaySound("explosion");
                    break;
                case 10:
                    GameObject.Find("HPB6").SetActive(false);
                    SoundManagerController.PlaySound("explosion");
                    break;
                case 8:
                    GameObject.Find("HPB5").SetActive(false);
                    SoundManagerController.PlaySound("explosion");
                    break;
                case 6:
                    GameObject.Find("HPB4").SetActive(false);
                    SoundManagerController.PlaySound("explosion");
                    break;
                case 4:
                    GameObject.Find("HPB3").SetActive(false);
                    SoundManagerController.PlaySound("explosion");
                    break;
                case 2:
                    GameObject.Find("HPB2").SetActive(false);
                    SoundManagerController.PlaySound("explosion");
                    break;
                case 0:
                    GameObject.Find("HPB1").SetActive(false);
                    GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
                    Destroy(cloneExpl, 3);
                    Destroy(c.gameObject);
                    gameObject.SetActive(false);
                    SoundManagerController.PlaySound("win");
                    win.gameObject.SetActive(true);
                    break;
            }
            
        }
        else if (c.gameObject.name == "Player"){
            Debug.Log("Hola");
        }
    }

}

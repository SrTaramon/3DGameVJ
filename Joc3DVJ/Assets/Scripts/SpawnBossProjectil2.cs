using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossProjectil2 : MonoBehaviour
{
    public GameObject explosionEffect;

    public GameObject firePoint1;
    public GameObject firePoint2;

    public GameObject projectil;

    public GameObject projectilOrientation1;

    public float despawnTime;

    public TextMesh win;

    private Vector3 direction; 
    private Vector3 direction2;

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
        
        var dist = Vector3.Distance(projectilOrientation1.transform.position, gameObject.transform.position);

        if (modorafaga){
            FSpawnProjectil();
           //SoundManagerController.PlaySound("bullet");
        }
        if ((Time.time > rafagaTimer + lastShot) && dist < 250){ // ficar un and amb la distacia la qual començara a disparar
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

        proj2 = Instantiate(projectil, firePoint2.transform.position, Quaternion.identity);
        direction2 = projectilOrientation1.transform.position - firePoint2.transform.position;
        proj2.transform.localRotation = Quaternion.LookRotation(direction2);

        Destroy (proj2, despawnTime);
    }

    void OnCollisionEntered(Collider c){
        if (c.gameObject.tag == "FriendBullet"){
            Debug.Log("AQUi entro");
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemyProjectil : MonoBehaviour
{
    public GameObject explosionEffect;

    public GameObject firePoint1;

    public GameObject projectil;

    //public GameObject projectilOrientation;

    public GameObject player;

    public float despawnTime;

    private Vector3 direction;
    private Vector3 direction2;
    public float fireRate;
    private float lastShot;

    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Level2"){
            player = GameObject.Find("GameplayPlane");
        }
    }

    // Update is called once per frame
    void Update()
    {  
        if (player.activeSelf){
            dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
            
        }
        
        if ((Time.time > fireRate + lastShot) ){ // ficar un and amb la distacia la qual començara a disparar
            if (SceneManager.GetActiveScene().name == "Level2"){
                if (dist <= 150) {
                    FSpawnProjectil();
                    lastShot = Time.time;
                    SoundManagerController.PlaySound("bullet");
                    lastShot = Time.time;
                }
            }
            else if (dist <= 250 && ((player.transform.position.z - gameObject.transform.position.z) < 0)) {
                FSpawnProjectil();
                SoundManagerController.PlaySound("bullet");
                lastShot = Time.time;
            }
        }
        
    }

    void FSpawnProjectil() {
        GameObject proj;


        proj = Instantiate(projectil, firePoint1.transform.position, Quaternion.identity);
        direction = player.transform.position - firePoint1.transform.position;
        proj.transform.localRotation = Quaternion.LookRotation(direction);

        Destroy (proj, despawnTime);
    }

    void OnCollisionEnter(Collision c){
        if (c.gameObject.tag == "FriendBullet"){
            GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
            SoundManagerController.PlaySound("explosion");
            Destroy(cloneExpl, 4);
            Destroy(c.gameObject);
            gameObject.SetActive(false);
            Debug.Log("Hola");
        }
    }
}

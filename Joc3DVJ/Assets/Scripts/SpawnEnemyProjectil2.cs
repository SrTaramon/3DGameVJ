using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyProjectil2 : MonoBehaviour
{
    public GameObject explosionEffect;

    public GameObject firePoint1;
    public GameObject firePoint2;

    public GameObject projectil;

    public GameObject projectilOrientation1;

    public float despawnTime;

    public GameObject card; 

    private Vector3 direction;
    private Vector3 direction2;

    public float fireRate;
    private float lastShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if ((Time.time > fireRate + lastShot) ){ // ficar un and amb la distacia la qual començara a disparar
            FSpawnProjectil();
            SoundManagerController.PlaySound("bullet");
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

    void OnCollisionEnter(Collision c){
        if (c.gameObject.tag == "FriendBullet"){
            GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
            SoundManagerController.PlaySound("explosion");
            Destroy(cloneExpl, 4);
            Destroy(c.gameObject);
            gameObject.SetActive(false);
        }
        else if (c.gameObject.name == "Player"){
            Debug.Log("Hola");
        }
    }

}

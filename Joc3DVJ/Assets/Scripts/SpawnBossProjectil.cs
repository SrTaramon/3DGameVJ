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

    // Start is called before the first frame update
    void Start()
    {
        modorafaga = false;
    }

    // Update is called once per frame
    void Update()
    {   

        if (modorafaga){
            FSpawnProjectil();
            SoundManagerController.PlaySound("bullet");

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
            Destroy(cloneExpl, 4);
            Destroy(c.gameObject);
            gameObject.SetActive(false);
        }
        else if (c.gameObject.name == "Player"){
            Debug.Log("Hola");
        }
    }
}

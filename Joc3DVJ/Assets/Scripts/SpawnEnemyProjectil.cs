using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyProjectil : MonoBehaviour
{
     public GameObject firePoint1;

    public GameObject projectil;

    public GameObject projectilOrientation;

    public float despawnTime;

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
        GameObject proj;


        proj = Instantiate(projectil, firePoint1.transform.position, Quaternion.identity);
        direction = projectilOrientation.transform.position - firePoint1.transform.position;
        proj.transform.localRotation = Quaternion.LookRotation(direction);

        Destroy (proj, despawnTime);
    }
}

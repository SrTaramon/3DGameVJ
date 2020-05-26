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
        Debug.Log(dist);

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
}

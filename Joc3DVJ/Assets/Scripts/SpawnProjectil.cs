using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectil : MonoBehaviour
{   
    public GameObject firePoint1;
    public GameObject firePoint2;

    public GameObject projectil;

    public GameObject projectilOrientation;
    public GameObject projectilOrientation2;

    public float despawnTime;

    private Vector3 direction;
    private Vector3 direction2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.S)){
            FSpawnProjectil();
            SoundManagerController.PlaySound("bullet");
        }
        
    }

    void FSpawnProjectil() {
        GameObject proj;
        GameObject proj2;


        proj = Instantiate(projectil, firePoint1.transform.position, Quaternion.identity);
        direction = projectilOrientation.transform.position - firePoint1.transform.position;
        proj.transform.localRotation = Quaternion.LookRotation(direction);


        proj2 = Instantiate(projectil, firePoint2.transform.position, Quaternion.identity);
        direction2 = projectilOrientation2.transform.position - firePoint2.transform.position;
        proj2.transform.localRotation = Quaternion.LookRotation(direction2);

        Destroy (proj, despawnTime);
        Destroy (proj2, despawnTime);
    }
}

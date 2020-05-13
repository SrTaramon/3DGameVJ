using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilMov : MonoBehaviour
{   
    public float speed;
    public float firerate;

    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0) {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        speed = 0;

        GameObject clonExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
        SoundManagerController.PlaySound("explosion");
        Destroy(clonExpl, 2);
        Destroy(gameObject);
    }
}

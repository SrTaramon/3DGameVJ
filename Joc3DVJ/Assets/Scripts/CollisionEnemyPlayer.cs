using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemyPlayer : MonoBehaviour
{
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {   

        if (collision.gameObject.tag == "FriendBullet"){
            GameObject cloneExpl = Instantiate(explosionEffect, transform.position, transform.rotation);
            SoundManagerController.PlaySound("explosion");
            Destroy(cloneExpl, 4);
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }

    }
}

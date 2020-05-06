using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Update(){
        transform.localPosition += new Vector3(0, 0, 1) * 10 * Time.deltaTime;
    }
}

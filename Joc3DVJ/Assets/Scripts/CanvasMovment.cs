using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMovment : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        if (hor == 0) hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Vertical");
        if (ver == 0) ver = Input.GetAxis("Mouse Y");
        transform.localPosition += new Vector3(hor*3, ver*3, 0) * 100 * Time.deltaTime;

        

        //tinc q fer q no surti de la pantalla
    }


}

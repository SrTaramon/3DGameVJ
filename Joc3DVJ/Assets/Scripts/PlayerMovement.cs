using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        float horKey = Input.GetAxis("Horizontal");
        float verKey = Input.GetAxis("Vertical");
    
        if (hor != 0 || ver != 0) AxisMove(hor, ver, speed);
        if (horKey != 0 || verKey != 0) AxisMove(horKey, verKey, speed);
    }

    void AxisMove(float x, float y, float speed){
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
        PositionFrame();
    }

    void PositionFrame()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}

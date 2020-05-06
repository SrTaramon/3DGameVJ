using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Transform player;
    public float speed;

    void Start(){
        player = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        float horKey = Input.GetAxis("Horizontal");
        float verKey = Input.GetAxis("Vertical");
    
        if (hor != 0 || ver != 0){
            AxisMove(hor, ver, speed);
            HorizontalLean(player, hor, 50, .1f);
        } 
        if (horKey != 0 || verKey != 0){
            AxisMove(horKey, verKey, speed);
            HorizontalLean(player, horKey, 50, .1f);
        } 

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu", LoadSceneMode.Single);
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

     void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
    }
}

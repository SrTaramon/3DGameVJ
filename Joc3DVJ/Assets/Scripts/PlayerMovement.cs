using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;


public class PlayerMovement : MonoBehaviour
{
    private Transform player;
    public float speed;
    public Transform aimTarget;
    public float lookSpeed = 340;

    void Start(){
        player = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {

        float hor = Input.GetAxis("Horizontal");
        if (hor == 0) hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Vertical");
        if (ver == 0) ver = Input.GetAxis("Mouse Y");
        

        AxisMove(hor, ver, speed);
        RotationLook(hor,ver, lookSpeed);
        HorizontalLean(player, hor, 50, .1f);


        /*
        if (hor != 0 || ver != 0){
            AxisMove(hor, ver, speed);
            RotationLook(hor,ver, lookSpeed);
            HorizontalLean(player, hor, 50, .1f);
        } 
        if (horKey != 0 || verKey != 0){
            AxisMove(horKey, verKey, speed);
            RotationLook(horKey,horKey, lookSpeed);
            HorizontalLean(player, horKey, 50, .1f);
        } 
        */

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu", LoadSceneMode.Single);

        if (Input.GetKey(KeyCode.Space)) QuickSpin(1);
    }

    void AxisMove(float x, float y, float speed){
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
        PositionFrame();
        aimTarget.localPosition += new Vector3(x*3, y*3, 0) * speed * Time.deltaTime;
        Vector3 limits = aimTarget.localPosition;
        if (limits.x > 45) limits.x = 45;
        if (limits.x < -45) limits.x = -45;
        if (limits.y > 25) limits.y = 25;
        if (limits.y < -25) limits.y = -25;
        aimTarget.localPosition = limits;
    }

    void PositionFrame()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void RotationLook(float h, float v, float speed)
    {   
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed);
        //aimTarget.localPosition = new Vector3(h, v, 10);
        
    }

     void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(aimTarget.position, .5f);
        Gizmos.DrawSphere(aimTarget.position, .15f);

    }

    public void QuickSpin(int dir)
    {
        if (!DOTween.IsTweening(player))
        {
            player.DOLocalRotate(new Vector3(player.localEulerAngles.x, player.localEulerAngles.y, 360 * -dir), .4f, RotateMode.LocalAxisAdd).SetEase(Ease.OutSine);
        }
    }

}

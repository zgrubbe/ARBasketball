/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    public Vector3 throwSpeed;
    //private GameObject ballClone;
    private Rigidbody rbBall;

    private void Start()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            rbBall.AddForce(throwSpeed);
        }
    }*/

    /*  * References:    *  https://code.tutsplus.com/tutorials/create-a-basketball-free-throw-game-with-unity--cms-21203  *  https://www.youtube.com/watch?v=vduSC2YHFnw  *  https://forum.unity.com/threads/flicking-shooting-throwing-tossing-lobbing-slicing-script.91726/  *   *   *  Free udemy course on creating basketball game in Unity  *      https://www.udemy.com/unity-game-developer/  *  Link below is for a $5 asset of basketball shooting and soccer - may be a easy solution  *      https://assetstore.unity.com/packages/templates/simple-soccer-basketball-68851  */   using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.UI;  public class Shoot : MonoBehaviour {      private Vector3 throwSpeed;     private Rigidbody rbBall;
    bool ballShot;     bool shooting;     public Text forceAngle;     private float angleForce = 0f;     private float throwZ = -200f;     private float throwX = 0f;      private void Start()     {         rbBall = GetComponent<Rigidbody>();         ballShot = false;         shooting = false;         forceAngle.text = "Force Angle: " + angleForce.ToString();         throwSpeed = new Vector3(0f,0f,0f);     }      void FixedUpdate()     {         if (Input.GetButton("Fire1") && !ballShot)         {             shooting = true;             angleForce += 1f;             forceAngle.text = "Force Angle: " + angleForce.ToString();         }         else if (!Input.GetButton("Fire1") && shooting)
        {
            ballShot = true;
            throwSpeed = new Vector3(throwX,angleForce,throwZ);
            rbBall.isKinematic = false;
            rbBall.useGravity = true;
            rbBall.AddForce(throwSpeed);
            shooting = false;
        }     }      void Update()     {         if (!ballShot)
        {
            Vector3 temp = Input.mousePosition;
            temp.z = 5f; // Set distance to be moved forward.             this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        }
    } }

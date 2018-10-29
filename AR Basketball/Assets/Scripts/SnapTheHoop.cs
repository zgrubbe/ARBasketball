using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTheHoop : MonoBehaviour {
    private Vector3 moveSpeed;
    private Rigidbody bBoard;
    bool fired;
    private float angleForce = 0f;
    private float throwZ = -100000f;
    private float throwX = 0f;
    private float shootSpeed = 0f;


    // Use this for initialization
    void Start () {
        bBoard = GetComponent<Rigidbody>();
        bBoard.useGravity = false;
        this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.35f);
        fired = false;
    }

    void FixedUpdate()
    {
    
        if (!fired){
            Vector3 temp = Input.mousePosition;
            temp.z = 2f; // Set distance to be moved forward.
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
            bBoard.isKinematic = false;
            bBoard.AddForce(moveSpeed);
            moveSpeed = new Vector3(throwX, angleForce, throwZ);
        }
    }

    // Update is called once per frame
    void LateUpdate () {
        if (Input.GetButton("Fire1"))
        {
            fired = true;
            this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        bBoard.isKinematic = true;
        bBoard.transform.rotation = collision.transform.rotation;
    }
}

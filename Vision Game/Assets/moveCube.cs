using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCube : MonoBehaviour
{

    public float speed = 0.0f;
    Rigidbody rb; 
 // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        rb.AddForce(xDirection, 0, zDirection, ForceMode.VelocityChange);
}




   
}
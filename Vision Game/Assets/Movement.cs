using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    private void start()
    {
        rb = GetComponent<Rigidbody>();

    }
    
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");


        rb.velocity = new Vector3(xMov * speed, rb.velocity.y, zMov * speed);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float jumpForce;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //MoverPersonaje();
        RotarPersonaje();
    }

    private void FixedUpdate()
    {
        MoverPersonajePro();
    }

    public void MoverPersonaje()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(horizontal, 0, vertical).normalized;
        
        transform.Translate(speed*Time.deltaTime * mov);
    }
    
    public void MoverPersonajePro()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 mov = new Vector3(horizontal, rb.velocity.y, vertical).normalized;

        rb.velocity = mov * speed;
    }

    void RotarPersonaje()
    {
        float inputMouse = Input.GetAxis("Mouse X");
        
        Vector3 axis = Vector3.up;
        
        transform.Rotate(inputMouse * rotationSpeed * Time.deltaTime * axis);
    }

    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }
}
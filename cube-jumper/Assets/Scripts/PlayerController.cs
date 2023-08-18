using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool _jump;
    [SerializeField]private float jumpDistance = 5;
    public float moveSpeed = .5f;
    public float maxSpeed = 5f;
    public float gravity =-20;
    private GroundCheck groundCheck;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
        Physics.gravity = new Vector3(0,gravity, 0);
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& groundCheck.isGrounded)
        {
            _jump = true;
        }

        
    }

    private void FixedUpdate() 
    {
        if (_jump)
        Jump();
        _jump = false;
         MoveForward();
        
    }

    void Jump()
    {
        rb.AddForce(Vector3.up*jumpDistance,ForceMode.Impulse);
    }

    void MoveForward()
    {
        Vector3 moveDirection = transform.forward;
        rb.AddForce(moveDirection * moveSpeed);
        rb.AddForce(-rb.velocity*rb.drag);

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized*maxSpeed;
        }
    }
}

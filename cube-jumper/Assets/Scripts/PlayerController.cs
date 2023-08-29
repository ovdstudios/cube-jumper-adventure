using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Dreamteck.Splines;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField]Transform groundCheck;
    [SerializeField]private float jumpHeight = 2f;
    private float gravity = -80f;
    private CharacterController characterController;
    
    private Vector3 velocity;
    
    private bool negativeRotate90 = false;
    
    private bool rotated = false;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }
    //Ground Check
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f,groundLayers);
    }
    // Update is called once per frame
    void Update()
    {

        if(negativeRotate90&& !rotated)
        {
            transform.Rotate(Vector3.up,-90f);
           rotated = true;
        }
        //horizontalInput = 1;

        //face forward
        //transform.forward = new Vector3(horizontalInput,0, Mathf.Abs(horizontalInput)-1);
    characterController.Move(transform.forward * moveSpeed * Time.deltaTime);

        if(IsGrounded() && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else 
        {
            //Add Gravity
        velocity.y += gravity*Time.deltaTime;
        }

        //characterController.Move ( new Vector3(0,0,horizontalInput*moveSpeed)*Time.deltaTime);

        if(IsGrounded()&& Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        //Vertical Velocity
        characterController.Move(velocity*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Rotator1"))
        {
              
              negativeRotate90 = true;
              rotated = false;
        }
        /*if(other.CompareTag("Rotator2"))
        {
            negativeRotate90 = true;
            rotated = false;
        }
        */
    }

    
    
}

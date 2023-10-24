using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem jumpParticle;
    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField]Transform groundCheck;
    [SerializeField]private float jumpHeight = 2f;
    private float gravity = -80f;
    private CharacterController characterController;

    public AudioSource jumpSound;
    
    private bool canRotate = true;
    private Vector3 velocity;

    void Awake()
    {
        
    }
    
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
        
     //transform.forward = new Vector3(horizontalInput,0, Mathf.Abs(horizontalInput)-1);
     //MOVE
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
        //THIS HERE IS JUMP!!!!!
        if(IsGrounded()&& Input.GetButtonDown("Jump"))
        {
            jumpSound.Play();
            CreateParticle();
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        //Vertical Velocity
        characterController.Move(velocity*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
      
      
        if(other.CompareTag("Rotator1") && canRotate)
        {
              
             transform.Rotate(Vector3.up,-90f);
             canRotate = false; 

             StartCoroutine(EnableRotationAfterDelay(.4f));
        }

        if(other.CompareTag("Rotator2") && canRotate)
        {
            transform.Rotate(Vector3.up,90f);
            canRotate = false;
            StartCoroutine(EnableRotationAfterDelay(.4f));
        }

    }

    void CreateParticle()
    {
        jumpParticle.Play();
    }
  
    private IEnumerator EnableRotationAfterDelay (float delay)
    {
        yield return new WaitForSeconds (delay);

        canRotate = true;
    }
}

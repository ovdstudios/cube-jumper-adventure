using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDeneme : MonoBehaviour
{
    public float jumpHeight = 5.0f;
    public float jumpDuration = 0.5f;
    [SerializeField] LayerMask groundLayers;
    [SerializeField]Transform groundCheck;
    
    private bool isJumping = false;
    private float jumpStartTime;
    private Vector3 initialPosition;


    

    //private float gravity = -50f;
     /*bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f,groundLayers);
    }
    */
    // Start is called before the first frame update
    void Start()
    {
         initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartJump();
        }

        // Handle the jump
        if (isJumping)
        {
            float timeSinceJumpStarted = Time.time - jumpStartTime;
            if (timeSinceJumpStarted < jumpDuration)
            {
                // Calculate vertical position during jump
                float jumpProgress = timeSinceJumpStarted / jumpDuration;
                float jumpHeightOffset = Mathf.Sin(jumpProgress * Mathf.PI) * jumpHeight;
                transform.position = initialPosition + Vector3.up * jumpHeightOffset;
            }
            else
            {
                // Jump finished, reset position
                transform.position = initialPosition;
                isJumping = false;
            }
        }
    
    }
    private void StartJump()
    {
        isJumping = true;
        jumpStartTime = Time.time;
    }
}

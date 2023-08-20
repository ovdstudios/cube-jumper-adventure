using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Router : MonoBehaviour
{
    PlayerController playerController;
    Rigidbody playerRb;
    public float counterMoveSpeed = -90;
    public float burstX = -1;
    Vector3 counterMoveDirection = new Vector3 (0,0,1);
    Vector3 boostX = new Vector3(.5f,0,0);

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag== "Player")
        {   
            playerRb.AddForce(counterMoveDirection*counterMoveSpeed,ForceMode.Impulse);
            playerRb.AddForce(boostX*burstX,ForceMode.Impulse);
            playerController.MoveLeftward();
        }
    }
}

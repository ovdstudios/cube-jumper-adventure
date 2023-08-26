using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 offset;
    Vector3 newPos;
    public GameObject player;

    void Start()
    {
        offset = player.transform.position - transform.position;
    }


    void Update()
    {
        newPos = transform.position;
        newPos.x = player.transform.position.x-offset.x;
        newPos.z = player.transform.position.z-offset.z;
        transform.position = newPos;
    }
}


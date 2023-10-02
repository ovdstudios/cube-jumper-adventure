using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Rigidbody _rb;
    Vector3 _leftRotation = new Vector3(0, -90, 0);
    Vector3 _rightRotation = new Vector3(0, 90, 0);
    private float _moveSpeed;
    Quaternion diff = Quaternion.identity;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RotatorLeft"))
        {
            diff = Quaternion.Euler(0, -90, 0);
        }

        if (other.CompareTag("RotatorRight"))
        {
            diff = Quaternion.Euler(0, 90, 0);
        }
        _rb.rotation *= diff;
        _rb.velocity = diff * _rb.velocity;
    }
}

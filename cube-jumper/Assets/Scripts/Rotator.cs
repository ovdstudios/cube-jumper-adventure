using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Rigidbody _rb;
    
    [SerializeField] private bool canRotate = true;
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
        if (other.CompareTag("RotatorLeft") && canRotate)
        {
            Debug.Log("Left Trigger");
            diff = Quaternion.Euler(0, -90, 0);
            canRotate = false;
            StartCoroutine(EnableRotationAfterDelay(.4f));
        }
        else if (other.CompareTag("RotatorRight") && canRotate)
        {


            {
                Debug.Log("Right Trigger");
                diff = Quaternion.Euler(0, 90, 0);
                canRotate = false;
                StartCoroutine(EnableRotationAfterDelay(.4f));
            }
        }
        else 
        {
         
            return;
        
        }


        _rb.rotation *= diff;
        _rb.velocity = diff * _rb.velocity;
    }

    private IEnumerator EnableRotationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canRotate = true;
        
    }
}

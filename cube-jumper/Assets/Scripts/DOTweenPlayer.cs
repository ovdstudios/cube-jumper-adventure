using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class DOTweenPlayer : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform baseGround;
    [SerializeField] CinemachineVirtualCamera camera;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(rb);
            camera.enabled = false;
            Vector3 jumpPosition =transform.InverseTransformPoint(transform.position + new Vector3(transform.localPosition.x + 8f, transform.localPosition.y - 12, transform.localPosition.z)) ;      
            transform.DOLocalJump(jumpPosition, 13, 1, .8f). SetEase(Ease.InSine);
            transform.DORotate(new Vector3(0f, 0f, -90f), 1f, RotateMode.LocalAxisAdd);
        }
    }
}

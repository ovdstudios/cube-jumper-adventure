using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailStopEmit : MonoBehaviour
{
    TrailRenderer trailRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 3)
        {
            trailRenderer.enabled = false;
        }
             
    }


}

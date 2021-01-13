using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private float maxSpeed = 4;
    private Rigidbody bubbleRb;
    void Start()
    {
        bubbleRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleRb.velocity.y > 0) 
        { 
            if (bubbleRb.velocity.magnitude > maxSpeed)
            {
            bubbleRb.velocity = bubbleRb.velocity.normalized * maxSpeed;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleRise : MonoBehaviour
{
    public Rigidbody bubbleRb;
    public float yRiseSpeed = 1;

    void Start()
    {
        bubbleRb = gameObject.GetComponent<Rigidbody>();
        
        //Custom rise speed code
        //Vector3 initRiseSpeed = new Vector3(0, yRiseSpeed, 0);   
        //bubbleRb.velocity = initRiseSpeed;
    }


    void Update()
    {
        
    }
}

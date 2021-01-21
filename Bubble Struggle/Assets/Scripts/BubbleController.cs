using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private float maxSpeed = 4;
    private Rigidbody bubbleRb;
    private SpawnManager spawnManager;
    void Start()
    {
        bubbleRb = gameObject.GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
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

        if (spawnManager.GetComponent<SpawnManager>().gameIsActive == false)
        {
            bubbleRb.velocity = Vector3.zero;
        }
    }
}

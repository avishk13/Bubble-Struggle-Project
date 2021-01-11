using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public float Speed = 10;
    private float bottomBound = -14;

    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * Speed);
        if(transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }                  
    }
}

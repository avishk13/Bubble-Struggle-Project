using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float xBounds = 10;
    

    void Start()
    {
        
    }

    void Update()
    {

        MoveLeft();
        MoveRight();

    }

    
    //Move right on key press
    void MoveRight()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < xBounds)
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }

        }
    }

    //Move left in key press
    void MoveLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -xBounds)
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }

        }
    }
}

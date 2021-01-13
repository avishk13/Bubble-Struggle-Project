using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float xBounds = 10;
    public GameObject spearPrefab;
    public bool spearExists;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spearExists)
        {
            FireSpear();
            spearExists = true;
        }

        MoveLeft();
        MoveRight();

        OnTriggerEnter(spearPrefab.GetComponent<Collider>());

        

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle" || other.tag == "Surface")
        {
            Destroy(other.gameObject);
        }
        
    }
    void FireSpear()
    {
        float offSet = -1;  
        Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y + offSet, transform.position.z);
        Instantiate(spearPrefab, spawnPosition, transform.rotation);
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

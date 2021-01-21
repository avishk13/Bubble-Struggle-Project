using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float xBounds = 10;
    public GameObject spearPrefab;
    public bool spearExists;
    private Vector3 characterScale;
    private float rightScale;
    private float leftScale;
    private SpawnManager spawnManager;





    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        characterScale = transform.localScale;
        rightScale = characterScale.x;
        leftScale = (characterScale.x) * -1;
        
    }

    void Update()
    {
        if (spawnManager.gameIsActive && !spawnManager.isFirstLaunchMenu)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !spearExists)
            {
                FireSpear();
                spearExists = true;

            }
            MoveLeft();
            MoveRight();
        }
        
        
        OnTriggerEnter(spearPrefab.GetComponent<Collider>());

        var movment = Input.GetAxis("Horizontal");

        

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
            characterScale.x = rightScale;
            transform.localScale = characterScale;
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
            characterScale.x = leftScale;
            transform.localScale = characterScale;
            if (transform.position.x > -xBounds)
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }

        }
    }
}

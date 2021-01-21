using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameObject[] bubbleObjects;
    public GameObject spearPrefab;
    //Determines the force at which bubbles are pushed when split
    private float yPushForce = -8;
    private float xPushForce = 5;
    //public ParticleSystem popParticle;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Collision manegment
    private void OnTriggerEnter(Collider other)
    {
        //Small bubble
        if (other.CompareTag("Projectile") && gameObject.CompareTag("SmallBubble"))
        {
            Destroy(other.gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().spearExists = false;
            //Instantiate(popParticle);
            //popParticle.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            //popParticle.Play();
            
        }

        //1Split Bubble
        if (other.CompareTag("Projectile") && gameObject.CompareTag("1SplitBubble"))
        {
            Destroy(other.gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().spearExists = false;
            //popParticle.Play();
            Destroy(gameObject);

            GameObject bubble1 = Instantiate(bubbleObjects[0], gameObject.transform.position, gameObject.transform.rotation);
            Rigidbody bubble1RB = bubble1.GetComponent<Rigidbody>();
            GameObject bubble2 = Instantiate(bubbleObjects[0], gameObject.transform.position, gameObject.transform.rotation);
            Rigidbody bubble2RB = bubble2.GetComponent<Rigidbody>();

            Vector3 pushDirectionLeft = new Vector3(xPushForce, yPushForce, 0);
            Vector3 pushDirectionRight = new Vector3(-xPushForce, yPushForce, 0);

            bubble1.transform.Translate(Vector3.right * 0.5f);
            bubble2.transform.Translate(Vector3.right * -0.5f);
            bubble1RB.AddForce(pushDirectionLeft, ForceMode.Impulse);
            bubble2RB.AddForce(pushDirectionRight, ForceMode.Impulse);
        }

        //2Split bubble
        if (other.CompareTag("Projectile") && gameObject.CompareTag("2SplitBubble"))
        {
            Destroy(other.gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().spearExists = false;
            //popParticle.Play();
            Destroy(gameObject);

            GameObject bubble1 = Instantiate(bubbleObjects[1], gameObject.transform.position, gameObject.transform.rotation);
            Rigidbody bubble1RB = bubble1.GetComponent<Rigidbody>();
            GameObject bubble2 = Instantiate(bubbleObjects[1], gameObject.transform.position, gameObject.transform.rotation);
            Rigidbody bubble2RB = bubble2.GetComponent<Rigidbody>();

            Vector3 pushDirectionLeft = new Vector3(xPushForce, yPushForce, 0);
            Vector3 pushDirectionRight = new Vector3(-xPushForce, yPushForce, 0);

            bubble1.transform.Translate(Vector3.right * 0.5f);
            bubble2.transform.Translate(Vector3.right * -0.5f);
            bubble1RB.AddForce(pushDirectionLeft, ForceMode.Impulse);
            bubble2RB.AddForce(pushDirectionRight, ForceMode.Impulse);
        }

        //Bubble bounces off walls
        if (other.CompareTag("Wall"))
        {
            Rigidbody bubbleRB = gameObject.GetComponent<Rigidbody>();
            float bubbleRBVelX = bubbleRB.velocity.x * -1;
            float bubbleRBVely = bubbleRB.velocity.y;
            float bubbleRBVelz = bubbleRB.velocity.z;

            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(bubbleRBVelX, bubbleRBVely, bubbleRBVelz);
        }

        if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Surface"))
        {
            Debug.Log("Game Over!");
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>().gameIsActive = false;
        }
    }
}


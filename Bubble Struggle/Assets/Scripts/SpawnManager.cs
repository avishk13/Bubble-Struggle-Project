using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] bubbleObjects;
    private float lowerBound = -12;
    private float zPosition = -1.5f;
    private float smallBubbleDelay = 1;
    private float oneSplitBubbleDelay = 1;
    private float twoSplitBubbleDelay = 15;


    void Start()
    {
        InvokeRepeating("randomSpawnSmallBubble", smallBubbleDelay, 2);
        InvokeRepeating("randomSpawn1SplitBubble", oneSplitBubbleDelay, 3);
        InvokeRepeating("randomSpawn2SplitBubble", twoSplitBubbleDelay, 5);
    }


    void Update()
    {

        

    }

    void randomSpawnSmallBubble()
    {
        GameObject bubble = bubbleObjects[0];
        float randomX = Random.Range(-14.0f, 14.0f);
        Vector3 randomSpawn = new Vector3(randomX, lowerBound, zPosition);
        Instantiate(bubble, randomSpawn, bubble.transform.rotation);

    }

    void randomSpawn1SplitBubble()
    {
        GameObject bubble = bubbleObjects[1];
        float randomX = Random.Range(-14.0f, 14.0f);
        Vector3 randomSpawn = new Vector3(randomX, lowerBound, zPosition);
        Instantiate(bubble, randomSpawn, bubble.transform.rotation);

    }

    void randomSpawn2SplitBubble()
    {
        GameObject bubble = bubbleObjects[2];
        float randomX = Random.Range(-14.0f, 14.0f);
        Vector3 randomSpawn = new Vector3(randomX, lowerBound, zPosition);
        Instantiate(bubble, randomSpawn, bubble.transform.rotation);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Rigidbody bubbleRB = gameObject.GetComponent<Rigidbody>();
            float bubbleRBVelX = bubbleRB.velocity.x * -1;
            float bubbleRBVely = bubbleRB.velocity.y;
            float bubbleRBVelz = bubbleRB.velocity.z;

            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(bubbleRBVelX, bubbleRBVely, bubbleRBVelz);
            Debug.Log("got collision");
        }
    }
}

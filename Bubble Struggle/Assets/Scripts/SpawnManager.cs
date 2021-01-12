using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] bubbleObjects;
    private float lowerBound = -12;
    private float smallBubbleDelay = 1;
    private float oneSplitBubbleDelay = 5;
    private float twoSplitBubbleDelay = 15;


    void Start()
    {
        InvokeRepeating("randomSpawnSmallBubble", smallBubbleDelay, 3);
        InvokeRepeating("randomSpawn1SplitBubble", oneSplitBubbleDelay, 4);
        InvokeRepeating("randomSpawn2SplitBubble", twoSplitBubbleDelay, 7);
    }


    void Update()
    {

        

    }

    void randomSpawnSmallBubble()
    {
        GameObject bubble = bubbleObjects[0];
        float randomX = Random.Range(-14.0f, 14.0f);
        Vector3 randomSpawn = new Vector3(randomX, lowerBound, 0);
        Instantiate(bubble, randomSpawn, bubble.transform.rotation);

    }

    void randomSpawn1SplitBubble()
    {
        GameObject bubble = bubbleObjects[1];
        float randomX = Random.Range(-14.0f, 14.0f);
        Vector3 randomSpawn = new Vector3(randomX, lowerBound, 0);
        Instantiate(bubble, randomSpawn, bubble.transform.rotation);

    }

    void randomSpawn2SplitBubble()
    {
        GameObject bubble = bubbleObjects[2];
        float randomX = Random.Range(-14.0f, 14.0f);
        Vector3 randomSpawn = new Vector3(randomX, lowerBound, 0);
        Instantiate(bubble, randomSpawn, bubble.transform.rotation);

    }

    
}

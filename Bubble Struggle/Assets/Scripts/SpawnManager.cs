using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] bubbleObjects;
    private float lowerBound = -12;
    private float zPosition = -1.5f;
    private float smallBubbleDelay = 1;
    private float oneSplitBubbleDelay = 1;
    private float twoSplitBubbleDelay = 15;
    private float spawnRate;
    public TextMeshProUGUI timerText;
    public int timerInt;
    public bool gameIsActive;
    public bool isFirstLaunchMenu;
    public GameObject gameOverText;
    public GameObject tryAgainText;
    public GameObject quitText;
    public GameObject startMenu;


    void Start()
    {
        gameIsActive = true;
        isFirstLaunchMenu = true;
        timerText.text = "Time: " + timerInt;
        spawnRate = 5;
        //StartGame();
    }


    void Update()
    {
        if (!gameIsActive)
        {
            StopGame();
        }

 
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

    IEnumerator AddToTimer ()
    {
        while (gameIsActive)
        {
            yield return new WaitForSeconds(1);
            timerInt++;         
            timerText.text = "Time: " + timerInt;          
        }
    }


    public void StartGame(int difficulty)
    //public void StartGame()
    {
        gameIsActive = true;
        spawnRate /= difficulty;
        InvokeRepeating("randomSpawnSmallBubble", smallBubbleDelay, spawnRate);
        InvokeRepeating("randomSpawn1SplitBubble", oneSplitBubbleDelay, spawnRate * (spawnRate / 2));
        InvokeRepeating("randomSpawn2SplitBubble", twoSplitBubbleDelay, spawnRate * 2.5f);
        //InvokeRepeating("randomSpawnSmallBubble", smallBubbleDelay, 2);
        //InvokeRepeating("randomSpawn1SplitBubble", oneSplitBubbleDelay, 3);
        //InvokeRepeating("randomSpawn2SplitBubble", twoSplitBubbleDelay, 5);
        timerInt = 0;
        StartCoroutine(AddToTimer());
        startMenu.SetActive(false);
        isFirstLaunchMenu = false;
    }


    void StopGame()
    {
        CancelInvoke();
        gameIsActive = false;
        gameOverText.SetActive(true);
        tryAgainText.SetActive(true);
        quitText.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

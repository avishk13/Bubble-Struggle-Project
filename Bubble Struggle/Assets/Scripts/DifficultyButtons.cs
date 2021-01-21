using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{

    private Button button;
    private SpawnManager spawnManager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetDifficulty()
    {
        //spawnManager.StartGame(difficulty);
        spawnManager.StartGame();
    }
}

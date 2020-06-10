using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameStarted { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartGame()
    {
        gameStarted = true;
        
    }
    public void RestartGame()
    {
        Invoke("Load", 1f);
    }
    public void Load()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    public PlayerController mainCharacter;
    public static GameManager instance = null;
    [SerializeField]private bool canStartGame = false;
    [SerializeField] private bool gamePaused;
    private int currentScene;
    public bool GamePaused => gamePaused;
    public bool CanStartGame => canStartGame;
    //public SpawnWhenEmpty fullLevelIndicator;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        mainCharacter?.gameObject.SetActive(canStartGame);
        if (Input.GetKeyDown(KeyCode.O))
        {
            NextLevel(3);
        }        
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextLevel(2);
        }


    }
    public void IsLevelGenerated(bool hasGenerated)
    {
        if (hasGenerated)
        {
            canStartGame = true;
        }
    }
    public void Pause(bool isPaused)
    {
        gamePaused = isPaused;
        
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        currentScene = 1;
    }
    public void Victory()
    {
        SceneManager.LoadScene(3);
        currentScene = 3;
    }
    public void NextLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        currentScene = 0;
    }
}

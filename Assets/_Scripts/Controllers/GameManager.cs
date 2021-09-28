using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public PlayerController mainCharacter;
    public static GameManager instance = null;
    [SerializeField]private bool canStartGame = false;
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
        mainCharacter.gameObject.SetActive(canStartGame);

    }
    public void IsLevelGenerated(bool hasGenerated)
    {
        if (hasGenerated)
        {
            canStartGame = true;
        }
    }
}

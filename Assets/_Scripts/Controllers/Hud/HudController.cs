using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HudController : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    [SerializeField] private PlayerController player;
    [SerializeField] private LifeHud lifeManager;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button backToMenuButton;
    private void Start()
    {
        backToMenuButton?.onClick.AddListener(BackToMenue);
        exitButton?.onClick.AddListener(Application.Quit);
        playButton?.onClick.AddListener(StartGame);
    }

    private void Update()
    {
            lifeManager?.ShowLife(lifeBar);
    }

    private void StartGame()
    {
        GameManager.instance.StartGame();
    }
    private void BackToMenue()
    {
        GameManager.instance.LoadMenu();
    }
}

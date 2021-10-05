using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[RequireComponent(typeof(LifeHud))]
public class HudController : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PlayerController player;
    [SerializeField] private LifeHud lifeManager;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button playButton;
    private int actualAmmo;
    private void Start()
    {
        exitButton?.onClick.AddListener(Application.Quit);
        playButton?.onClick.AddListener(StartGame);
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameManager.instance.mainCharacter;

        }
        else
        {
            lifeManager?.ShowLife(lifeBar);
        }
    }

    private void StartGame()
    {
        GameManager.instance.StartGame();
    }
}

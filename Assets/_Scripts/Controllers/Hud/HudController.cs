using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[RequireComponent(typeof (LifeHud),typeof (ScoreManager))]
public class HudController : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PlayerController player;
    [SerializeField] private LifeHud ammoManager;
    [SerializeField] private ScoreManager scoreManager;
    private int actualAmmo;
    private void Start()
    {
    }

    private void Update()
    {
        if(player == null)
        {
        player = GameManager.instance.mainCharacter;

        }
        else
        {
            ammoManager.ShowLife(lifeBar);
            scoreManager?.ShowScore(scoreText);
        }
    }
}

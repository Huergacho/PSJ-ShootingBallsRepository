using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof (AmmoManager),typeof (ScoreManager))]
public class HudController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PlayerController player;
    [SerializeField] private AmmoManager ammoManager;
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
            ammoManager.ShowAmmo(ammoText);
            scoreManager.ShowScore(scoreText);
        }
    }
}

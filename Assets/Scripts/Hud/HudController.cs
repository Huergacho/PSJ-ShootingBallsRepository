using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HudController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private PlayerController player;
    private int actualAmmo;
    private void Start()
    {
    }
    private void Update()
    {
        if(player == null)
       player = GameManager.instance.mainCharacter;
        actualAmmo = player.GetActualAmmo();
        ammoText.text = $"Ammo = {actualAmmo}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class AmmoManager : MonoBehaviour
{
    [SerializeField]private int actualAmmo;

    private void Start()
    {
        PlayerController.ammoQuantity += recieveActualAmmo;
    }
    public void ShowAmmo(TextMeshProUGUI ammoText)
    {
       
        ammoText.text = $"Ammo = {actualAmmo}";
    }
    public void recieveActualAmmo(int currentAmmo)
    {
        actualAmmo = currentAmmo;
    }
}

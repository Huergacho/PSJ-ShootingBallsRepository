using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
public class LifeHud : MonoBehaviour
{
    [SerializeField]private float actualLife;

    private void Start()
    {
        PlayerController.lifeUpdate += recieveActualLife;
    }
    public void ShowLife(Image lifeBar)
    {

        lifeBar.fillAmount = actualLife / 100;
    }
    public void recieveActualLife(float currentLife)
    {
        actualLife = currentLife;
    }
}

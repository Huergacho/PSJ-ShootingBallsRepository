using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menue;
    [SerializeField] private Button resumeButton;
    private void Start()
    {
        resumeButton?.onClick.AddListener(Resume);
    }
    private void Update()
    {
        CheckPause();
    }
    private void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menue.SetActive(true);
            GameManager.instance.Pause(true);
        }
    }
    private void Resume()
    {
        menue.SetActive(false);
        GameManager.instance.Pause(false);
    }
}

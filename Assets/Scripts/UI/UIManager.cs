using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public ScoreCounter scoreCounter = null; 
    public Button btPausePlay;

    private MyPlayer player = null;
    public GameObject pauseCanvas;
    public bool isPlay()
    {
        if (pauseCanvas != null)
        {
            return !pauseCanvas.activeSelf;
        }
        return false;
    }


    private void Start()
    {
        player = FindAnyObjectByType<MyPlayer>();
        if (btPausePlay != null)
        {
            btPausePlay.onClick.AddListener(ButtonClick);
        }
    }

    private void Update()
    { 
        scoreCounter.SetText(player.getScore());
    }


    void ButtonClick()
    {
        Time.timeScale = 0f; // Mettre en pause le temps

        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(true);
        }
    }
}

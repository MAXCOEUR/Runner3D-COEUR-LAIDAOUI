using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPause : MonoBehaviour 
{
    public TextMeshProUGUI scoreCounter = null;
    public TextMeshProUGUI jetonCounter = null;
    public Button btResume;
    public Button btQuit;

    public GameObject pauseCanvas;

    private MyPlayer player = null;

    private void Start()
    {
        player = FindAnyObjectByType<MyPlayer>();

        Time.timeScale = 0f;
        if (btResume != null)
        {
            btResume.onClick.AddListener(btResumeClick);
        }
        if (btQuit != null)
        {
            btQuit.onClick.AddListener(btQuitClick);
        }
    }

    private void Update()
    {
        scoreCounter.text = $"score: {player.getScore()}";
        jetonCounter.text = $"jeton: {player.getJeton()}";
    }


    void btResumeClick()
    {
        Time.timeScale = 1f;
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
        }
    }
    void btQuitClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}

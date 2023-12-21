using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIDeath : MonoBehaviour
{
    public TextMeshProUGUI scoreCounter = null;
    public TextMeshProUGUI jetonCounter = null;
    public Button btRestart;
    public Button btQuit;

    public GameObject pauseCanvas;

    private MyPlayer player = null;

    private void Start()
    {
        player = FindAnyObjectByType<MyPlayer>();

        Time.timeScale = 0f;
        if (btRestart != null)
        {
            btRestart.onClick.AddListener(btRestartClick);
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


    void btRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void btQuitClick()
    {
        SceneManager.LoadScene("MenuStart");
    }
}

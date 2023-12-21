using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuStart : Singleton<UIMenuStart>
{
    public Button btPlay;
    public GameObject canvas;

    private void Start()
    {
        if (btPlay != null)
        {
            btPlay.onClick.AddListener(btPlayClick);
        }
        Time.timeScale = 0f;
        setActive(true);
    }

    public void setActive(bool active)
    {
        Time.timeScale = 0f;
        if (canvas != null)
        {
            canvas.SetActive(active);
        }
    }

    private void Update()
    {
    }

    public void start()
    {
        setActive(false);
        Time.timeScale = 1f;
    }


    void btPlayClick()
    {
        start();
    }
}

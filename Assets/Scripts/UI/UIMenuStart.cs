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
    }

    private void Update()
    {
    }


    void btPlayClick()
    {
        SceneManager.LoadScene("MainSceneWithMenu");
    }
}

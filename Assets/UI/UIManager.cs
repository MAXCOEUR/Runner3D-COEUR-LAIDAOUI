using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : Singleton<UIManager>
{
    public ScoreCounter scoreCounter = null;

    private MyPlayer player = null;

    private void Start()
    {
        player = FindAnyObjectByType<MyPlayer>();
    }

    private void Update()
    { 
        scoreCounter.SetText(player.getScore());
    }
}

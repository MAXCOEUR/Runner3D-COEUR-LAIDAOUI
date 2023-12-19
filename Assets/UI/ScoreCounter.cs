using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText = null;

    public void SetText(int score)
    {
        counterText.text = $"Score: {score}";
    }
}

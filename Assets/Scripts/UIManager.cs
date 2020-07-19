using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;

    private void Start()
    {
        EventDispatcher.Listen("ScoreUpdated", ScoreUpdated);
    }

    private void ScoreUpdated(object[] args)
    {
        int score = (int) args[0];
        ScoreText.text = $"Score : {score}";
    }
}

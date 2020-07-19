using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    private void Start()
    {
        EventDispatcher.Listen("EnemyDied", EnemyDied);
    }

    private void EnemyDied(object[] args)
    {
        score++;
        EventDispatcher.Dispatch("ScoreUpdated", score);
        // Debug.Log($"Score : {score}");
    }
}

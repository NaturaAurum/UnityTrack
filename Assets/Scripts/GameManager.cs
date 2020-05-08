using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    Ready,
    Play,
    Over,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get; 
        private set;
    }

    public int PlayerScore = 0;

    private GameState currentGameState = GameState.Ready;

    public Text ScoreText;
    public Text GameOverScoreText;

    public GameObject GameStartGroup;
    public GameObject GameOverGroup;
    public GameObject GamePlayGroup;

    public GameState CurrentGameState
    {
        get => currentGameState;
        set
        {
            if (currentGameState != value)
            {
                currentGameState = value;
                EventDispatcher.Send("GameStateChanged", value);
                
                GameStartGroup.SetActive(value == GameState.Ready);
                GameOverGroup.SetActive(value == GameState.Over);
                GamePlayGroup.SetActive(value == GameState.Play);
            }
        }
    }
    
    private void Awake()
    {
        Instance = this;
        EventDispatcher.Listen("PlayerDied", OnPlayerDied);
        EventDispatcher.Listen("EnemyDied", OnEnemyDied);
        EventDispatcher.Listen("AsteroidDied", OnAsteroidDied);
        
        GameOverGroup.SetActive(false);
        GamePlayGroup.SetActive(false);
    }

    private void OnDestroy()
    {
        EventDispatcher.Remove("PlayerDied", OnPlayerDied);
        EventDispatcher.Remove("EnemyDied", OnEnemyDied);
        EventDispatcher.Remove("AsteroidDied", OnAsteroidDied);
    }

    private void OnPlayerDied(params object[] args)
    {
        CurrentGameState = GameState.Over;
        GameOverScoreText.text = $"Your Score : {PlayerScore}";
    }

    private void OnEnemyDied(params object[] args)
    {
        PlayerScore++;
        ScoreText.text = $"Score : {PlayerScore}";
        Debug.Log($"Player Score Increased! : {PlayerScore}");
    }

    private void OnAsteroidDied(params object[] args)
    {
        PlayerScore++;
        ScoreText.text = $"Score : {PlayerScore}";
        Debug.Log($"Player Score Increased! : {PlayerScore}");
    }

    private void Update()
    {
        if (CurrentGameState == GameState.Ready && Input.anyKey)
        {
            CurrentGameState = GameState.Play;
        }

        if (CurrentGameState == GameState.Over && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

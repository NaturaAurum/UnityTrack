using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AsteroidGenerator : MonoBehaviour
{

    public GameObject[] AsteroidPrefabs = null;

    public float AsteroidGenerateTime = 0;
    private float asteroidGenerateTimer = 0;

    public Transform[] Points;

    private bool gameStarted = false;
    
#if UNITY_EDITOR
    public void AutoConnect()
    {
        Points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; ++i)
        {
            Points[i] = transform.GetChild(i);
        }
    }
#endif
    
    
    // Start is called before the first frame update
    void Start()
    {
        EventDispatcher.Listen("GameStateChanged", OnGameStateChanged);
    }

    private void OnDestroy()
    {
        EventDispatcher.Remove("GameStateChanged", OnGameStateChanged);
    }

    private void OnGameStateChanged(params object[] args)
    {
        GameState state = (GameState) args[0];
        if (state == GameState.Play)
        {
            gameStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            return;
        }
        asteroidGenerateTimer += Time.deltaTime;
        if (asteroidGenerateTimer >= AsteroidGenerateTime)
        {
            Generate();
            asteroidGenerateTimer = 0;
        }
    }

    private void Generate()
    {
        int randomIndex = Random.Range(0, Points.Length);
        int asteroidRandomIndex = Random.Range(0, AsteroidPrefabs.Length);
        Instantiate(AsteroidPrefabs[asteroidRandomIndex], Points[randomIndex].position, 
            Quaternion.Euler(90, 0, 180));
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(AsteroidGenerator))]
public class AsteroidGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Auto Connect"))
        {
            (target as AsteroidGenerator).AutoConnect();
        }
    }
}
#endif
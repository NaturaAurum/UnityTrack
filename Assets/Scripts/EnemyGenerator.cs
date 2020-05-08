using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnemyGenerator : MonoBehaviour
{

    public GameObject EnemyPrefab = null;

    public float EnemyGenerateTime = 0;
    private float enemyGenerateTimer = 0;

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
        enemyGenerateTimer += Time.deltaTime;
        if (enemyGenerateTimer >= EnemyGenerateTime)
        {
            Generate();
            enemyGenerateTimer = 0;
        }
    }

    private void Generate()
    {
        int randomIndex = Random.Range(0, Points.Length);
        
        Instantiate(EnemyPrefab, Points[randomIndex].position, 
            Quaternion.Euler(90, 0, 180));
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(EnemyGenerator))]
public class EnemyGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Auto Connect"))
        {
            (target as EnemyGenerator).AutoConnect();
        }
    }
}
#endif


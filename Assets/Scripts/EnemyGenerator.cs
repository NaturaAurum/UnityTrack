using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab = null;
    public Transform[] Points = null;

    public float GenerateTime = 1f;
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= GenerateTime)
        {
            GenerateEnemy();
            timer = 0f;
        }
    }

    private void GenerateEnemy()
    {
        int randomIndex = Random.Range(0, Points.Length);
        Transform randomPoint = Points[randomIndex];
        Instantiate(EnemyPrefab, randomPoint.position, Quaternion.identity);
    }
}

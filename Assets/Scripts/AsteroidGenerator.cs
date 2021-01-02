using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject[] AsteroidPrefabs = null;
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
            GenerateAsteroid();
            timer = 0;
        }
    }

    private void GenerateAsteroid()
    {
        int objectRandomIndex = Random.Range(0, AsteroidPrefabs.Length);
        GameObject targetPrefab = AsteroidPrefabs[objectRandomIndex];
        int pointRandomIndex = Random.Range(0, Points.Length);
        Transform targetPoint = Points[pointRandomIndex];
        Instantiate(targetPrefab, targetPoint.position, Quaternion.identity);
    }
}

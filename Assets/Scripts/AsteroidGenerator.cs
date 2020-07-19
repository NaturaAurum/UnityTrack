using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public Transform[] generatePoints = null;

    public GameObject[] AsteroidPrefabs = null;

    public float AsteroidGenerateTime = 1f;
    private float asteroidGenerateTimer = 0f;

    private void GenerateAsteroid()
    {
        /*
         * Random.Range를 사용해서 point와 prefab을 랜덤으로 가져오도록
         * index를 가지고 온다음 각 배열에서 뽑아주고 Instantiate
         */
        int asteroidIndex = Random.Range(0, AsteroidPrefabs.Length);
        int pointIndex = Random.Range(0, generatePoints.Length);

        GameObject asteroidPrefab = AsteroidPrefabs[asteroidIndex];
        Transform point = generatePoints[pointIndex];

        Instantiate(asteroidPrefab, point.position, Quaternion.identity);
    }
    
    // Update is called once per frame
    void Update()
    {
        asteroidGenerateTimer += Time.deltaTime;
        if (asteroidGenerateTimer >= AsteroidGenerateTime)
        {
            GenerateAsteroid();
            asteroidGenerateTimer = 0;
        }
    }
}

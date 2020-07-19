using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float BulletSpeed = 10f;

    private Vector3 bulletDirection = Vector3.zero;

    public void SetBulletDirection(Vector3 direction)
    {
        bulletDirection = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        // // 내가 PlayerBullet이라면
        // if (gameObject.tag == "PlayerBullet")
        // {
        //     // Enemy나 Asteroid에 맞으면 파괴
        //     if (other.tag == "Enemy" || other.tag == "Asteroid")
        //     {
        //         Destroy(gameObject);
        //     }
        // }
        // // 내가 EnemyBullet 이라면=
        // else if (gameObject.tag == "EnemyBullet")
        // {
        //     // Player에 맞으면 파괴
        //     if (other.tag == "Player")
        //     {
        //         Destroy(gameObject);
        //     }
        // }

        // 윗 내용을 이렇게 줄여볼 수 있다
        bool isPlayerBulletDestroy =
            gameObject.tag == "PlayerBullet" && (other.tag == "Enemy" || other.tag == "Asteroid");
        bool isEnemyBulletDestroy = gameObject.tag == "EnemyBullet" && other.tag == "Player";

        if (isPlayerBulletDestroy || isEnemyBulletDestroy)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDirection * BulletSpeed * Time.deltaTime;
    }
}

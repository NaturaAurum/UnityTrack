using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed = 10f;

    public GameObject BulletPrefab;

    public float BulletGenerateTime = 1f;
    private float bulletGenerateTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void GenerateBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        Bullet bulletController = bullet.GetComponent<Bullet>();
        bulletController.SetBulletDirection(Vector3.down);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * MoveSpeed * Time.deltaTime;

        bulletGenerateTimer += Time.deltaTime;

        if (bulletGenerateTimer >= BulletGenerateTime)
        {
            GenerateBullet();
            bulletGenerateTimer = 0f;
        }
    }
}

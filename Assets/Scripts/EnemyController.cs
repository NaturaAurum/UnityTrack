using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    
    public GameObject BulletPrefab = null;

    private void GenerateBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetBulletDirection(Vector3.down);
    }

    public float BulletGenerateTime = 1f;
    private float bulletGenerateTimer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float EnemySpeed = 0;

    public float FireTerm = 0;

    private float fireTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if(fireTimer > FireTerm)
        {
            // TODO : 총알 쏘자
            GameObject bulletObj = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bulletObj.tag = "EnemyBullet";
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.BulletDirection = Vector3.down;
            fireTimer = 0f;
        }

        transform.position += Vector3.down * Time.deltaTime * EnemySpeed;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            EventDispatcher.Send("EnemyDied");
        }
    }
}

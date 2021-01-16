using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 15f;
    private Vector3 bulletDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetBulletDirection(Vector3 direction)
    {
        this.bulletDirection = direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDirection * BulletSpeed * Time.deltaTime;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector3 BulletDirection = Vector3.zero;

    public float BulletSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += BulletDirection * Time.deltaTime * BulletSpeed;
    }
}

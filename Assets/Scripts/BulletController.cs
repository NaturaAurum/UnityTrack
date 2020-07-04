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

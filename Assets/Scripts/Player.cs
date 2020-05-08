using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab = null;
    public float PlayerSpeed = 0;

    private Rigidbody rigidbody = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
//        if(Input.GetKey(KeyCode.A))
//        {
////            transform.position += Vector3.left * Time.deltaTime * PlayerSpeed;
//            rigidbody.AddForce(Vector3.left * PlayerSpeed);
//        }
//
//        if(Input.GetKey(KeyCode.D))
//        {
////            transform.position += Vector3.right * Time.deltaTime * PlayerSpeed;
//            rigidbody.AddForce(Vector3.right * PlayerSpeed);
//        }

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        rigidbody.AddForce(Vector3.up * vertical * PlayerSpeed);
        rigidbody.AddForce(Vector3.right * horizontal * PlayerSpeed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bulletObj = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bulletObj.tag = "PlayerBullet";
        }
    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("EnemyBullet") ||
//                collision.gameObject.CompareTag("Asteroid") || 
//                    collision.gameObject.CompareTag("Enemy"))
//        {
//            Destroy(gameObject)
//        }
//    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet") ||
            other.CompareTag("Asteroid") ||
            other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            EventDispatcher.Send("PlayerDied");
        }
    }
}

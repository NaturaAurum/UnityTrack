using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 총알에 맞으면 파괴
        if (other.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * MoveSpeed * Time.deltaTime;
    }
}

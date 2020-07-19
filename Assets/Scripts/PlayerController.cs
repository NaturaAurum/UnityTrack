using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 10f;

    public GameObject BulletPrefab = null;

    public bool Invincible = true;

    private void GenerateBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        // 플레이어가 생성하는 Bullet은 PlayerBullet tag를 가져야한다.
        bullet.tag = "PlayerBullet";
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetBulletDirection(Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Invincible)
            return;
        // 충돌한 오브젝트의 tag가 PlayerBullet이 아닌 다른 오브젝트 일 경우 파.괴.한.다
        if (other.tag != "PlayerBullet")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // W나 방향키 위쪽을 누르면 1
        // S나 방향키 아래쪽을 누르면 -1
        float vertical = Input.GetAxis("Vertical");
        // A나 방향키 왼쪽을 누르면 -1
        // D나 방향키 오른쪽을 누르면 1 
        float horizontal = Input.GetAxis("Horizontal");
        
        // vector3 * scala -> scala = float, int
        // x * scala, y * scala, z * scala
        // Vector3.up => (0, 1, 0)
        // vertical 값을 곱해주니까
        // 0 * vertical, 1 * vertical, 0 * vertical
        //
        
        transform.position += Vector3.up * vertical * MoveSpeed * Time.deltaTime;
        transform.position += Vector3.right * horizontal * MoveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateBullet();
        }


        // 특정 키를 입력했을 때 움직이도록 하는 코드
        // if (Input.GetKey(KeyCode.W))
        // {
        //     // a+=b => a = a + b
        //     transform.position += Vector3.up * MoveSpeed * Time.deltaTime;
        // } 
        // if (Input.GetKey(KeyCode.A))
        // {
        //     transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        // } 
        // if (Input.GetKey(KeyCode.S))
        // {
        //     transform.position += Vector3.down * MoveSpeed * Time.deltaTime;
        // } 
        // if (Input.GetKey(KeyCode.D))
        // {
        //     transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        // }
    }
}

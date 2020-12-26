using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 밑에 if 문들은 아래 GetAxis로 대체 가능함.

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.position += new Vector3(horizontal, vertical, 0) * MoveSpeed * Time.deltaTime;

        // if (Input.GetKey(KeyCode.W))
        // {
        //     transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;
        // }
        //
        // if (Input.GetKey(KeyCode.S))
        // {
        //     transform.position += Vector3.back * MoveSpeed * Time.deltaTime;
        // }
        //
        // if (Input.GetKey(KeyCode.A))
        // {
        //     transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        // }
        //
        // if (Input.GetKey(KeyCode.D))
        // {
        //     transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        // }
    }
}

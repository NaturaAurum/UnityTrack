using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


// public class Player
// {
//     private int hp = 50;
//     private int power = 100;
//
//     public void Attack()
//     {
//         int power = 10;
//         this.power = power;
//         Damage(power);
//     }
//
//     public void Damage(int damage)
//     {
//         hp -= damage;
//     }
// }


/// <summary>
/// 테스트 코드
/// 필요할때 쓰면 됨.
/// </summary>
public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player();

        // int age = 23;
        // var height = 192.5f;
        // var name = "Taewoo Kim";
        //
        // Debug.Log(age);
        // Debug.Log(height);
        // Debug.Log(name);

        // int sum = 0;
        // for (int i = 1; i <= 10; i++)
        // {
        //     sum += i;
        // }
        //
        // Debug.Log(sum);

        // int[] arr = {83, 99, 52, 93, 15};
        // float sum = 0;
        // for (int i = 0; i < arr.Length; i++)
        // {
        //     sum += arr[i];
        // }
        //
        // // /, %
        // Debug.Log(sum / arr.Length);

        int a = 14;
        int b = 20;

        Debug.Log(Plus(a, b));
        Debug.Log(Minus(a, b));
        Debug.Log(Multiple(a, b));
        Debug.Log(Devide(a, b));
    }

    int Plus(int a, int b)
    {
        return a + b;
    }

    int Minus(int a, int b)
    {
        return a - b;
    }

    int Multiple(int a, int b)
    {
        return a * b;
    }

    int Devide(int a, int b)
    {
        return a / b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

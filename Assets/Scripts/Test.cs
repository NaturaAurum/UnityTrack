using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int hp = 0;
    private int power = 0;

    public void Initialize(int hp, int power)
    {
        this.hp = hp;
        this.power = power;
    }
}


public class Test : MonoBehaviour
{
    int age = 23;
    float height = 154.2f;
    string name = "김태우";

    int frame = 0;
    int targetFrame = 30;

    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player();
        player.Initialize(100, 200);

        //Debug.Log(age);
        //Debug.Log(height);
        //Debug.Log(name);

        //string str1 = "asdasd";
        //int num = 123;
        //string message = str1 + num;

        //Debug.Log(message);

        //string str2 = "dsadsa";
        //string str3 = "ftgd";
        //string message2 = str2 + str3;

        //Debug.Log(message2);
        //int sum = 0;
        //for (int index = 1; index < 11; ++index)
        //{
        //    // sum = sum + index;
        //    sum += index;
        //}

        //Debug.Log(sum);

        //int[] array = { 83, 99, 52, 93, 15 };
        //int[] array = new int[5];
        //array[0] = 83;
        //array[1] = 99;
        //array[2] = 52;
        //array[3] = 93;
        //array[4] = 15;

        //float sum = 0; // 합을 저장할 변수
        //float avg = 0; // 평균 저장할 변수

        //for (int i = 0; i < array.Length; ++i)
        //{
        //    sum += array[i];
        //}

        //avg = sum / array.Length;

        //Debug.Log(avg);

        Debug.Log(Plus(2, 5));
        Debug.Log(Minus(5, 2));
        Debug.Log(Multiple(2, 5));
        Debug.Log(Devide(5, 2));
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

    public Vector3 vec1 = Vector3.forward;
    public Vector3 vec2 = Vector3.left;
    public Vector3 p1 = Vector3.zero; // plus
    public Vector3 p2 = Vector3.zero; // minus 

    public bool ShowP1 = true;
    public bool ShowP2 = false;
    
    private void OnDrawGizmos()
    {
        p1 = vec1 + vec2;
        p2 = vec1 - vec2;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + vec1);
        // Gizmos.color = Color.red * Color.white;
        // Gizmos.DrawLine(transform.position + vec1, transform.position + vec1 + vec2);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + vec2);

        if (ShowP1)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, transform.position + p1);
        }

        if (ShowP2)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, p2);
        }
    }
}

using UnityEngine;
using System.Collections;

public class VariableScript : MonoBehaviour
{
    //переменная скорости которая юудет задавать скорость движения и генерации
    public static float speed = 1;

    void Start()
    {
        InvokeRepeating("UpSpeed", 0f, 10f);
    }

    void UpSpeed()
    {
        speed += 3f;
        //Debug.Log(speed);
    }

    void Update()
    {
        //Debug.Log(speed);
    }
}

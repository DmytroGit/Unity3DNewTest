using UnityEngine;
using System.Collections;

public class MoveObjectScript : MonoBehaviour
{
    //скорость объектов движущихся на камеру создавая иллюзию движения камеры вперед
    public static float speed;

    void Start()
    {
        //уничтожения объектов через 10 секунд после генерации
        //через это время они уже за камерой и их не видно
        Destroy(gameObject, 10);
    }

    void Update()
    {
        speed = VariableScript.speed;
        
        //движение объекта вперед 
        transform.Translate(transform.forward * Time.deltaTime * speed);

    }

    public float UpMove()
    {
        return speed = VariableScript.speed;
    }
}

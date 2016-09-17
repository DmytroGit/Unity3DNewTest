using UnityEngine;
using System.Collections;
using System;

public class CreaterObject : MonoBehaviour
{
    //переменая массива для объектов на обочине  (перетаскиваем сюда объекты в Unity3d)
    public GameObject[] Object;

    //переменная для дороги (перетаскиваем сюда дорогу в Unity3d)
    public GameObject Road;
    

    //частота срабатывания таймера - котрый вызывает метод генерации обектов
    float SpamerTime = MoveObjectScript.speed;

    //переменная рандома - потом потребуется для генерации случайного числа
    System.Random random = new System.Random();

    //для поворота Y
    System.Random randomRotation = new System.Random();

    //позиции смещения на дороге
    int[] array =new int[] {-4, -3, -2, 2, 3, 4 };  

    //=============для генерации объектов===========================

    int countLine = 6;//Количество рядов объектов
    // номер индекса в массиве объекта 
    int numOdject;
    //переменная нового объекта
    GameObject newObject;
    //координаты нового объекта
    Vector3 newPos;

    float oldSpeed = MoveObjectScript.speed;

    void Start()
    {
        //SpamerTime = SpeedObject.speed;
        //таймер вызывающий метод генерации объектов
        InvokeRepeating("SpamerObjectTimer", 0, SpamerTime);
    }
    //TODO както привязать скорость генерации к скорости перемещения
    void Update()
    {
        //сравниваем старую скорость с новой если изменилась перезапускаем с новой скоростью
        if (oldSpeed != MoveObjectScript.speed)
        {
            SpamerTime = 1 / MoveObjectScript.speed;
            CancelInvoke("SpamerObjectTimer");
            InvokeRepeating("SpamerObjectTimer", 0, SpamerTime);
            oldSpeed = MoveObjectScript.speed;
        }

        SpamerTime = 1f / MoveObjectScript.speed;
        //Debug.Log("Creater" + VariableScript.speed + " - " + SpamerTime);
    }

    //метод генерации объектов
    void SpamerObjectTimer()
    {
        //=======================Генерация дороги=======================
        newObject = Instantiate(Road, transform.position, Quaternion.identity) as GameObject;
        //==============================================================

        
        //=======================Генерация объектов на обочине==========
        for (int i = 0; i < countLine; i++)
        {
            //рандомный выбор объекта - генерим случайное число исходя из размера массива
            numOdject = random.Next(Object.Length);

            //создание рандомной позиции для нового объекта
            newPos = new Vector3(
            transform.position.x + array[i]/*меняем это для разброса по рядам*/,
            transform.position.y,
            transform.position.z);


            //создание объекта + поворот
            newObject = Instantiate(Object[numOdject], newPos, Quaternion.Euler(0,0,randomRotation.Next(0, 360))) as GameObject;
            //transform.rotation = Quaternion.Euler(45, 45, 45);
        }
    }
}

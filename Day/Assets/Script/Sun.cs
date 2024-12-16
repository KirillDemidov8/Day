using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sun : MonoBehaviour, IDayTime
{
    public int dayTime { get; set; }
    public int nowSecond { get; set; }
    public float speed { get; set; } = 0.5f; // скорость
    public Vector3 targetSun { get; set; } // позиция солнца в верхней точке




    void Start()
    {
        Botstraper.Instance.Timer.OnSecondPassed += GetTimeNow;
        dayTime = Botstraper.Instance.DayTime;
        speed *= dayTime / 4;
    }

    public void GetTimeNow(int second)
    {
        nowSecond = second;
        Debug.Log(second);


    }

    public void Update()
    {
        if (nowSecond == 0)
        {
            NewDay();
        }
        else if (nowSecond <= dayTime / 4)
        {
            Morning();
        }
        else if (nowSecond <= dayTime / 2)
        {
            Day();
        }
        else if (nowSecond <= 3 * (dayTime / 4))
        {
            Evening();
        }
        else if (nowSecond <= dayTime)
        {
            Night();
        }
    }


    public void NewDay()
    {
        Debug.Log($"{this.name}: NewDay");
        transform.position = new Vector3(-8, -3, 0);
    }

    public void Morning()
    {
        Debug.Log($"{this.name}: Morning");
        targetSun = new Vector3(0, 3, 0);
        Move();
    }

    public void Day()
    {
        Debug.Log($"{this.name}: Day");
    }

    public void Evening()
    {
        Debug.Log($"{this.name}: Evening");
        targetSun = new Vector3(8, -5, 0);

        Move();
    }
    public void Night()
    {
        Debug.Log($"{this.name}: Night");
    }

    private void Move()
    {
        Vector3 direction = targetSun - transform.position;

        // Если объект не достиг цели, продолжаем движение
        if (direction.magnitude > 0.1f)
        {
            // Нормализуем направление и перемещаем объект
            float step = speed * Time.deltaTime; // Расчет шага
            transform.position = Vector3.MoveTowards(transform.position, targetSun, step);
            Debug.Log("go");
        }
    }



}

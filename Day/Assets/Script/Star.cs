using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private SpriteRenderer sprite;
    public int dayTime { get; set; }
    public int nowSecond { get; set; }
    public float speed { get; set; } = 3f; // скорость

    private float transitionStartTime; // Время начала перехода
    private bool isTransitioning = false; // Флаг, указывающий, происходит ли переход
    private float duration; // Длительность перехода

    private Color colorStart;
    private Color colorDay;
    private Color spriteColor;

    void Start()
    {
        Botstraper.Instance.Timer.OnSecondPassed += GetTimeNow;
        dayTime = Botstraper.Instance.DayTime;
        sprite = GetComponent<SpriteRenderer>();
        // Преобразование шестнадцатеричного кода в цвет
        colorStart = new Color(1, 1, 1, 1);
        colorDay = new Color(1, 1, 1, 0);
        StartTransition();
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
        sprite.color = colorStart;
    }
    public void Morning()
    {
        Debug.Log($"{this.name}: Morning");
        ColorChange(colorStart, colorDay);
    }

    public void Day()
    {
        Debug.Log($"{this.name}: Day");
    }

    public void Evening()
    {
        Debug.Log($"{this.name}: Evening");
        StartOpasity();
    }

    public void Night()
    {
        Debug.Log($"{this.name}: Night");
    }
    void ColorChange(Color startColor, Color endColor)
    {
        if (isTransitioning)
        {
            float elapsedTime = Time.time - transitionStartTime;
            Debug.Log("start color");
            if (elapsedTime < duration)
            {
                Debug.Log("start111 color");
                // Вычисляем интерполяцию цвета
                sprite.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
            }
            else
            {
                // Устанавливаем конечный цвет и останавливаем переход
                sprite.color = endColor;
                isTransitioning = false;
                Debug.Log("end color");
            }
        }
    }

    public void StartTransition()
    {
        // Задаем длительность в зависимости от speedFactor
        duration = dayTime / speed; // Например, 10 секунд для полного перехода при speedFactor = 1
        transitionStartTime = Time.time; // Запоминаем время начала перехода
        isTransitioning = true; // Устанавливаем флаг перехода
    }

    public void StartOpasity()
    {
        spriteColor = sprite.color;
        if (spriteColor.a < 1f) // Проверяем, не достигли ли полной непрозрачности
        {
            spriteColor.a += (dayTime / speed) * Time.deltaTime * 0.02f; // Изменяем альфа-канал
            spriteColor.a = Mathf.Clamp(spriteColor.a, 0f, 1f); // Ограничиваем значение от 0 до 1
            sprite.color = spriteColor;
        }
    }
}

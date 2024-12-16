using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using UnityEngine;

public class Sky : MonoBehaviour, IDayTime
{
    private SpriteRenderer sprite;
    public int dayTime { get; set; }
    public int nowSecond { get; set; }
    public float speed { get; set; } = 1.5f; // ��������� ��������

    private float transitionStartTime; // ����� ������ ��������
    private bool isTransitioning = false; // ����, �����������, ���������� �� �������
    private float duration; // ������������ ��������

    private Color colorStart;
    private Color colorDay;
    void Start()
    {
        Botstraper.Instance.Timer.OnSecondPassed += GetTimeNow;
        dayTime = Botstraper.Instance.DayTime;
        sprite = GetComponent<SpriteRenderer>();
        // �������������� ������������������ ���� � ����
        ColorUtility.TryParseHtmlString("#1E284F", out colorStart);
        ColorUtility.TryParseHtmlString("#5675E9", out colorDay);
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
        ColorChange(colorDay, colorStart);
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

            if (elapsedTime < duration)
            {
                // ��������� ������������ �����
                sprite.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
            }
            else
            {
                // ������������� �������� ���� � ������������� �������
                sprite.color = endColor;
                isTransitioning = false;
            }
        }
    }

    public void StartTransition()
    {
        // ������ ������������ � ����������� �� speedFactor
        duration = dayTime / speed; // ��������, 10 ������ ��� ������� �������� ��� speedFactor = 1
        transitionStartTime = Time.time; // ���������� ����� ������ ��������
        isTransitioning = true; // ������������� ���� ��������
    }
}

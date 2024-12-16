using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class Botstraper : MonoBehaviour
{

    private Timer timer = new Timer();
    public Timer Timer { get { return timer; } }



    [SerializeField] private int  dayTime;
    public int DayTime { get { return dayTime; } }

    

    public static Botstraper Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        dayTime = 20;
        _instance = this;
    }
    static private Botstraper _instance;

    void Start()
    {
        StartCoroutine(timer.Clock(DayTime));
    }

   
    void Update()
    {
        
    }
}

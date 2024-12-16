using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Timer : MonoBehaviour, ITimer
{
    public delegate void SecondPassedHandler(int second);
    public event ITimer.SecondPassedHandler OnSecondPassed;

    

    public IEnumerator Clock(int dayTime)
    {
        for (int i = 0; i <= dayTime; i++)
        {
            yield return new WaitForSeconds(1);
            OnSecondPassed?.Invoke(i);
        }
    }

   




}

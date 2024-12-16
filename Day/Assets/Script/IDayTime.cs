
using System;

public interface IDayTime
{
    public int dayTime { get; set; } //общее время четырех фаз
    public int nowSecond { get; set; } //текущее время 

    public float speed { get; set; } // Скорость перемещения


    public void GetTimeNow(int second);

    void Update();
    

    public void NewDay();
    public void Morning();
    public void Day();
    public void Evening();
    public void Night();
}

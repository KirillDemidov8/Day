
using System;

public interface IDayTime
{
    public int dayTime { get; set; } //����� ����� ������� ���
    public int nowSecond { get; set; } //������� ����� 

    public float speed { get; set; } // �������� �����������


    public void GetTimeNow(int second);

    void Update();
    

    public void NewDay();
    public void Morning();
    public void Day();
    public void Evening();
    public void Night();
}

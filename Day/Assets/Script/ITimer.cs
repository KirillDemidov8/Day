using System.Collections;

public interface ITimer
{
    public delegate void SecondPassedHandler(int second);
    public event SecondPassedHandler OnSecondPassed;

    public IEnumerator Clock(int dayTime);
}

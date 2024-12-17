using System;

public class Stopwatch
{
    public delegate void StopwatchEventHandler(string message);
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;
    
    private TimeSpan timeElapsed;
    private bool isRunning;

    public Stopwatch()
    {
        timeElapsed = TimeSpan.Zero;
        isRunning = false;
    }

    public TimeSpan TimeElapsed
    {
        get { return timeElapsed; }
    }

    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            OnStarted?.Invoke("Stopwatch Started!");
        }
    }

    public void Stop()
    {
        if (isRunning)
        {
            isRunning = false;
            OnStopped?.Invoke($"Stopwatch Stopped at {timeElapsed:mm\\:ss\\:fff}");
        }
    }

    public void Reset()
    {
        isRunning = false;
        timeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
    }

    public void Tick()
    {
        if (isRunning)
        {
            timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
        }
    }
}

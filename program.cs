using System;
using System.Threading;

class Program
{
    static void Main()
    {
        var stopwatch = new Stopwatch();
        stopwatch.OnStarted += OnStartedHandler;
        stopwatch.OnStopped += OnStoppedHandler;
        stopwatch.OnReset += OnResetHandler;

        Console.Clear();
        Console.WriteLine("Stopwatch Application");
        Console.WriteLine("**********************");
        Console.WriteLine("Input 'S' to start the stopwatch.");
        Console.WriteLine("Input 'T' to stop the stopwatch.");
        Console.WriteLine("Input 'R' to reset the stopwatch.");
        Console.WriteLine("Input 'Esc' to exit the program.");
        Console.WriteLine("**********************");

        bool running = false;
        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;

                if (key == ConsoleKey.S && !running)
                {
                    stopwatch.Start();
                    running = true;
                    Console.Clear();
                    Console.WriteLine("Stopwatch started...");
                    Console.WriteLine("Press 'T' to stop, 'R' to reset, 'Esc' to exit.");
                }
                else if (key == ConsoleKey.T && running)
                {
                    stopwatch.Stop();
                    running = false;
                    Console.Clear();
                    Console.WriteLine("Press 'S' to start again, 'R' to reset, 'Esc' to exit.");
                }
                else if (key == ConsoleKey.R)
                {
                    stopwatch.Reset();
                    running = false;
                    Console.Clear();
                    Console.WriteLine("Press 'S' to start the stopwatch.");
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            if (running)
            {
                stopwatch.Tick();
                Console.Clear();
                Console.WriteLine("Stopwatch running...");
                Console.WriteLine($"Elapsed time: {stopwatch.TimeElapsed:mm\\:ss\\:fff}");
                Console.WriteLine("Press 'T' to stop, 'R' to reset, 'Esc' to exit.");
                Thread.Sleep(1000);
            }
        }
    }

    private static void OnStartedHandler(string message)
    {
        Console.WriteLine(message);
        Thread.Sleep(1000);
    }

    private static void OnStoppedHandler(string message)
    {
        Console.WriteLine(message);
        Thread.Sleep(1000);
    }

    private static void OnResetHandler(string message)
    {
        Console.WriteLine(message);
        Thread.Sleep(1000);
    }
}

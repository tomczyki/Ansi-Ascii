/*
Author: Ignacy Tomczyk
Project Name: Gallery
File Name: Program.cs
Purpose: Display animated ASCII art
Pseudocode:
    Ask for FPS
    Ask for animation
    Resize console window
    Create timer with interval that matches FPS
    On timer tick,
        Print frame from index
        Increment index
*/

using Selector;
using Timer = System.Timers.Timer;

namespace Gallery;

internal class Program
{
    private static Timer _timer;

    private static AsciiAnimation _animation;

    private static void Main(string[] args)
    {
        Console.WriteLine("What should be the FPS (recommended is 30)?");

        int fps;
        while (!int.TryParse(Console.ReadLine(), out fps))
        {
            Console.WriteLine("Invalid input.");
        }

        _animation = ConsoleSelector.QuestionSelect(
            "Which piece of animated ASCII art would you like to view?",
            "Fire (by CameronFoxly: https://ascii-motion.app/community/project/44870d67-36e2-4e2a-a6de-96eb077c81eb)",
            "Matrix Rain (by CameronFoxly: https://ascii-motion.app/community/project/24f61412-b970-4538-b050-e1d0e6534ad6)",
            "Rain Drops (by CameronFoxly: https://ascii-motion.app/community/project/1fd54c3c-7c5b-4984-b35d-dd0d46bb5505)")
            switch
        {
            0 => new Fire(),
            1 => new MatrixRain(),
            2 => new RainDrops(),
            _ => throw new InvalidOperationException()
        };

        Console.CursorVisible = false;
        Console.Clear();

        int prevWidth = Console.WindowWidth, prevHeight = Console.WindowHeight;
        Console.CancelKeyPress += (s, e) =>
        {
            Console.Write($"\e[8;{prevHeight};{prevWidth}t");
            Console.CursorVisible = true;
        };

        _animation.ResizeConsole();
        _animation.PrintNextFrame();

        _timer = new(TimeSpan.FromSeconds(1.0 / fps)) { AutoReset = false };
        _timer.Elapsed += (s, e) =>
        {
            _animation.PrintNextFrame();
            _timer.Start();
        };
        _timer.Start();

        while (true)
        {
            Console.ReadKey(intercept: true);
        }
    }
}

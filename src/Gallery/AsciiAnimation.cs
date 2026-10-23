using System.Drawing;

namespace Gallery;

public abstract class AsciiAnimation
{
    public abstract Size Size { get; }

    public abstract string[] Frames { get; }

    private int _frame;

    public void PrintNextFrame()
    {
        Console.SetCursorPosition(left: 0, top: 0);

        Console.WriteLine(Frames[_frame++]);
        Console.WriteLine();

        if (_frame == Frames.Length)
        {
            _frame = 0;
        }
    }

    public void ResizeConsole()
    {
        Console.Write($"\e[8;{Size.Height};{Size.Width}t");
    }
}

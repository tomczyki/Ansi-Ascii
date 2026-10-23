namespace Selector;

public static class ConsoleSelector
{
    public static int QuestionSelect(string question, params string[] options)
    {
        Console.WriteLine();
        Console.WriteLine(question);

        if (options.Length == 0)
        {
            return -1;
        }

        int top = Console.CursorTop;
        int index = 0;

        Console.CursorVisible = false;

        WriteSelectedLine(options[0]);
        for (int i = 1; i < options.Length; ++i)
        {
            Console.WriteLine(options[i]);
        }

        while (true)
        {
            ConsoleKeyInfo info = Console.ReadKey();

            if (info.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (info.Key is not (ConsoleKey.UpArrow or ConsoleKey.DownArrow))
            {
                continue;
            }

            int change = info.Key == ConsoleKey.UpArrow ? -1 : 1;
            if (index + change >= options.Length)
            {
                change = -(options.Length - 1);
            }
            else if (index + change < 0)
            {
                change = options.Length - 1;
            }

            // Write previously selected option normally
            Console.SetCursorPosition(left: 0, top + index);
            Console.WriteLine(options[index]);

            index += change;

            // Highlight newly selected option
            Console.SetCursorPosition(left: 0, top + index);
            WriteSelectedLine(options[index]);
        }

        // Place cursor after options
        Console.SetCursorPosition(left: 0, top + options.Length);
        Console.CursorVisible = true;

        return index;

        static void WriteSelectedLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value);
            Console.ResetColor();
        }
    }
}

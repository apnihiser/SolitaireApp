using static System.Console;

public class Menu
{
    private int _selectionIndex;
    private string[] _options;
    private string _prompt;

    public Menu(string prompt, string[] options)
    {
        _selectionIndex = 0;
        _prompt = prompt;
        _options = options;
    }

    public void DrawOptions()
    {
        string prefix;
        WriteLine(_prompt);

        for (int i = 0; i < _options.Length; i++)
        {
            if(i == _selectionIndex)
            {
                prefix = "*";
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.Black;
                WriteLine($"{prefix} << {_options[i]} >>");
            }
            else
            {
                prefix = " ";
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.White;
                WriteLine($"{prefix} << {_options[i]} >>");
            }
            ResetColor();
        }
    }

    public int RunMenu()
    {
        ConsoleKey keyPressed;

        do
        {
            Clear();
            DrawOptions();

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if(keyPressed == ConsoleKey.UpArrow)
            {
                _selectionIndex--;
                if(_selectionIndex == -1)
                {
                    _selectionIndex = _options.Length - 1;
                }
            }
            else if(keyPressed == ConsoleKey.DownArrow)
            {
                _selectionIndex++;
                if (_selectionIndex == _options.Length)
                {
                    _selectionIndex = 0;
                }
            }

        } while (keyPressed != ConsoleKey.Enter);

        return _selectionIndex;
    }
}
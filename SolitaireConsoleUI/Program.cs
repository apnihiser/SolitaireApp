using SolitaireConsoleUI;
using SolitaireConsoleUI.Settings;
using System.Runtime.InteropServices;
using static System.Console;

Title = "CLI Solitaire";
CursorVisible = false;

//WindowHeight = DisplaySettings.ScreenHeight;
//WindowWidth = DisplaySettings.ScreenWidth;


string prompt = MenuSettings.PROMPT;
string[] options = MenuSettings.OPTIONS;
int selection;
Menu menu = new(prompt, options);

do
{
    selection = menu.RunMenu();

    switch (selection)
    {
        case 0:
            Game game = new();
            game.Start();
            break;
        case 1:
            Clear();
            WriteLine(MenuSettings.INSTRUCTIONS);
            WriteLine("\nPress any key to return to the main menu.");
            break;
        case 2:
            Clear();
            WriteLine(MenuSettings.ABOUT_APP);
            WriteLine("\nPress any key to return to the main menu.");
            break;
        case 3:
            Game.Exit();
            break;
    }

    ReadKey(true);

} while (true);




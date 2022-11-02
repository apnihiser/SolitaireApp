using SolitaireLibrary;
using static ConsoleUI.Helper.LogicHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class KeyboardInput
    {
        public static int GenerateMenuChoice(RenderEngine renderEngine, Board board)
        {
            ConsoleKey keyPressed;

            do
            {
                Console.Clear();
                renderEngine.RenderScreen();

                ConsoleKeyInfo key = Console.ReadKey(true);
                keyPressed = key.Key;

                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        if (IsBotLeftPile(board.SelectedIndex))
                        {
                            board.SelectedIndex -= 6;
                        }
                        else if (IsBotRightPile(board.SelectedIndex))
                        {
                            board.SelectedIndex -= 7;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (IsTopLeftPile(board.SelectedIndex))
                        {
                            board.SelectedIndex += 6;
                        }
                        if (IsTopRightPile(board.SelectedIndex))
                        {
                            board.SelectedIndex += 7;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (board.SelectedIndex == 5)
                        {
                            board.SelectedIndex = 0;
                        }
                        else
                        {
                            board.SelectedIndex++;
                            if (board.SelectedIndex == board.CardPiles.Count())
                            {
                                board.SelectedIndex = 6;
                            }
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (board.SelectedIndex == 6)
                        {
                            board.SelectedIndex = 12;
                        }
                        else
                        {
                            board.SelectedIndex--;
                            if (board.SelectedIndex == -1)
                            {
                                board.SelectedIndex = 5;
                            }
                        }
                        break;
                }

            } while (keyPressed != ConsoleKey.Enter);

            return board.SelectedIndex;
        }
    }
}

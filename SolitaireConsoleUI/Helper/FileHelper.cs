using SolitaireLibrary.Enums;
using static SolitaireConsoleUI.Settings.DisplaySettings;

namespace SolitaireConsoleUI.Helper
{
    public static class FileHelper
    {
        public static string[,] GetCardBack()
        {
            return ParseTextIntoGrid(CARD_BACK_PATH);
        }

        public static string[,] GetCardFace(CardSuit suit, CardValue value)
        {
            int enumInt = (int)value;
            string[,] grid = ParseTextIntoGrid(CARD_FACE_PATH);
            char[] charArray = ((int)value).ToString().ToCharArray();

            if (enumInt != 10)
            {
                if (enumInt > 1 && enumInt < 11)
                {
                    grid[1, 1] = ((int)value).ToString();
                    grid[1, 2] = EnumToUnicode(suit);
                    grid[3, 4] = EnumToUnicode(suit);
                    grid[5, 6] = ((int)value).ToString();
                    grid[5, 7] = EnumToUnicode(suit);
                }
                else
                {
                    grid[1, 1] = value.ToString();
                    grid[1, 2] = EnumToUnicode(suit);
                    grid[3, 4] = EnumToUnicode(suit);
                    grid[5, 6] = value.ToString();
                    grid[5, 7] = EnumToUnicode(suit);
                }
            }
            else
            {
                grid[1, 1] = charArray[0].ToString();
                grid[1, 2] = charArray[1].ToString();
                grid[1, 3] = EnumToUnicode(suit);
                grid[3, 4] = EnumToUnicode(suit);
                grid[5, 5] = charArray[0].ToString();
                grid[5, 6] = charArray[1].ToString();
                grid[5, 7] = EnumToUnicode(suit);
            }

            return grid;
        }

        private static string EnumToUnicode(CardSuit suit)
        {
            string output = "";

            switch (suit)
            {
                case CardSuit.Heart:
                    output = "\u2665";
                    break;
                case CardSuit.Diamond:
                    output = "\u2666";
                    break;
                case CardSuit.Club:
                    output = "\u2663";
                    break;
                case CardSuit.Spade:
                    output = "\u2660";
                    break;
                default:
                    break;
            }

            return output;
        }

        public static string[,] GetCursorUpImage()
        {
            return ParseTextIntoGrid(CURSOR_UP_PATH);
        }

        public static string[,] GetCursorDownImage()
        {
            return ParseTextIntoGrid(CURSOR_DOWN_PATH);
        }

        public static string[,] GetPileImage()
        {
            return ParseTextIntoGrid(PILE_ASSET_PATH);
        }

        public static string[,] GetBoardGrid()
        {
            return ParseTextIntoGrid(BOARD_ASSET_PATH);
        }

        public static string[,] ParseTextIntoGrid(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows = lines.Length;
            int cols = firstLine.Length;
            string[,] grid = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < cols; x++)
                {
                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }
            }

            return grid;
        }
    }
}



namespace ConsoleUI.Helper
{
    public class LogicHelper
    {

        public static bool IsTopLeftPile(int index)
        {
            if (index >= 0 && index <= 3)
            {
                return true;
            }
            return false;
        }

        public static bool IsTopRightPile(int index)
        {
            if (index == 4 || index == 5)
            {
                return true;
            }
            return false;
        }

        public static bool IsBotLeftPile(int index)
        {
            if (index >= 6 && index <= 10)
            {
                return true;
            }
            return false;
        }

        public static bool IsBotRightPile(int index)
        {
            if (index >= 11 && index <= 12)
            {
                return true;
            }
            return false;
        }
    }
}

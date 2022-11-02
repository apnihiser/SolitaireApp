
namespace SolitaireConsoleUI.Settings
{
    public static class DisplaySettings
    {
        // File Locations
        public const string CARD_BACK_PATH = "./Assets/CardBack.txt";
        public const string CARD_FACE_PATH = "./Assets/CardFace.txt";
        public const string CURSOR_UP_PATH = "./Assets/UpCursor.txt";
        public const string CURSOR_DOWN_PATH = "./Assets/DownCursor.txt";
        public const string PILE_ASSET_PATH = "./Assets/PileAscii.txt";
        public const string BOARD_ASSET_PATH = "./Assets/BoardAscii.txt";

        // Screen Resolution
        public static readonly int ScreenWidth = 84;
        public static readonly int ScreenHeight = 60;
        public const int SCREEN_TOP_ROW = 0;
        public const int SCREEN_LEFT_COL = 0;

        // Base Gameboard placement
        public const int GAMEBOARD_ROW_ANCHOR = SCREEN_TOP_ROW + 1;
        public const int GAMEBOARD_COL_ANCHOR = SCREEN_LEFT_COL + 3;

        // Relative Pile placement to Gameboard
        public const int PILE_ROW_ANCHOR = GAMEBOARD_ROW_ANCHOR + 2;
        public const int PILE_COL_ANCHOR = GAMEBOARD_COL_ANCHOR + 4;
        public const int PILE_HORIZONTAL_MARGIN = 10;

        // Foundation Pile
        public const int FP_ROW = PILE_ROW_ANCHOR;
        public const int FP_COL = PILE_COL_ANCHOR;

        // Waste Pile
        public const int WP_ROW = PILE_ROW_ANCHOR;
        public const int WP_COL = PILE_COL_ANCHOR + 50;

        // Stock Pile
        public const int SP_ROW = PILE_ROW_ANCHOR;
        public const int SP_COL = PILE_COL_ANCHOR + 60;

        // Tableau Pile
        public const int TP_ROW = PILE_ROW_ANCHOR + 10;
        public const int TP_COL = PILE_COL_ANCHOR;

        // Card Display Setting
        public const int VERTICAL_OFFSET = 3;

        // Cursor Display Settings
        public const int CURSOR_UP_OFFSET = 7;
        public const int CURSOR_DOWN_OFFSET = -2;
    }
}

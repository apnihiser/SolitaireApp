using SolitaireLibrary;
using SolitaireLibrary.Enums;
using static SolitaireConsoleUI.Helper.FileHelper;
using static SolitaireConsoleUI.Settings.DisplaySettings;


namespace ConsoleUI
{
    public class RenderEngine
    {
        private Board _board { get; set; }
        private CardPile[] _foundationDisplayPiles { get; set; }
        private CardPile _wasteDisplayPile { get; set; }
        private CardPile _stockDisplayPile { get; set; }
        private CardPile[] _tableauDisplayPiles { get; set; }

        public RenderEngine(Board board, CardPile[] foundation, CardPile waste, CardPile stock, CardPile[] tableau)
        {
            _board = board;

            _foundationDisplayPiles = foundation;

            _wasteDisplayPile = waste;

            _stockDisplayPile = stock;

            _tableauDisplayPiles = tableau;
        }

        public void RenderScreen()
        {
            Console.Clear();
            RenderBoard(GAMEBOARD_ROW_ANCHOR, GAMEBOARD_COL_ANCHOR);
            RenderPiles(FP_ROW, FP_COL, PILE_HORIZONTAL_MARGIN, _foundationDisplayPiles);
            RenderPile(WP_ROW, WP_COL, _wasteDisplayPile);
            RenderPile(SP_ROW, SP_COL, _stockDisplayPile);
            RenderPiles(TP_ROW, TP_COL, PILE_HORIZONTAL_MARGIN, _tableauDisplayPiles);
            RenderCursor(_board);
        }

        public static void RenderCursor(Board board)
        {
            int selectedIndex = board.SelectedIndex;
            CardPile card = board.CardPiles[board.SelectedIndex];

            if (selectedIndex >= 0 && selectedIndex < 6)
            {
                DrawToConsole(card.Y + CURSOR_UP_OFFSET, card.X, GetCursorUpImage());
            }
            else if (selectedIndex < 13)
            {
                DrawToConsole(card.Y + CURSOR_DOWN_OFFSET, card.X, GetCursorDownImage());
            }
        }

        public static void RenderCards(int originY, int originX, int verticalOffset, CardPile pile)
        {
            string[,] cardGrid = GetCardBack();

            foreach (var card in pile.CardStack)
            {
                switch (pile.Type)
                {
                    case PileType.Foundation:
                    case PileType.Waste:
                        cardGrid = GetCardFace(card.Suit, card.Value);
                        break;

                    case PileType.Stock:
                        break;

                    case PileType.Tableau:
                        if (card == pile.BottomCard)
                        {
                            if (card == pile.TopCard || card.IsVisible == true)
                            {
                                cardGrid = GetCardFace(card.Suit, card.Value);
                                originY += 0;
                            }
                            else
                            {
                                originY += 0;
                            }
                            
                        }
                        else if (card.IsVisible == true || card == pile.TopCard)
                        {
                            cardGrid = GetCardFace(card.Suit, card.Value);
                            originY += verticalOffset;
                        }
                        else
                        {
                            originY += verticalOffset;
                        }
                        break;
                }

                DrawToConsole(originY, originX, cardGrid);
            }
        }

        public static void RenderPiles(int originY, int originX, int horizontalMargin, CardPile[] piles)
        {
            foreach (var pile in piles)
            {
                RenderPile(originY, originX, pile);

                originX += horizontalMargin;
            }
        }

        public static void RenderPile(int originY, int originX, CardPile pile)
        {
            pile.Y = originY;
            pile.X = originX;

            DrawToConsole(originY, originX, GetPileImage());

            if (pile.CardStack?.Count > 0)
            {
                RenderCards(originY, originX, VERTICAL_OFFSET, pile);
            }
        }

        public static void RenderBoard(int originY, int originX)
        {
            DrawToConsole(originY, originX, GetBoardGrid());
        }

        public static void DrawToConsole(int originY, int originX, string[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    string element = grid[y, x];

                    Console.SetCursorPosition(originX + x, originY + y);
                    if (element == "\u2665" || element == "\u2666")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if(element == "\u2663" || element == "\u2660")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.WriteLine(element);
                    Console.ResetColor();
                }
            }
        }
    }
}

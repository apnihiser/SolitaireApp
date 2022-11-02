using static SolitaireLibrary.Actions;
using static SolitaireLibrary.GameSettings;
using static ConsoleUI.Helper.LogicHelper;
using SolitaireLibrary;
using ConsoleUI;
using SolitaireConsoleUI.Settings;

namespace SolitaireConsoleUI
{
    public class Game
    {
        private Deck _deck { get; set; }
        private Board _board { get; set; }
        private DateTime _dateTime { get; set; }
        private int _scoreDisplay { get; set; }
        private bool _isGameOver { get; set; } = false;
        private CardPile[] _foundationDisplayPiles { get; set; }
        private CardPile _wasteDisplayPile { get; set; }
        private CardPile _stockDisplayPile { get; set; }
        private CardPile[] _tableauDisplayPiles { get; set; }
        private RenderEngine _re;

        public Game()
        {
            _board = new Board();
            _deck = new Deck();

            _foundationDisplayPiles = new CardPile[4]
            {
                _board.CardPiles[0],
                _board.CardPiles[1],
                _board.CardPiles[2],
                _board.CardPiles[3],
            };

            _wasteDisplayPile = _board.CardPiles[4];

            _stockDisplayPile = _board.CardPiles[5];

            _tableauDisplayPiles = new CardPile[7]
            {
                _board.CardPiles[6],
                _board.CardPiles[7],
                _board.CardPiles[8],
                _board.CardPiles[9],
                _board.CardPiles[10],
                _board.CardPiles[11],
                _board.CardPiles[12]
            };

            _re = new RenderEngine(_board, _foundationDisplayPiles, _wasteDisplayPile, _stockDisplayPile, _tableauDisplayPiles);
        }

        public void Start()
        {
            //Console.WindowHeight = DisplaySettings.ScreenHeight;
            //Console.WindowWidth = DisplaySettings.ScreenWidth;

            DealCardsToBoard();

            do
            {
                Console.CursorVisible = false;
                int sendingPileIndex = KeyboardInput.GenerateMenuChoice(_re, _board);

                if(sendingPileIndex == STOCK_PILE_INDEX)
                {
                    if (_board.CardPiles[STOCK_PILE_INDEX].CardStack.Count == 0)
                    {
                        MoveRemainingCardsToStockPile(_board.CardPiles[WASTE_PILE_INDEX].CardStack, _board.CardPiles[STOCK_PILE_INDEX]);
                    }
                    else
                    {
                        TransferTopCard(_board.CardPiles[STOCK_PILE_INDEX], _board.CardPiles[WASTE_PILE_INDEX]);
                    }
                }
                else
                {
                    int receivingPileIndex = KeyboardInput.GenerateMenuChoice(_re, _board);

                    if (IsValidMove(sendingPileIndex, receivingPileIndex, _board))
                    {                       
                        TransferTopCard(_board.CardPiles[sendingPileIndex], _board.CardPiles[receivingPileIndex]);
                    }
                }

                IsGameWon(_foundationDisplayPiles);

            } while (_isGameOver == false);
        }

        private void DealCardsToBoard()
        {
            _deck.Cards = CreateDeck();
            _deck.Cards = ShuffleDeck(_deck.Cards);
            DealCardsToTableauPiles(_tableauDisplayPiles, _deck.Cards);
            SetTableauTopCardsToVisible(_tableauDisplayPiles);
            MoveRemainingCardsToStockPile(_deck.Cards, _stockDisplayPile);
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}

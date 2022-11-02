using SolitaireLibrary.Enums;
using static SolitaireLibrary.GameSettings;

namespace SolitaireLibrary
{
    public static class Actions
    {
        // Game Win
        public static bool IsGameWon(CardPile[] foundationPiles)
        {
            bool output = true;

            foreach(var pile in foundationPiles)
            {
                if(pile.CardStack.Count < 11 )
                {
                    output = false;
                }
            }

            return output;
        }

        // Board Library
        public static void DealCardsToTableauPiles(CardPile[] tableauPiles, List<PlayingCard> deck)
        {
            for (int i = FIRST_TABLEAU_PILE; i < LAST_TABLEAU_PILE; i++)
            {
                for (int j = FIRST_TABLEAU_PILE; j < LAST_TABLEAU_PILE; j++)
                {
                    if (j <= i)
                    {
                        tableauPiles[i].AddTopCard(DealACard(deck));
                    }
                }
            }
        }

        public static void SetTableauTopCardsToVisible(CardPile[] tableauPiles)
        {
            foreach (var pile in tableauPiles)
            {
                if(pile.TopCard is not null)
                {
                    pile.TopCard.IsVisible = true;
                }
            }
        }

        public static void MoveRemainingCardsToStockPile(List<PlayingCard> remainingCards, CardPile emptyPile)
        {
            try
            {
                for (int i = remainingCards.Count - 1; i >= 0; i--)
                {
                    PlayingCard card = remainingCards[i];
                    emptyPile.AddTopCard(card);
                }

                remainingCards.Clear();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void TransferTopCard(CardPile sendingPile, CardPile receivingPile)
        {
            try
            {
                if (sendingPile.CardStack.Count > 0 && sendingPile.TopCard is not null)
                {
                    sendingPile.TopCard.IsVisible = true;

                    if(receivingPile.CardStack.Count > 0 && receivingPile.TopCard is not null)
                    {
                        receivingPile.TopCard.IsVisible = true;
                    }

                    receivingPile.AddTopCard(sendingPile.TopCard);
                    sendingPile.RemoveTopCard();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Deck Library
        public static List<PlayingCard> CreateDeck()
        {
            List<PlayingCard> output = new List<PlayingCard>();

            try
            {
                for (int i = 1; i < CARD_SUIT_COUNT; i++)
                {
                    for (int j = 1; j <= CARD_VALUE_COUNT; j++)
                    {
                        output.Add(new PlayingCard((CardSuit)i, (CardValue)j));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return output;
        }

        public static List<PlayingCard> ShuffleDeck(List<PlayingCard> deck)
        {
            List<PlayingCard> output = new List<PlayingCard>();
            Random rng = new Random();

            output = deck.OrderBy(item => rng.Next()).ToList();

            return output;
        }

        public static PlayingCard DealACard(List<PlayingCard> deck)
        {
            try
            {
                PlayingCard card = deck.Take(1).First();
                deck.Remove(card);
                return card;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<PlayingCard> GetAllCards(List<PlayingCard> deck)
        {
            return deck;
        }

        // Move Library
        public static bool IsValidMove(int sendingPileIndex, int receivingPileIndex, Board board)
        {
            bool output = false;
            CardPile sendPile = board.CardPiles[sendingPileIndex];
            CardPile receivePile = board.CardPiles[receivingPileIndex];

            if (sendPile.Type == PileType.Tableau ||
                sendPile.Type == PileType.Waste)
            {
                if (receivePile.Type == PileType.Tableau)
                {
                    output = ValidateTableauMove(sendPile, receivePile);
                }
                else if(receivePile.Type == PileType.Foundation)
                {
                    output = ValidateFoundationMove(sendPile, receivePile);
                }
            }

            return output;
        }

        private static bool ValidateFoundationMove(CardPile sendingPile, CardPile receivingPile)
        {
            bool output = false;

            if(sendingPile.TopCard?.Value == CardValue.A &&
                receivingPile.CardStack.Count == 0)
            {
                output = true;
            }
            else if(sendingPile.TopCard?.Suit == receivingPile.TopCard?.Suit &&
                    sendingPile.TopCard?.Value == receivingPile.TopCard?.Value + 1)
            {
                output = true;
            }

            return output;
        }

        private static bool ValidateTableauMove(CardPile sendingPile, CardPile receivingPile)
        {
            bool output = false;

            if(sendingPile.TopCard?.Value == CardValue.K && receivingPile.CardStack.Count == 0)
            {
                output = true;
            }
            if(sendingPile.TopCard?.Color != receivingPile.TopCard?.Color &&
                sendingPile.TopCard?.Value == receivingPile.TopCard?.Value - 1)
            {
                output = true;
            }

            return output;
        }
    }
}

using SolitaireLibrary.Enums;


namespace SolitaireLibrary
{
    public class Board
    {
        public CardPile[] CardPiles;
        public int SelectedIndex { get; set; } = 0;

        public Board()
        {
            CardPiles = new CardPile[13]
            {
                new CardPile(PileType.Foundation),
                new CardPile(PileType.Foundation),
                new CardPile(PileType.Foundation),
                new CardPile(PileType.Foundation),
                new CardPile(PileType.Waste),
                new CardPile(PileType.Stock),
                new CardPile(PileType.Tableau),
                new CardPile(PileType.Tableau),
                new CardPile(PileType.Tableau),
                new CardPile(PileType.Tableau),
                new CardPile(PileType.Tableau),
                new CardPile(PileType.Tableau),
                new CardPile(PileType.Tableau)
            };
        }
    }
}

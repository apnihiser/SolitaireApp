using SolitaireLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireLibrary
{
    public class CardPile
    {
        public List<PlayingCard> CardStack;
        public PileType Type { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public PlayingCard? TopCard
        {
            get 
            {
                if (CardStack.Count > 0)
                {
                    return CardStack[CardStack.Count - 1];
                }
                return null;
            }
        }

        public PlayingCard? BottomCard
        {
            get
            {
                if (CardStack.Count > 0)
                {
                    return CardStack[0];
                }
                return null;
            }
        }

        public CardPile(PileType type)
        {
            CardStack = new List<PlayingCard>();
            Type = type;
        }

        public void RemoveTopCard()
        {
            if(CardStack.Count > 0 )
            {
                CardStack.Remove(TopCard!);
            }
        }

        public void AddTopCard(PlayingCard card)
        {           
            CardStack.Add(card);
        }
    }
}

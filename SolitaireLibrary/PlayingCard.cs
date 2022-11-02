using SolitaireLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireLibrary
{
    public class PlayingCard
    {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
        public SuitColor Color 
        { 
            get
            {
                SuitColor output = SuitColor.None;

                if (Suit == CardSuit.Club || Suit == CardSuit.Spade)
                {
                    output = SuitColor.Black;
                }
                else if (Suit == CardSuit.Diamond || Suit == CardSuit.Heart)
                {
                    output = SuitColor.Red;
                }

                return output;
            }
        }

        public bool IsVisible { get; set; } = false;

        public PlayingCard(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
    }
}

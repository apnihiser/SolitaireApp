﻿namespace SolitaireConsoleUI.Settings
{
    public static class MenuSettings
    {
        public const string PROMPT = "Welcome to CLI Solitaire!";
        public static readonly string[] OPTIONS = { "Play CLI Solitaire", "How To Play", "About This App", "Quit" };
        public const string ABOUT_APP = @"Application written by Adam P. Nihiser
Simple project to practice C#
hosted at github.com/apnihiser
please contact me at apnihiser@gmail.com for career inquiries or application questions.";
        public const string INSTRUCTIONS = @"THE PACK
The standard 52-card pack is used.

OBJECT OF THE GAME
The goal is to get the four suits built onto the foundations from aces up through kings.

THE DEAL
Deal out 28 cards in seven Tableau piles as follows: The first pile is one card; the 
second pile has two cards, and so on up to seven in the last pile. The top card of each 
pile is face up; all others are face down.

THE PLAY
The four aces form the foundations. As it becomes available, each ace must be played to 
a row above the piles. Cards in the appropriate suit are then played on the aces in 
sequence - the two, then the three, and so on - as they become available.

Any movable card may be placed on a card next-higher in rank if it is of opposite color.
Example: A black five may be played on a red six. If more than one card is face up on a 
tableau pile, all such cards must be moved as a unit.

When there is no face-up card left on a pile, the top face-down card is turned up and 
becomes available.

Only a king may fill an open space in the layout. The player turns up cards from the top 
of the stock in groups of three, and the top card of the three may be used for building 
on the piles, if possible, played on a foundation. If a card is used in this manner, the 
card below it becomes available for play. If the up-card cannot be used, the one, two, or 
three cards of the group are placed face up on the waste pile, and the next group of three 
cards is turned up.";
    }
}

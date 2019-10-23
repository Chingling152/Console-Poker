using System.Linq;
using InteliTrader.Controllers;

namespace InteliTrader.Cards
{
    public class Deck{
        /// <summary>
        /// Define as cartas do deck
        /// </summary>
        public Card[] Cards {get; private set;}       

        public DeckHand Hand{get;set;}

        /// <summary>
        /// Define a posição da carta de maior valor do deck
        /// </summary>
        public Card HighCard{
            get{
                Card highCard = Cards[0];
                for (int i = 1; i < 5; i++)
                {
                    if(Cards[i] > highCard || Cards[i] == highCard){
                        highCard = Cards[i];
                    }
                }
                return highCard;
            }
        }

        public Deck(Card[] cards){
            this.Cards = cards.OrderBy(x => Card.CardValues.IndexOf(x.Value)).ToArray();
            this.Hand = Rules.GetDeckHand(this);
        }

        public string GetCards(){
            string[] cards = new string[5];
            for (int i = 0; i < 5; i++)
            {
                cards[i] = Cards[i].ToString();
            }
            return string.Join(' ',cards);
        }

        public override string ToString(){
            return $"Deck : {GetCards()}\nHand : {Hand}\nHigh Card : {HighCard}";
        }
    }
}
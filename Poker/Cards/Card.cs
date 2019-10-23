using System.Collections.Generic;

namespace InteliTrader.Cards
{
    public class Card{

        public static readonly List<string> CardValues = new List<string>(){
            "2","3","4","5","6","7","8","9","10","J","Q","K","A"
        };
        public static readonly List<string> CardNipes = new List<string> {
            "D","H","S","C"
        };
        
        public string Value { get; private set; }
        public string Nipe { get; private set; }

        public Card(string value,string nipe)
        {
            this.Value = value;
            this.Nipe = nipe;
        }

        public override string ToString(){
            return Value + Nipe;
        }

        public static bool operator!=(Card card,Card card2) => Card.CardValues.IndexOf(card.Value) != Card.CardValues.IndexOf(card2.Value);
        public static bool operator==(Card card,Card card2)=> Card.CardValues.IndexOf(card.Value) == Card.CardValues.IndexOf(card2.Value);
        public static bool operator>(Card card,Card card2)=> Card.CardValues.IndexOf(card.Value) > Card.CardValues.IndexOf(card2.Value);
        public static bool operator<(Card card,Card card2)=> Card.CardValues.IndexOf(card.Value) < Card.CardValues.IndexOf(card2.Value);
    }
}
using InteliTrader.Cards;

namespace InteliTrader.Controllers
{
    public static class Rules
    {
        
        public static DeckHand GetDeckHand(Deck deck){
            if(deck.Cards.Length ==5){//jogos validos possuem 5 cartas 
                bool flush = isFlush(deck.Cards);
                bool straight = isStraight(deck.Cards);
                //verifica os jogos : Flush , RoyalFlush , Straight e StraighFlush
                if(flush || straight){
                    if(flush && straight && deck.HighCard.Value == "A"){
                        return DeckHand.RoyalFlush;
                    }else
                    if(flush && straight){
                        return DeckHand.StraightFlush;
                    }else if(flush){
                        return DeckHand.Flush;
                    }else{
                        return DeckHand.Straight;
                    }
                }else{//verifica os jogos, quadra , trinca , par , full house e dois pares 
                    if(isKind(4,deck.Cards)){
                        return DeckHand.FourKind;
                    }else 
                    if(isFullHouse(deck.Cards)){
                        return DeckHand.FullHouse;
                    }else 
                    if(isKind(3,deck.Cards)){
                        return DeckHand.ThreeKind;
                    }else if(isTwoPairs(deck.Cards)){
                        return DeckHand.TwoPairs;
                    }else if(isKind(2,deck.Cards)){
                        return DeckHand.OnePair;
                    }
                }//caso não chegue a nenhum resultado
            }
            return DeckHand.HighCard;
        }

        private static bool isFlush(Card[] cards){
            string defaultNipe = cards[0].Nipe;

            for (int i = 0; i < cards.Length; i++)
            {
                if(cards[i].Nipe != defaultNipe)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Verifica se o grupo de cartas possui uma sequencia
        /// </summary>
        /// <param name="cards">Cartas a serem verificadas</param>
        /// <returns>retorna true se as 5 cartas estiverem ordenadas e em sequencia</returns>
        private static bool isStraight(Card[] cards){
            if(Card.CardValues.IndexOf(cards[0].Value) > Card.CardValues.IndexOf("10")){
                //verificar se o primeiro não é maior do que 10 
                //não é possivel começar uma sequencia a partir do Valete
                return false;
            }else{
                string expectedCard = Card.CardValues[Card.CardValues.IndexOf(cards[0].Value) +1];//proxima carta esperada (index da carta atual +1)
                for (int i = 1; i < cards.Length ; i++)
                {   
                    if(cards[i].Value != expectedCard){
                        return false;
                    }
                    expectedCard = Card.CardValues[Card.CardValues.IndexOf(cards[i].Value) +1];
                }
            }
            return true;
        }

        private static bool isFullHouse(Card[] cards){
            bool c1 = cards[0] == cards[1] && cards[1]== cards[2] && cards[3] == cards[4];
            bool c2 = cards[0] == cards[1] && cards[2]== cards[3] && cards[3] == cards[4];
            return c1 || c2;
        }

        private static bool isTwoPairs(Card[] cards){
            bool c1 = cards[0] == cards[1] && cards[2] == cards[3];
            bool c2 = cards[0] == cards[1] &&cards[3] == cards[4];
            bool c3 = cards[1] == cards[2] &&cards[3] == cards[4];
            return c1 || c2 || c3;
        }
        /// <summary>
        /// Verifica se o grupo de cartas possui um numero de cartas iguais
        /// </summary>
        /// <param name="quant">Define a quantidade de cartas iguais que o grupo de cartas deveráter</param>
        /// <param name="cards">Cartas a serem verificadas</param>
        /// <returns>retorna true se as cartas possuirem N cartas iguais</returns>
        private static bool isKind(int quant,Card[] cards){
            int kind = 1;
            for (int i = 0; i < cards.Length-1; i++){
                kind = cards[i] == cards[i+1]? kind +1 :1;
                if(kind == quant)
                    return true;
            }
            return false;
        }
    }
}
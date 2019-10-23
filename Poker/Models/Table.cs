using System;
using System.Collections.Generic;
using InteliTrader.Cards;

namespace InteliTrader
{
    public class Table
    {
        /// <summary>
        /// Define Todas as cartas selecionadas na mesa atual
        /// </summary>
        private List<string> SelectedCards = new List<string>();
        /// <summary>
        /// Define os jogadores na mesa atual
        /// </summary>
        public readonly Player[] Players;

        public Table(int players){
            Players = new Player[players];
            for (int i = 0; i < players; i++)
            {
                Deck deck = new Deck(RandomDeck());
                Players[i] = new Player(deck);
            }
        }
        /// <summary>
        /// Gera um deck aleatorio Unico
        /// </summary>
        /// <returns>Um grupo de 5 cartas aleatoriamente sortidas</returns>
        private Card[] RandomDeck(){
            Card[] deck = new Card[5];

            for (int i = 0; i < 5; i++)
            {
                Random rdm = new Random();
                string card;
                string nipe;
                do
                {
                    card = Card.CardValues[rdm.Next(0,Card.CardValues.Count-1)];
                    nipe = Card.CardNipes[rdm.Next(0,Card.CardNipes.Count-1)];
                } while (SelectedCards.Contains(card+nipe));//prevenir cartas repetidas

                SelectedCards.Add(card + nipe);
                deck[i] = new Card(card,nipe);
            }

            return deck;
        }
        /// <summary>
        /// Procura o vencedor baseado em seus jogos e cart aalta
        /// </summary>
        /// <returns>Retorna todas as informações do player vencedor</returns>
        public string Winner(){
            Player first = Players[0];
            for (int i = 1; i < Players.Length; i++)
            {
                if(Players[i].Deck.Hand > first.Deck.Hand){
                    first= Players[i];
                }else if (Players[i].Deck.Hand == first.Deck.Hand){
                    int firtsValue = Card.CardValues.IndexOf(first.Deck.HighCard.Value);
                    int playerValue = Card.CardValues.IndexOf(Players[i].Deck.HighCard.Value);
                    if(firtsValue <= playerValue){//comparando carta alta
                        first = Players[i];
                    }
                }
            }

            return first.ToString();
        }
    }
}

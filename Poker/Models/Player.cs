using InteliTrader.Cards;

namespace InteliTrader
{
    /// <summary>
    /// Jogador
    /// </summary>
    public class Player
    {
        public static int CountPlayer =0;
        /// <summary>
        /// Define o deck atual do jogador
        /// </summary>
        public Deck Deck{get;private set;}

        public string Name{get; private set;}

        public Player(Deck deck)
        {
            this.Deck = deck;
            this.Name = $"Jogador {++CountPlayer}";
        }

        public override string ToString()=> $"---------\n{Name}\n{Deck.ToString()}";
        
    }
}

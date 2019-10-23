namespace InteliTrader.Cards
{
    /// <summary>
    /// Define o Nivel do deck do jogador
    /// </summary>
    public enum DeckHand
    {
        /// <summary>
        /// Um baralho sem nenhum jogo feito
        /// </summary>
        HighCard = 0,
        /// <summary>
        /// Um baralho com 2 cartas com mesmo valor
        /// </summary>
        OnePair = 1,
        /// <summary>
        /// Um baralho com 2 pares de cartas com o mesmo valor
        /// </summary>
        TwoPairs = 2 ,
        /// <summary>
        /// Um baralho com 3 cartas com o mesmo valor
        /// </summary>
        ThreeKind = 3,
        /// <summary>
        /// Um baralho 5 cartas em sequencia
        /// </summary>
        Straight = 4,
        /// <summary>
        /// Um baralho 5 cartas com o mesmo naipe
        /// </summary>
        Flush = 5,
        /// <summary>
        /// Um baralho contendo um par e uma trinca
        /// </summary>
        FullHouse = 6,
        /// <summary>
        /// Um baralho com 4 cartas com o mesmo valor
        /// </summary>
        FourKind = 7,
        /// <summary>
        /// Um baralho com 5 cartas em sequencia do mesmo naipe
        /// </summary>
        StraightFlush = 8,
        /// <summary>
        /// Um baralho com as cartas A,K,Q,J e 10 do mesmo naipe
        /// </summary>
        RoyalFlush = 9
    }
}
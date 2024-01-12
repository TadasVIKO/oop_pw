namespace BlackJack;

public class NumberCard : Card
{
    public override string Suit { get; }
    public override string Rank { get; }

    public NumberCard(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override int GetValue()
    {
        return int.Parse(Rank);
    }
}
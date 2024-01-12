namespace BlackJack;

public class FaceCard : Card
{
    public override string Suit { get; }
    public override string Rank { get; }

    public FaceCard(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override int GetValue()
    {
        return 10;
    }
}
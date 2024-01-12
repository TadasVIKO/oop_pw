namespace BlackJack;

public abstract class Card
{
    public abstract string Suit { get; }
    public abstract string Rank { get; }

    public abstract int GetValue();

    public override string ToString()
    {
        return Rank + Suit;
    }
}
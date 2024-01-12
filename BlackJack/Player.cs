namespace BlackJack;

public abstract class Player
{
    protected List<Card> hand;

    public Player()
    {
        hand = new List<Card>();
    }

    public void AddCard(Card card)
    {
        hand.Add(card);
    }

    public abstract int CalculateScore();

    public bool IsBusted()
    {
        return CalculateScore() > 21;
    }

    public string GetHandString(bool showFirstCard = true)
    {
        if (showFirstCard)
        {
            return string.Join(", ", hand);
        }
        else
        {
            return hand.First() + ", ##";
        }
    }
}
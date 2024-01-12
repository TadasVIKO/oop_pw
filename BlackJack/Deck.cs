namespace BlackJack;

public class Deck
{
    protected static List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
        string[] suits = { "♠", "♣", "♥", "♦" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                if (rank == "A" || rank == "K" || rank == "Q" || rank == "J")
                {
                    cards.Add(new FaceCard(suit, rank));
                }
                else
                {
                    cards.Add(new NumberCard(suit, rank));
                }
            }
        }

        DeckShuffle.Shuffle();
    }
}

class DeckShuffle : Deck
{
    public static void Shuffle()
    {
        Random random = new Random();
        cards = cards.OrderBy(x => random.Next()).ToList();
    }
}

class DrawingCard : Deck
{
    public static Card DrawCard()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}

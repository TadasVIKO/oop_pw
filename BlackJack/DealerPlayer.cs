namespace BlackJack;

public class DealerPlayer : Player
{
    public override int CalculateScore()
    {
        int score = 0;
        int aceCount = 0;

        foreach (var card in hand)
        {
            score += card.GetValue();
            if (card.Rank == "A")
            {
                aceCount++;
            }
        }

        while (aceCount > 0 && score > 21)
        {
            score -= 10;
            aceCount--;
        }

        return score;
    }
    
    public void PlayTurn(Deck deck)
    {
        while (CalculateScore() < 17)
        {
            AddCard(DrawingCard.DrawCard());
        }
    }
}
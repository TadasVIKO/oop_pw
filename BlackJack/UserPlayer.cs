namespace BlackJack;

public class UserPlayer : Player
{
    protected string name;
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
}

public class PlayerBalance : UserPlayer
{
    protected static int balance;

    public static int getBalance()
    {
        return balance;
    }

    public static void setBalance(object input)
    {
        balance = (int)input;
    }
}

public class PlayerName : UserPlayer
{
    protected static string name;

    public static void setName(object input)
    {
        name = (string)input;
    }

    public static string getName()
    {
        return name;
    }
}
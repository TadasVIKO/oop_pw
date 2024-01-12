namespace BlackJack;

public class Game
{
    public static void Start()
    {
        Console.WriteLine("\n===================================");
        Console.WriteLine($"{PlayerName.getName()}'s currect balance is ${PlayerBalance.getBalance()}");
        
        Deck deck = new Deck();
        UserPlayer player = new UserPlayer();
        DealerPlayer dealer = new DealerPlayer();
        int bet = 0;

        if (PlayerBalance.getBalance() != 0)
        {
            Console.Write("\nPlace a bet: ");

            while (!int.TryParse(Console.ReadLine(), out bet))
            {
                Console.Write("Invalid input. Please enter an integer: ");
            }

            while (bet > PlayerBalance.getBalance())
            {
                Console.Clear();
                Console.WriteLine("You don't have the sufficient funds. Your current balance is: " +
                                  PlayerBalance.getBalance());
                Console.Write("Please place a valid bet: ");

                while (!int.TryParse(Console.ReadLine(), out bet))
                {
                    Console.Write("Invalid input. Please enter an integer: ");
                }
            }
        }
        else
        {
            Console.WriteLine("\nYou do not have any money to bet! You can still play without betting.");
        }

        player.AddCard(DrawingCard.DrawCard());
        dealer.AddCard(DrawingCard.DrawCard());
        player.AddCard(DrawingCard.DrawCard());
        dealer.AddCard(DrawingCard.DrawCard());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Player's turn:");
            ShowHands.DisplayHands(player, dealer, false);

            if (player.IsBusted())
            {
                Console.WriteLine("Busted! You lose.");
                break;
            }

            Console.Write("Do you want to hit? (Y/N): ");
            char choice = Console.ReadKey().KeyChar;

            if (choice == 'y' || choice == 'Y')
            {
                player.AddCard(DrawingCard.DrawCard());
            }
            else if (choice == 'n' || choice == 'N')
            {
                Console.Clear();
                break;
            }
        }

        Console.WriteLine("\nDealer's turn:");
        dealer.PlayTurn(deck);
        ShowHands.DisplayHands(player, dealer, true);

        if (player.IsBusted() || (!dealer.IsBusted() && dealer.CalculateScore() >= player.CalculateScore()))
        {
            int new_bal = PlayerBalance.getBalance() - bet;
            PlayerBalance.setBalance(new_bal);
            Console.WriteLine("Dealer wins! Your new balance is: " + PlayerBalance.getBalance());
        }
        else
        {
            int new_bal = PlayerBalance.getBalance() + bet;
            PlayerBalance.setBalance(new_bal);
            Console.WriteLine("You win! Your new balance is: " + PlayerBalance.getBalance());
        }

        string name = PlayerName.getName();
        int bal = PlayerBalance.getBalance();
        
        FileManagerUpdate.Update(name, bal);
        
        Console.WriteLine("Do you wish to play again? (Y/N)");
        char playagain = Console.ReadKey().KeyChar;

        if (playagain == 'y' || playagain == 'Y')
        {
            Console.Clear();
            Game.Start();
        }
        else if (playagain == 'n' || playagain == 'N')
        {
            Console.Clear();
            Console.WriteLine("\nThank you for playing!");
            Menu.Show();
        }
    }
}

public class ShowHands : Game
{
    protected internal static void DisplayHands(Player player, Player dealer, bool showAllDealerCards)
    {
        Console.WriteLine("Player's hand: " + player.GetHandString());
        Console.WriteLine("Player's score: " + player.CalculateScore());
        Console.WriteLine("\nDealer's hand: " + dealer.GetHandString(showAllDealerCards));
        Console.WriteLine("Dealer's score: " + dealer.CalculateScore());
    }
}

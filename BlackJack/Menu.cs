namespace BlackJack;

public class Menu
{
    public static void Show()
    {
        Console.WriteLine("Welcome, " + PlayerName.getName() + "!");
        Console.WriteLine("Please choose an option: ");
        Console.WriteLine("1. Play BlackJack\n" +
                          "2. Check scoreboard\n" +
                          "3. Exit");

        Console.Write("Choose your option: ");
        char choice = Console.ReadKey().KeyChar;

        if (choice == '1')
        {
            Console.Clear();
            Game.Start();
        }
        else if (choice == '2')
        {
            Console.WriteLine("\nScoreboard:");
            FileManagerRead.Read();
            
            Console.WriteLine("Press x to return to the menu.");
            if (Console.ReadKey().Key == ConsoleKey.X)
            {
                Console.Clear();
                Menu.Show();
            }
        }
        else if (choice == '3')
        {
            return;
        }
    }
}
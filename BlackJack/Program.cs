using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using BlackJack;
using Org.BouncyCastle.Crypto.Modes.Gcm;

class Program
{
    static void Main()
    {
        FileManager.Connect();
        
        Console.WriteLine("Welcome to Blackjack!");
        Console.WriteLine("What is your name: ");
        string input = Console.ReadLine();

        while (input == "" || input is null)
        {
            Console.WriteLine("Name cannot be empty!");
            Console.WriteLine("What is your name: ");
            input = Console.ReadLine();
        }
        
        FileManagerGetPlayer.Player(input);

        Console.Clear();
        Menu.Show();
    }
}
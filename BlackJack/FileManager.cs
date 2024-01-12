using MySql.Data.MySqlClient;

namespace BlackJack;

public class FileManager
{
    protected static MySqlConnection conn = new MySqlConnection();
    
    public static void Connect()
    {
        conn.ConnectionString = "server=localhost;uid=root;pwd=123password;database=oop_db";
        conn.Open();
    }
}

public class FileManagerRead : FileManager
 {
     public static void Read()
     {
         MySqlCommand cmd = new MySqlCommand("select * from players order by balance DESC", conn);
         MySqlDataReader reader = cmd.ExecuteReader();
 
         while (reader.Read())
         {
             Console.WriteLine("Name: " + reader[0] + ", Balance: " + reader[1]);
         }
         reader.Close();
     }
     
 }
 
public class FileManagerGetPlayer : FileManager
{
    public static void Player(string name)
    {
        MySqlCommand cmd = new MySqlCommand("select * from players where name = @name", conn);
        cmd.Parameters.AddWithValue("@name", name);
        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                PlayerName.setName(reader[0]);
                PlayerBalance.setBalance(reader[1]);
            }
        }
        else
        {
            int bal = 100;
            MySqlCommand insertcmd = new MySqlCommand("insert into players (name, balance) values (@name, @bal)", conn);
            insertcmd.Parameters.AddWithValue("@name", name);
            insertcmd.Parameters.AddWithValue("@bal", bal);
            
            reader.Close();

            int rowsAffected = insertcmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Your name was not found in the database, new character has been created.");
                PlayerName.setName(name);
                PlayerBalance.setBalance(bal);
            }
        }
        reader.Close();
    }
    
}

public class FileManagerUpdate : FileManager
{
    public static void Update(string name, int bal)
    {
        MySqlCommand cmd = new MySqlCommand("UPDATE players SET players.balance = @bal WHERE (players.name = @name)", conn);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@bal", bal); 
        cmd.ExecuteNonQuery();

    }
}
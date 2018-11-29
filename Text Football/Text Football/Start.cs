using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Football
{
    class Start
    {
        public void startSetUp()
        {
            int numPlayers = numberOfPlayers();
            List<Player> players = createPlayers(numPlayers);
            Player p1 = players[0];
            Player p2 = players[1];
            //for testing, it works!
            //Console.WriteLine(p1.teamName);
            //Console.ReadLine();

        }

        public int numberOfPlayers()
        {
            Console.WriteLine("How many players will be playing 1 or 2?");

            bool unsuccessful = true;
            int value = 0;

            while (unsuccessful)
            {
                Console.WriteLine("Please enter the number players:");
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    if (value == 1 || value == 2 )
                    {
                        Console.WriteLine("You have selected: " + value);
                        unsuccessful = false;
                    }
                    else
                    {
                        Console.WriteLine("Your input needs to be 1 or 2.");
                    }

                }
                else
                {
                    Console.WriteLine("Your input needs to be a number. Please try again.");
                }
            }

            return value;
        }

        public List<Player> createPlayers(int numPlayers)
        {
            List<Player> players = new List<Player>();
            if(numPlayers == 1)
            {
                Console.WriteLine("You have selected 1 player. You will be competing against the CPU.");

                Console.WriteLine("Creating player 1...");
                Player player1 = new Player();
                Console.WriteLine("Player 1 enter your player name:");
                player1.playerName = Console.ReadLine();
                Console.WriteLine("Player 1 enter your team name:");
                player1.teamName = Console.ReadLine();
                Console.WriteLine("Player 1 is: " + player1.playerName + "\n" + player1.playerName + " will be controlling the " + player1.teamName);

                Console.WriteLine("Creating the CPU...");
                //need to make the cpu class/or use the player class? and create a new cpu here
                Player CPU = new Player();
                CPU.playerName = "CPU";
                CPU.teamName = "CPU's";
                Console.WriteLine("The CPU name is: " + CPU.playerName + "\n" + CPU.playerName + " will be controlling the " + CPU.teamName);

                players.Add(player1);
                players.Add(CPU);
                Console.ReadLine();
            }
            else if(numPlayers == 2)
            {
                Console.WriteLine("You have selected 2 players.");

                Console.WriteLine("Creating player 1...");
                Player player1 = new Player();
                Console.WriteLine("Player 1 enter your player name:");
                player1.playerName = Console.ReadLine();
                Console.WriteLine("Player 1 enter your team name:");
                player1.teamName = Console.ReadLine();
                Console.WriteLine("Player 1 is: " + player1.playerName + "\n" + player1.playerName + " will be controlling the " + player1.teamName);

                Console.WriteLine("Creating player 2...");
                Player player2 = new Player();
                Console.WriteLine("Player 2 enter your player name:");
                player2.playerName = Console.ReadLine();
                Console.WriteLine("Player 2 enter your team name:");
                player2.teamName = Console.ReadLine();
                Console.WriteLine("Player 2 is: " + player2.playerName + "\n" + player2.playerName + " will be controlling the " + player2.teamName);

                players.Add(player1);
                players.Add(player2);
                Console.ReadLine();
            }

            return players;
        }

        public void coinToss()
        {

        }
    }
}

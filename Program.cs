using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanPlayer player1 = new HumanPlayer();
            player1.Name = "Bob";

            OneHigherPlayer player2 = new OneHigherPlayer();
            player2.Name = "Sue";

            SmackTalkingPlayer smack = new SmackTalkingPlayer();
            smack.Name = "Toothbrush McGee";
            smack.Taunt = "'You wanna roll dice with me?!'";

            SoreLoserPlayer player4 = new SoreLoserPlayer();
            player4.Name = "LeBron";

            UpperHalfPlayer player5 = new UpperHalfPlayer();
            player5.Name = "LSV";

            SoreLoserUpperHalfPlayer player6 = new SoreLoserUpperHalfPlayer();
            player6.Name = "Phil Hellmuth";

            player2.Play(player1);

            Console.WriteLine("-------------------");

            smack.Play(player1);

            Console.WriteLine("-------------------");

            CreativeSmackTalkingPlayer player3 = new CreativeSmackTalkingPlayer();
            player3.Name = "Wilma";
            player3.Taunts.Add("Suck it!");
            player3.Taunts.Add("Hate the player, not the game");
            player3.Taunts.Add("You got a sharpie? I can autograph that for you.");
            player3.Taunts.Add("I eat pieces of shit like you for breakfast.");

            player3.Play(player2);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            player1.Play(large);

            Console.WriteLine("-------------------");

            List<Player> players = new List<Player>() {
                player1, player2, player3, player4, large, smack, player5, player6
            };

            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play noe another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                player1.Play(player2);
            }
        }
    }
}
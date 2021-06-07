using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        public List<string> Taunts { get; set; }

        public CreativeSmackTalkingPlayer()
        {
        Taunts = new List<string>();
        }

        public override int Roll()
        {
            Random i = new Random();
            int randomTaunt = i.Next(0, Taunts.Count - 1);
            Console.WriteLine($"{Name} says, {Taunts[randomTaunt]}");
            return new Random().Next(DiceSize) + 1;
        }
    }
}
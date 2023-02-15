using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NhlSystemClassLibrary;

namespace NhlSystemClassLibrary
{
    public class Team
    {
        // Name, City, Arena, Conference, Division

        //Define fully implemented properties with a backing field for Name, City, Arena
        private string _name;
        private string _city;
        private string _arena;

        public string Name
        {
            get { return _name; }
            set
            {
                //Validate name
                if(String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Name cannot be blank.");
                }
                _name = value.Trim(); //Trim removes spaces at the front and back
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                //Validate city
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "City cannot be blank.");
                }
                if(value.Trim().Length < 3)
                {
                    throw new ArgumentException("City must contain 3 or more characters.");
                }
                if (!Regex.IsMatch(value.Trim(), @"^[a-zA-Z ]+$"))
                {
                    throw new ArgumentException("City must only contain english letters.");
                }
                _city = value.Trim(); //Trim removes spaces at the front and back
            }
        }
        public string Arena
        {
            get { return _arena; }
            set
            {
                //Validate arena
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Arena cannot be blank.");
                }
                _arena = value.Trim(); //Trim removes spaces at the front and back
            }
        }


        //Define auto-implemented properties for Conference and Division
        public Conference Conference { get; set; }
        public Division Division { get; set; }

        public List<Player> Players { get; private set; } = new List<Player>();

        // Greedy constructor
        public Team(string name, string city, string arena)
        {
            Name = name;
            City = city;
            Arena = arena;
        }

        public void AddPlayer(Player currentPlayer)
        {
            if(currentPlayer == null)
            {
                throw new ArgumentNullException(nameof(AddPlayer),"Player cannot be null");
            }
            foreach(Player player in Players)
            {
                if(player.PlayerNum == currentPlayer.PlayerNum)
                {
                    throw new ArgumentException($"{currentPlayer.PlayerNum} is already in the team as {player.Name}'s number");
                }
            }
            if(Players.Count == 23)
            {
                throw new ArgumentException("Team is already full!");
            }
            Players.Add(currentPlayer);
        }

        public void PrintTeamInfo()
        {
            Console.WriteLine($"Team name: {Name}, Team city: {City}, Team arena: {Arena}, Team players: ");
            foreach (Player player in Players)
            {
                Console.WriteLine($"Number: {player.PlayerNum}, Name: {player.Name}, Position: {player.Position}, Games Played: {player.GamesPlayed}, Goals: {player.Goals}, Assists: {player.Assists}");
            }
        }
    }
}

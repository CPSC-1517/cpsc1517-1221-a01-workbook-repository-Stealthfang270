using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhlSystemClassLibrary;

namespace NhlSystemClassLibrary
{
    public class Player
    {
        const int MinPlayerNum = 1;
        const int MaxPlayerNum = 98;

        private int _playerNum;
        private string _name;
        private int _gamesPlayed;
        private int _goals;
        private int _assists;



        public int PlayerNum
        {
            get
            {
                return _playerNum;
            }
            private set
            {
                if (!Utils.NumInRange(value, MinPlayerNum, MaxPlayerNum))
                {
                    throw new ArgumentException("Number must be between 1 and 98");
                }
                _playerNum = value;
            }
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Name cannot be blank.");
                }
                _name = value.Trim();
            }
        }


        public Position Position { get; private set; }

        public int GamesPlayed
        {
            get { return _gamesPlayed; }
            protected set
            {
                if (!Utils.NumInRange(value, 0, int.MaxValue))
                {
                    throw new ArgumentException("Games Played must be a positive number");
                }
            }
        }

        public int Goals
        {
            get { return _goals; }
            private set
            {
                if (!Utils.NumInRange(value, 0, int.MaxValue))
                {
                    throw new ArgumentException("Goals must be a positive number");
                }
            }
        }

        public int Assists
        {
            get { return _assists; }
            private set
            {
                if (!Utils.NumInRange(value, 0, int.MaxValue))
                {
                    throw new ArgumentException("Assists must be a positive number");
                }
            }
        }

        public int Points
        {
            get { return _goals + _assists; }
        }

        public Player(int playerNum, string name, Position position, int gamesPlayed, int goals, int assists)
        {
            PlayerNum = playerNum;
            Name = name;
            Position = position;
            GamesPlayed = gamesPlayed;
            Goals = goals;
            Assists = assists;
        }

        public Player(int playerNum, string name, Position position)
        {
            PlayerNum = playerNum;
            Name = name;
            Position = position;
        }

        public void AddGamesPlayed()
        {
            GamesPlayed++;
        }
        public void AddGoals()
        {
            Goals++;
        }
        public void AddAssist()
        {
            Assists++;
        }
    }
}

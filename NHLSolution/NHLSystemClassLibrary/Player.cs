using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystemClassLibrary
{
    internal class Player
    {
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
            set
            {
                if (value < 1 || value > 98)
                {
                    throw new ArgumentException("Number must be between 1 and 98");
                }
                _playerNum = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Name cannot be blank.");
                }
                _name = value.Trim();
            }
        }


        public Position Position { get; set; }

        public int GamesPlayed
        {
            get { return _gamesPlayed; }
            set { PositiveNum(value, "Games played"); }
        }

        public int Goals
        {
            get { return _goals; }
            set { PositiveNum(value, "Goals"); }
        }

        public int Assists
        {
            get { return _assists; }
            set { PositiveNum(value, "Assists"); }
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

        private static int PositiveNum(int num, string numName)
        {
            if(num >= 0)
            {
                return num;
            }
            else
            {
                throw new ArgumentException($"{numName} must be a positive number");
            }
        }
    }
}

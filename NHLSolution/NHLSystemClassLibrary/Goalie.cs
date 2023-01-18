using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhlSystemClassLibrary;

namespace NhlSystemClassLibrary
{
    public class Goalie : Player
    {
        private double _savePercent;
        public double GoalsAgainstAverage { get; set; }
        public double SavePercent
        {
            get
            {
                return _savePercent;
            }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Save Percent must be between 0 and 1");
                }
            }
        }
        public int Shutouts { get; private set; }

        public Goalie(int playerNum, string name) : base(playerNum, name, Position.Goalie)
        {

        }
        public Goalie(int playerNum, string name, int gamesPlayed) : base(playerNum, name, Position.Goalie)
        {
            base.GamesPlayed = gamesPlayed;
        }

        public void AddShutout()
        {
            Shutouts++;
        }
    }
}

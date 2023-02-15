using System;
using System.Collections.Generic;
using System.Globalization;
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
                _gamesPlayed = value;
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
                _goals = value;
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
                _assists = value;
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

        public Player()
        {

        }

        public override string ToString()
        {
            return $"{PlayerNum},{Name},{Position},{GamesPlayed},{Goals},{Assists}";
        }

        //PlayerNum,Name,Position,GamesPlayer,Goals,Assists
        public static Player Parse(string csvLine)
        {
            const char Separator = ',';
            const int ExpectedColumnCount = 6;
            string[] tokens = csvLine.Split(Separator);

            if(tokens.Length != ExpectedColumnCount)
            {
                throw new FormatException($"CSV line must contain exactly {ExpectedColumnCount} values.");
            }

            int playerNum = int.Parse(tokens[0]);
            string name = tokens[1];
            Position position = Enum.Parse<Position>(tokens[2]);
            int gamesPlayed = int.Parse(tokens[3]);
            int goals = int.Parse(tokens[4]);
            int assists = int.Parse(tokens[5]);

            return new Player(playerNum,name,position,gamesPlayed,goals,assists);
        }

        public static bool TryParse(string csvLine, out Player currentPlayer)
        {
            bool success = false;

            try
            {
                currentPlayer = Parse(csvLine);
                success = true;
            }
            catch(FormatException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception($"Player TryParse method failed with exception {ex.Message}");
            }

            return success;
        }

        public static Team ReadPlayerDataFromCsv(string FilePath)
        {
            Team team = new Team("ugh", "Guh huh", "Balls");

            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        Player player;
                        TryParse(line, out player);
                        team.AddPlayer(player);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Format exception {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading from file with exception {ex.Message}");
                    }
                }
            }

            return team;
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

namespace NHLConsoleApp
{
    using NhlSystemClassLibrary;
    internal class Program
    {
        static void Main(string[] args)
        {
            const string FilePath = @"../../../Players.csv";
            
            Team team = Player.ReadPlayerDataFromCsv(FilePath);
            team.PrintTeamInfo();
        }
    }
}
namespace NHLConsoleApp
{
    using NhlSystemClassLibrary;
    internal class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team("Eggs", "Eggtopia", "Egg Arena");
            Console.WriteLine($"{team.Name}  {team.City} {team.Arena}");
        }
    }
}
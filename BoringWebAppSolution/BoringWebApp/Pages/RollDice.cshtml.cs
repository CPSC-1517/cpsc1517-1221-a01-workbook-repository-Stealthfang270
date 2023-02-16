using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoringWebApp.Pages
{
    public class RollDiceModel : PageModel
    {
        

        public int Dice { get; private set; } = 1;
        public string[] DicePaths { get; private set; } =
        {
            "img/dice1.png",
            "img/dice2.png",
            "img/dice3.png",
            "img/dice4.png",
            "img/dice5.png",
            "img/dice6.png"
        };

        public string DicePath { get; private set; }

        [BindProperty]
        public int Bet { get; set; }

        [BindProperty]
        public int DiceSelect { get; set; }
        

        public string InfoMessage { get; set; }

        public void OnGet()
        {

            DicePath = DicePaths[0];
        }

        public void OnPost()
        {
            Random random = new Random();
            Dice = random.Next(1, 7);

            DicePath = DicePaths[Dice - 1];

            if(Bet < 5) { Bet = 5; }

            if (DiceSelect == Dice)
            {
                InfoMessage = $"Your bet was {DiceSelect}. The number is {Dice}. You win ${Bet:0.00}";
            }
            else
            {
                InfoMessage = $"Your bet was {DiceSelect}. The number is {Dice}. You lose ${Bet:0.00}";
            }
        }
    }
}

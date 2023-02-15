using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoringWebApp.Pages
{
    public class RollDiceModel : PageModel
    {

        public int Dice { get; private set; } = 0;
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

        public void OnGet()
        {

            DicePath = DicePaths[0];
        }

        public void OnPost()
        {
            Random random = new Random();
            Dice = random.Next(1, 7);

            DicePath = DicePaths[Dice - 1];
        }
    }
}

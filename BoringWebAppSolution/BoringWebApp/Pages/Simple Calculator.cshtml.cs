using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoringWebApp.Pages
{
    public class Simple_CalculatorModel : PageModel
    {
        public string InfoMessage { get; private set; }

        [BindProperty]
        public double Num1 { get; set; }

        [BindProperty]
        public double Num2 { get; set; }

        #region OnPosts
        public void OnPostAdd()
        {
            InfoMessage = $"The result is {Add(Num1, Num2)}";
        }

        public void OnPostSubtract()
        {
            InfoMessage = $"The result is {Subtract(Num1, Num2)}";
        }

        public void OnPostMultiply()
        {
            InfoMessage = $"The result is {Multiply(Num1, Num2)}";
        }

        public void OnPostDivide()
        {
            InfoMessage = $"The result is {Divide(Num1, Num2)}";
        }
        #endregion

        public void OnGet()
        {
        }

        #region Methods
        public double Add(double n1, double n2) { return n1 + n2; }
        public double Subtract(double n1, double n2) { return n1 - n2; }
        public double Multiply(double n1, double n2) { return n1 * n2; }
        public double Divide(double n1, double n2)
        {
            if(n2 == 0)
            {
                return double.NaN;
            } else
            {
                return n1 / n2;
            }
        }
        #endregion
    }
}

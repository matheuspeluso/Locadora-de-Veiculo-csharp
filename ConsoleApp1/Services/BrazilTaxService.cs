namespace ConsoleApp1.Services
{
    internal class BrazilTaxService : ITaxService  
    {
        public double Tax(double amount)  // de acordo com a metodo da ITaxService
        {
            if (amount <= 100)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }
    }
}

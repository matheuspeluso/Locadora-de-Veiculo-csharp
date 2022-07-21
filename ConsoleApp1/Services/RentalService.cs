using System;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Services
{
    internal class RentalService
    {
        public double PricePerHours { get; private set; }
        public double PricePerDay { get; private set; }

        private ITaxService _taxService;

        public RentalService(double pricePerHours, double pricePerDay,ITaxService taxService)
        {
            PricePerHours = pricePerHours;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CardRental cardRental)
        {
            TimeSpan duration = cardRental.Finish.Subtract(cardRental.Start); // duração da locação

            double basicPayment = 0.0;

            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHours * Math.Ceiling (duration.TotalHours); // arredondando pra cima
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling (duration.TotalDays); // arrendondando pra cima
            }
            double tax = _taxService.Tax(basicPayment);

            cardRental.Invoice = new Invoice(basicPayment, tax);

        }
    }
}

﻿using System;
using System.Globalization;
using ConsoleApp1.Entities;
using ConsoleApp1.Services;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter rental data: ");
                Console.Write("Car Model: ");
                string model = Console.ReadLine();

                Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
                DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Console.Write("Return: (dd/MM/yyyy hh:mm): ");
                DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                Console.Write("Enter price per hour: ");
                double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Enter price per day: ");
                double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                CardRental carRental = new CardRental(start, finish, new Vehicle(model));
                RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());
                rentalService.ProcessInvoice(carRental);
                Console.WriteLine("INVOICE: ");
                Console.WriteLine(carRental.Invoice);
            }
            catch(Exception e)
            {
                Console.Write("An error happend: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
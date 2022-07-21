﻿using System.Globalization;

namespace ConsoleApp1.Entities
{
    internal class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }

        public override string ToString()
        {
            return "Basic payment: " +
                BasicPayment.ToString("f2", CultureInfo.InvariantCulture) +
                "\nTax: " + Tax.ToString("f2", CultureInfo.InvariantCulture) +
                "\nTotal payment: " + TotalPayment.ToString("f2", CultureInfo.InvariantCulture);
        }
    }
}

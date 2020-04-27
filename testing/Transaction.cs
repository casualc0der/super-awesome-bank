using Microsoft.VisualBasic;
using System;

namespace testing
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string Date { get; set; }

        public Transaction(decimal amount, string notes, DateTime date)
        {
            this.Amount = amount;
            this.Note = notes;
            this.Date = date.ToString();
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWarehouse
{
    public class  Transaction
    {
        public decimal Price { get; }
        public int Quantity { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, int quantity,string note)
        {
            Price = amount;
            Date = date;
            Notes = note;
            Quantity = quantity;
        }
    }
}

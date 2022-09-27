using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyWarehouse
{
    public class Storage_account
    {
        public string Number { get; }
        public decimal Price
        {
            get
            {
                decimal cost = 0;
                foreach (var good in TotalTransaction)
                {
                    cost += good.Price;
                }
                return cost;
            }
        }
        public int Quantity 
        {
            get
            {
                int quan = 0;
                foreach (var good in TotalTransaction)
                {
                    quan +=good.Quantity;
                }
                return quan;
            }


        }
        
        
        
        
        
        public string Place { get; set; }

        private static int seed = 1000;

        public Storage_account( string place, decimal price, int quantity)
        {
            Place = place;

            Number = seed.ToString();
            seed++;
            ImportItem(price, quantity, DateTime.Now, place);


            
        }
        private List<Transaction> TotalTransaction = new List<Transaction>();



        public void ImportItem(decimal amount, int quantity, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of item must be positive");
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "quantity of item must be positive");
            }

            var deposit = new Transaction(amount, date,  quantity, note);
            TotalTransaction.Add(deposit);
        }
        public void ExportItem( decimal amount,int quantity, DateTime date, string note)
        {
            if (Quantity - quantity < 0)
            {
                throw new InvalidOperationException("Not sufficient goods for this Export");
            }
            if (Price - amount < 0)
            {
                throw new InvalidOperationException("loss");
            }
            var withdrawal = new Transaction(-amount, date, -quantity, note);
            TotalTransaction.Add(withdrawal);
        }
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            
            report.AppendLine("Date\t\tAmount\tPlace\tQuantity");
            foreach (var item in TotalTransaction)
            {
               
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Price}\t{item.Notes}\t{item.Quantity}");
            }

            return report.ToString();
        }

    }
}  
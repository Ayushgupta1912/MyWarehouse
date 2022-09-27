namespace MyWarehouse
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var Laptop = new Storage_account("shimla",1000,10);
            Console.WriteLine(Laptop.Price);

            Laptop.ImportItem(1000, 50, DateTime.Now, "Mehli");
            Console.WriteLine(Laptop.Price);
            Console.WriteLine(Laptop.GetAccountHistory());


        }
    }
}
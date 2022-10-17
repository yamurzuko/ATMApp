using System;

namespace ATMApp
{
    public class WithDrawalAction
    {
        private readonly Database database;
        public WithDrawalAction(Database database)
        {
            this.database = database;
        }

        public void Run(int customerId)
        {
            Console.WriteLine("Lütfen Çekmek İstediğiniz Miktarı Girin:");
            int amount = int.Parse(Console.ReadLine());

            database.WithDrawal(customerId, amount); 
        }
    }
}
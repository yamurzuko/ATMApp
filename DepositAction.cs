using System;

namespace ATMApp
{
    public class DepositAction
    {
        private readonly Database database;
        public DepositAction(Database database)
        {
            this.database = database;
        }

        public void Run(int customerId)
        {
            Console.WriteLine("Lütfen Yatırmak İstediğiniz Miktarı Girin:");
            int amount = int.Parse(Console.ReadLine());

            database.DepositMoney(customerId, amount); 
        }
    }
}
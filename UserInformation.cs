using System;

namespace ATMApp
{
    public class UserInformation
    {
        private int customerId;
        private string name;
        private string password;
        private int balance;

        public UserInformation(int customerId, string name, string password, int balance)
        {
            this.CustomerId = customerId;
            this.Name = name;
            this.Password = password;
            this.Balance = balance;
        }
        public int CustomerId { get => customerId; set => customerId = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public int Balance { get => balance; set => balance = value; }
    }
}

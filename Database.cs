using System;
using System.IO;

namespace ATMApp
{
    public class Database
    {
        private static List<UserInformation> userList;
        public Database()
        {
            userList = new List<UserInformation>()
            {
                new UserInformation(100, "Ugur", "ugur1234", 1000),
                new UserInformation(101, "İlker", "ilker1234", 2000),
                new UserInformation(102, "Ahmet", "ahmet1234", 500),
                new UserInformation(103, "Tuba", "tuba1234", 5489),
                new UserInformation(104, "Pelin", "pelin1234", 123234)
            };
        }
        public List<UserInformation> GetUserList()
        {
            return userList;
        }
        public void GetBalance(int customerId)
        {
            foreach (var item in userList)
            {
                if (item.CustomerId == customerId)
                {
                    Console.WriteLine("Güncel Bakiyeniz : {0}", item.Balance);
                }
            }
        }
        public bool CheckUser(int customerId, string password)
        {
            foreach (var item in userList)
            {
                if (item.CustomerId == customerId && item.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public void DepositMoney(int customerId, int amount)
        {
            foreach (var item in userList)
            {
                if (item.CustomerId == customerId)
                {
                    item.Balance += amount;
                    Console.WriteLine("Para Yatırma İşleminiz Gerçekleşmiştir.");
                    string message = item.CustomerId + " " + item.Balance + " TL hesabınıza yatırıldı.";
                    WriteFile(message);
                    break;
                }
            }
        }
        public void WithDrawal(int customerId, int amount)
        {
            foreach (var item in userList)
            {
                if (item.CustomerId == customerId)
                {
                    item.Balance -= amount;
                    Console.WriteLine("Para Çekme İşleminiz Gerçekleşmiştir..");
                    Console.WriteLine("{0} TL'yi para haznesinden alabilirsiniz. Kalan bakiyeniz {1}", amount, item.Balance);
                    string message = item.CustomerId + " " + amount + " TL çekildi.";
                    WriteFile(message);
                    break;
                }
            }
        }
        public void ReadFile()
        {
            string filePath = @"C:\Users\ugurcanyagmur\Projects\ATMApp\logger.pages";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(fs);

            string log = sr.ReadLine();

            while (log != null)
            {
                Console.WriteLine(log);
                log = sr.ReadLine();
            }

            sr.Close();
            fs.Close();
        }
        public void WriteFile(string message)
        {

            string filePath = @"C:\Users\ugurcanyagmur\Projects\ATMApp\" + DateTime.Now.ToString("dd.MM.yyyy") + ".pages";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(message);

            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
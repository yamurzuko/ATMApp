using System;

namespace ATMApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();

            while (true)
            {
                Console.WriteLine("Lütfen Müşteri Numaranızı Giriniz: ");
                int customerId = int.Parse(Console.ReadLine());
                Console.WriteLine("Lütfen şifrenizi giriniz: ");
                string customerPass = Console.ReadLine();

                if (database.CheckUser(customerId, customerPass))
                {
                    Console.WriteLine("Giriş Başarılı..");
                    database.GetBalance(customerId);
                    Console.WriteLine("**********************************");
                    Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:\n 1) Para yatırma \n 2) Para çekme \n 3) Çıkış");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            DepositAction depositMoney = new DepositAction(database);
                            depositMoney.Run(customerId);
                            break;
                        case "2":
                            WithDrawalAction withdrawal = new WithDrawalAction(database);
                            withdrawal.Run(customerId);
                            break;
                        case "3":
                            Console.Out.Close();
                            break;
                    }
                }
                else
                {
                    string message = "Müşteri numaranızı veya şifrenizi hatalı girdiniz. Tekrar deneyin.";
                    Console.WriteLine(message);
                    database.WriteFile(message);
                }
            }
        }
    }
}
namespace bank
{
    public class Account
    {
        public string? name { get; set; }
        public string? password { get; set; }
        public double balance { get; set; }
        public string? tckn { get; set; }
        
        public bool active { get; set; }
        
        public static List<Account> accounts { get; } = new List<Account>();
        
        public static void createUser()
        {
            Account account = new Account();
            Console.Clear();
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine()!;
            Thread.Sleep(500);
            if (name == "")
            {
                Console.WriteLine("Hata!");
                Thread.Sleep(1500);
                Program.Main();
            }
            Console.Clear();
            Console.WriteLine("Please enter your password: ");
            string password = Console.ReadLine()!;
            Thread.Sleep(500);
            Console.Clear();
            double balance = 0;
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Please enter your tckn: ");
            string tckn = Console.ReadLine()!;
            Thread.Sleep(500);
            Console.Clear();
            if (accounts.Any(x => x.tckn == tckn))
            {
                Console.WriteLine("Kullanıcı var!");
                Thread.Sleep(1500);
                Program.Main();
            }
            
            account.name = name;
            account.password = password;
            account.balance = balance;
            account.tckn = tckn;
            account.active = true;
            Console.Clear();
            
            Console.WriteLine("Your account has been created!");
            Thread.Sleep(1500);
            
            
            accounts.Add(account);
            Program.Main();
        }

        public static void login()
        {
            if (accounts.Count != 0)
            {
                Console.Clear();
                Thread.Sleep(500);
                Console.Write("Tc Kimlik Numaranız: ");
                string tckn = Console.ReadLine()!;
                Thread.Sleep(500);
                if (string.IsNullOrEmpty(tckn))
                {
                    Console.WriteLine("Hata!");
                    Thread.Sleep(1500);
                    Program.Main();
                }
                Console.Write("Şifreniz: ");
                string pw = Console.ReadLine()!;
                Thread.Sleep(500);
                int index = 0;
                foreach (var account in accounts)
                {
                    if (account.tckn == tckn)
                    {
                        if (!account.active)
                        {
                            Console.Clear();
                            Console.WriteLine("Hesabınız devre dışı!");
                            Thread.Sleep(1500);
                            Program.Main();
                        }
                        else if (pw == account.password)
                        {
                            string? username = account.name;
                            double userBalance = account.balance;
                            userLogged(username, userBalance, index);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Şifreniz yanlış.");
                            Thread.Sleep(500);
                            login();
                            break;
                        }
                    }
                    index++;
                }
                Console.WriteLine("Kullanıcı bulunamadı! Kayıt olmak ister misiniz? (E/H)");
                string answer = Console.ReadLine()!;
                if (answer == "E" || answer == "e" || answer == "Evet" || answer == "evet")
                {
                    createUser();
                }
                else if (answer == "h" || answer == "H" || answer == "hayir" || answer == "Hayir")
                {
                    Program.Main();
                }
                else
                {
                    Console.WriteLine("Geçersiz işlem! Ana ekrana dönüyorsunuz.");
                    Program.Main();
                }
                
                
            //     int count = 0;
            //     foreach (var account in accounts)
            //     {
            //         if (account.tckn != tckn)
            //             count++;
            //         else if (count == accounts.Count)
            //         {
            //             Console.WriteLine("Kullanıcı bulunamadı! Kayıt olmak ister misiniz? (E/H)");
            //             string answer = Console.ReadLine()!;
            //             if (answer == "E" || answer == "e" || answer == "Evet" || answer == "evet")
            //             {
            //                 createUser();
            //             }
            //             else if (answer == "h" || answer == "H" || answer == "hayir" || answer == "Hayir")
            //             {
            //                 Program.Main();
            //             }
            //             else
            //             {
            //                 Console.WriteLine("Geçersiz işlem! Ana ekrana dönüyorsunuz.");
            //                 Program.Main();
            //             }
            //         }
            //         else if (account.tckn == tckn && account.password == pw)
            //         {
            //             string username = account.name;
            //             double userBalance = account.balance!;
            //             userLogged(username, userBalance);
            //         }
            //         else
            //         {
            //             Program.Main(); calismadi :(
            //         }
            //     }
            }
            else
            {
                createUser();
            }
        }

        public static void userLogged(string? _name, double _balance, int _index)
        {
            Console.Clear();
            Thread.Sleep(1500);
            Console.WriteLine("Hoş geldin " + _name + "!");
            Console.WriteLine("Bakiyeniz: " + _balance + "TL");
            Console.WriteLine("1 --> Para çek");
            Console.WriteLine("2 --> Para yatır");
            Console.WriteLine("Q --> Çıkış Yap");
            string answer = Console.ReadLine()!;
            switch (answer)
            {
                case "1":
                    int count = 0;
                    do
                    {
                        Console.Clear();
                        Thread.Sleep(500);
                        Console.Write("Çekmek istediğiniz tutar: ");
                        int _answer = int.Parse(Console.ReadLine()!);
                        if (_answer > _balance || _answer < 0)
                        {
                            Console.WriteLine("Geçersiz işlem");
                            Thread.Sleep(500);
                            userLogged(_name, _balance, _index);
                        }
                        else
                        {
                            count++;
                            Console.Clear();
                            Console.WriteLine("Para Çekiliyor.");
                            _balance -= _answer;
                            Thread.Sleep(2000);
                            Console.Clear();
                            Account.accounts[_index].balance = _balance;
                            Console.WriteLine("Verilen para: " + _answer);
                            Console.WriteLine("Kalan Bakiyeniz: " + _balance);
                            Thread.Sleep(2500);
                            userLogged(_name, _balance, _index);
                        }
                    } while (count == 0);
                    count = 0;
                    break;
                case "2":
                    Console.Clear();
                    Thread.Sleep(500);
                    Console.Write("Yatırmak istediğiniz tutar: ");
                    int __answer = int.Parse(Console.ReadLine()!);
                    if (__answer < 0)
                        Console.WriteLine("Geçersiz.");
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Paranız yatırılıyor...");
                        Thread.Sleep(2500);
                        Console.Clear();
                        _balance += __answer;
                        Console.WriteLine("Yatırılan Para: " + __answer);
                        Console.WriteLine("Bakiyeniz: " + _balance);
                        Thread.Sleep(2500);
                        Account.accounts[_index].balance = _balance;
                        userLogged(_name, _balance, _index);
                    }
                    break;
                case "Q":
                    Console.WriteLine("Kendinize iyi bakın...");
                    Thread.Sleep(2500);
                    Program.Main();
                    break;
                case "q":
                    Console.WriteLine("Kendinize iyi bakın...");
                    Thread.Sleep(2500);
                    Program.Main();
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem.");
                    Thread.Sleep(2500);
                    userLogged(_name, _balance, _index);
                    break;
            }
        }
        
    }

    public class Admin
    {
        protected static string? username = "admin";
        protected static string? password = "admin";

        public static void login()
        {
            Console.Clear();
            string name = Console.ReadLine()!;
            string pw = Console.ReadLine()!;
            if (string.IsNullOrEmpty(name))
                Program.Main();
            else if (name == username)
            {
                if (password == pw)
                {
                    adminlogged();
                }
                else
                {
                    Program.Main();
                }
            }
            else
                Program.Main();
        }

        public static void adminlogged()
        {
            Console.Clear();
            Thread.Sleep(500);
            Console.WriteLine("1 -- All Users");
            Console.WriteLine("2 -- Active User");
            Console.WriteLine("3 -- Deactive User");
            Console.WriteLine("Q -- Quit");
            Console.WriteLine();
            int activeUser = 0;
            foreach (var account in Account.accounts) if (account.active == true) activeUser++;
            Console.WriteLine("Active User: " + activeUser);
            Console.WriteLine("All User Count: " + Account.accounts.Count);
            string answer = Console.ReadLine()!;
            switch (answer)
            {
                case "1":
                    Console.Clear();
                    for (int i = 0; i < Account.accounts.Count; i++)
                    {
                        var a = Account.accounts[i];
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Name: " + a.name);
                        Console.WriteLine("Password: " + a.password);
                        Console.WriteLine("Balance: " + a.balance);
                        Console.WriteLine("Tckn: " + a.tckn);
                        Console.WriteLine("Active: " + a.active);
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    adminlogged();
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Deaktif etmek istediğiniz kişinin tckn: ");
                    string tckn = Console.ReadLine()!;
                    int e = 0;
                    for (int i = 0; i < Account.accounts.Count; i++)
                    {
                        if (tckn == Account.accounts[i].tckn)
                        {
                            Account.accounts[i].active = false;
                            Console.WriteLine(Account.accounts[i].name+"'in hesabı deaktif edildi!");
                            Thread.Sleep(2500);
                            adminlogged();
                        }
                        else
                        {
                            e++;
                        }
                    }
                    if (e == Account.accounts.Count)
                    {
                        Console.WriteLine("Kullanıcı Bulunamadı");
                        Thread.Sleep(2500);
                        Console.Clear();
                    }
                    adminlogged();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("Aktif etmek istediğiniz kişinin tckn: ");
                    string _tckn = Console.ReadLine()!;
                    int _e = 0;
                    for (int i = 0; i < Account.accounts.Count; i++)
                    {
                        if (_tckn == Account.accounts[i].tckn)
                        {
                            Account.accounts[i].active = true;
                            Console.WriteLine(Account.accounts[i].name+"'in hesabı aktif edildi!");
                            Thread.Sleep(2500);
                            adminlogged();
                        }
                        else
                        {
                            _e++;
                        }
                    }
                    if (_e == Account.accounts.Count)
                    {
                        Console.WriteLine("Kullanıcı Bulunamadı");
                        Thread.Sleep(2500);
                        Console.Clear();
                    }
                    adminlogged();
                    break;
                case "Q":
                case "q":
                    Program.Main();
                    break;
                default:
                    adminlogged();
                    break;
            }
        }
    }
    public class Program
    {
        public static int a = 0;
        public static void Main()
        {
            //dummy
                Account account1 = new Account()
                {
                    name = "1",
                    password = "1",
                    tckn = "1",
                    active = false
                };
                Account account2 = new Account()
                {
                    name = "2",
                    password = "2",
                    tckn = "2",
                    active = true
                };

                if (Program.a == 0)
                {
                    Account.accounts.Add(account1);
                    Account.accounts.Add(account2);
                    Program.a = 1;
                }
            
            Console.Clear();
            Console.WriteLine("Welcome to iBank!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz: ");
            Console.WriteLine("1 --> Giriş Yap");
            Console.WriteLine("2 --> Kayıt Ol");
            string input = Console.ReadLine()!;
            switch (input)
            {
                case "2":
                    Account.createUser();
                    break;
                case "1":
                    Account.login();
                    break;
                case "admin":
                    Admin.login();
                    break;
                default:
                    Console.WriteLine("Hatalı giriş!");
                    Thread.Sleep(1500);
                    Program.Main();
                    break;
            }
            
            
            // Account.createUser();
            // var a = Account.accounts[0];
            // Console.WriteLine(a.name + a.password + a.balance + a.tckn);
            
        }
    }
}
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace BrutalForceProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Weclome to application for brutal force!");

            while (true)
            {
                int selection = ShowMenu();

                bool exit = false;

                switch (selection)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        CrackTheCode();
                        break;
                    default:exit = true;
                        break;
                }

                if (exit)
                {
                    break;
                }

            }
        }



        private static void CreateUser()
        {
            Console.WriteLine("Creates a user");

            Console.Write("Enter a username: ");
            string userName = Console.ReadLine();

            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            string hashedPassword = CreateMd5(password);

            Console.WriteLine(hashedPassword);
            Console.ReadLine();
            Console.Clear();
        }


        private static void CrackTheCode()
        {
            // 'a', ..., 'z', 'aa', ..., 'zz', 'aaa', ..., 'zzz'
            int maxLength = 3;

            for (int length = 1; length <= maxLength; ++length)
            {
                // initial combination "a...a" ('a' length times)
                StringBuilder Sb = new StringBuilder(new String('a', length));

                while (true)
                {
                    String value = Sb.ToString();
                    //TODO: Test MD5 here
                    // if (value.Equals(targetMD5)) {...}

                    // Is this the last combination? (all 'z' string)
                    if (value.All(item => item == 'z'))
                        break;

                    // Add one: aaa -> aab -> ... aaz -> aba -> ... -> zzz
                    for (int i = length - 1; i >= 0; --i)
                        if (Sb[i] != 'z')
                        {
                            Sb[i] = (Char)(Sb[i] + 1);

                            break;
                        }
                        else
                            Sb[i] = 'a';
                }
            }
        }

        private static string CreateMd5(string input)
        {
            MD5 mD5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = mD5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

       

        private static int ShowMenu()
        {
            Console.WriteLine("1. Skapa användare och lösenord");
            Console.WriteLine("2. Knäck lösenordet");
            Console.Write("Input selection: ");

            string input = Console.ReadLine();
            int.TryParse(input, out int selectedOption);
            return selectedOption;
        }
    }
}

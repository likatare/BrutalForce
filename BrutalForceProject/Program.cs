using System;

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
                        crackTheCode();
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

        private static void crackTheCode()
        {
            throw new NotImplementedException();
        }

        private static void CreateUser()
        {
            throw new NotImplementedException();
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

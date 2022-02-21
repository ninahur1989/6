using System;

namespace mag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            bool program = true;




            while (program)
            {
                string item;

                Console.WriteLine("Write one of case below");
                Console.WriteLine("Write what do ( Add / remove / confirm");
                string choise = Console.ReadLine();

                switch (choise.ToLower())
                {
                    case "add":

                        shop.Add();
                        break;
                    case "remove":
                        shop.Remove();
                        break;
                    case "confirm":

                        shop.Confirm();
                        break;

                }

            }

        }
    }
}

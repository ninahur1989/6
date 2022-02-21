using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace mag
{
    internal class Shop
    {
        List<Item> list = new List<Item>();
        List<Item> cart = new List<Item>();


        public Shop()
        {
            Random random = new Random();

            List<string> name = new List<string>() { "phone", "cake", "car", "balloon", "radio", "piano", "fork", "chocolate", "fridge", "pillow", "bottle", "piano", "bananas", "candle" };
            for (int y = 0; y < name.Count; y++)
            {
                list.Add(new Item(name[y], y, random.Next(10, 10000), random.Next(1, 11), 0));
            }
        }
        int sum = 0;
        int NumofOrder = 1;

        public void Add()
        {


            if (Check())
            {
                return;
            }
            if (sum == 10)
            {
                Console.WriteLine("\n  remove item if you want to continue or confirm your order");
                return;
            }

            ShowItemes(list, "current katalog include: ");
            Console.WriteLine("Chose item which you want to buy");

            string name = Console.ReadLine();

            Item item = list.Find(item => item.Name == name);

            if (item == default)
            {
                Console.WriteLine("not found this item in list");
                return;
            }
            Console.Clear();
            item.Show(item.Name);

            int amountOfItem;
            while (true)
            {
                Console.WriteLine($"how many {name} do you need?");
                if (!int.TryParse(Console.ReadLine(), out amountOfItem))
                {
                    Console.WriteLine("it isnt number!!");
                    continue;
                }

                if (amountOfItem > 0 && amountOfItem <= item.Amount)
                {
                    if (!cart.Contains(item))
                    {
                        cart.Add(item);

                    }

                    for (int i = 0; i < amountOfItem; amountOfItem--, item.Amount--)
                    {
                        item.CardAmount++;
                        sum++;
                    }
                    if (item.Amount == 0)
                    {
                        list.Remove(item);
                        break;
                    }
                    break;
                }
            }
        }
        public void Remove()
        {
            Console.Clear();
            ShowItemes(cart, " what do you want to remove from your Shopping basket : ");
            string name = Console.ReadLine();
            Item item = cart.Find(item => item.Name == name);

            if (item == default)
            {
                Console.WriteLine("not found this item in list");
                return;
            }
            item.Show(item.Name);

            int amountOfItem;

            while (true)
            {
                Console.WriteLine($"how many {name} do you need?");
                if (!int.TryParse(Console.ReadLine(), out amountOfItem))
                {
                    Console.WriteLine("it isnt number!!");
                    continue;
                }

                if (amountOfItem > 0 && amountOfItem <= item.CardAmount)
                {
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                    for (int i = 0; i < amountOfItem; amountOfItem--, item.CardAmount--)
                    {
                        item.Amount++;
                        sum--;
                    }
                    if (item.CardAmount == 0)
                    {
                        cart.Remove(item);
                        break;
                    }
                    break;
                }
            }
        }

        public void Confirm()
        {
            if (Check())
            {
                return;
            }

            Console.Clear();
            Console.WriteLine("Your order is confirmed");
            string msg = "";
            foreach (Item item in cart)
            {
                Console.WriteLine($"{item.Name} in you card in amount {item.CardAmount}  ");
            }

            foreach (Item it in cart)
            {
                it.CardAmount = 0;
                msg += it + "\n";
            }
            sum = 0;
            cart.Clear();

            File.AppendAllText(@"C:\Users\Admin\source\repos\magaz\magaz\magaz.csproj", " " + "num od your order is: " + NumofOrder + " \n" + msg);
            NumofOrder++;

            Console.WriteLine("Press any button if you want to continue");
            Console.ReadKey();
        }
        void ShowItemes(List<Item> list, string b)
        {
            Console.WriteLine(b);

            foreach (Item it in list)
            {
                Console.WriteLine(it.Name);
            }

            Console.WriteLine("------------------------------------------------");
        }

        bool Check()
        {

            if (sum > 10)
            {
                Console.WriteLine("Your Shopping basket is overloaded\n");
                foreach (Item d in cart)
                {
                    Console.WriteLine($"{d.Name} in you card in amount {d.CardAmount}  ");
                }
                Console.WriteLine($"\n you have to remove {sum - 10 } items from your card ");
                return true;

            }
            else
                return false;
        }
    }
}

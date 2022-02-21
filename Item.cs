using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mag
{
    public class Item
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int CardAmount { get; set; }

        public Item(string name, int id, int price, int amount, int cardAmount)
        {
            Name = name;
            Id = id;
            Price = price;
            Amount = amount;
            CardAmount = cardAmount;
        }

        public void Show(string name)
        {
            Console.WriteLine($"{Name } cost {Price} \n and have ID: {Id}\n in stock we have {Amount} \n in your card {CardAmount}");
        }
    }
}

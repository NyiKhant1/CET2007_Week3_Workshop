using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Week3_Workshop
{
    abstract class MenuItem
    {
        private string name;
        private double price;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Price cannot be negative or empty");
            }
        }
        protected MenuItem(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public virtual void Describe()
        {
            Console.WriteLine(name + " Price: £ " + price);
        }
        abstract public double CalculateTotal(int quantity);


    }

    class Meal : MenuItem
    {
        public Meal(string name, double price) : base (name, price)
        {}
        public override void Describe()
        {
            Console.WriteLine(" Meal: ");
            base.Describe();
        }
        public override double CalculateTotal(int quantity)
        {
            double SubTotal = quantity * Price;
            double tax = SubTotal * 0.10;
            return SubTotal + tax;
            //return SubTotal;

        }
    }

    class Drink : MenuItem
    {
        public Drink(string name, double price) : base(name, price)
        { }
        public override void Describe()
        {
            Console.WriteLine(" Drink: ");
            base.Describe();
        }
        public override double CalculateTotal(int quantity)
        {
            double SubTotal = quantity * Price;
            double tax = SubTotal * 0.05;
            return SubTotal + tax;
            //return SubTotal;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuItem[] fleet = new MenuItem[3];
            fleet[0] = new Meal("Burger", 5.99);
            fleet[1] = new Drink("Cola (500 ml)", 1.50);
            fleet[2] = new Meal("Pizza", 7.99);
            Console.WriteLine("___Menu___");
            for (int i = 0; i < fleet.Length; i++)
            {
                fleet[i].Describe();
            }
            // Ask Customer to choose Item
            int Choice;
            while (true)
            {
                Console.WriteLine("Please Choose an Item 0 = Burger, 1 = Cola, 2 = Pizza");
                string s = Console.ReadLine();
                if (int.TryParse(s, out Choice) && Choice >= 0 && Choice < 3) break;
                Console.WriteLine("Invalid Input, Please try againg");
            }
            MenuItem selected = fleet[Choice];

            // Ask Customer to enter quantity
            int EnterQuantity;
            while (true)
            {
                Console.WriteLine("Please Enter the Quantity");
                string s = Console.ReadLine();
                if (int.TryParse(s, out EnterQuantity) && EnterQuantity >= 1 && EnterQuantity <= 40) break;
                Console.WriteLine("Invalid Input, Please try againg");
            }
            double Total = selected.CalculateTotal(EnterQuantity);
            Console.WriteLine(Math.Round(Total, 2));


        }
    }
}

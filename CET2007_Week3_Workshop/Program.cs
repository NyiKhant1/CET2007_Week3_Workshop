using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Week3_Workshop
{
    class MenuItem
    {
        private string name;
        private string price;

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
        public string Price
        {
            get { return price; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Price cannot be empty");
                price = value;
            }
        }
        protected MenuItem(string name, string price)
        {
            this.name = name;
            this.price = price;
        }
        public virtual void Describe()
        {
            Console.WriteLine(name + " Price: " + price);

        }
     

    }

    class Meal : MenuItem
    {
        public Meal(string name, string price) : base (name, price)
        {}
        public override void Describe()
        {
            Console.WriteLine(" Meal: ");
            base.Describe();
        }
        
        
    }

    class Drink : MenuItem
    {
        public Drink(string name, string price) : base(name, price)
        { }
        public override void Describe()
        {
            Console.WriteLine(" Drink: ");
            base.Describe();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuItem[] fleet = new MenuItem[3];
            fleet[0] = new Meal("Burger", "£5.99");
            fleet[1] = new Drink("Cola (500 ml)", "£1.50");
            fleet[2] = new Meal("Pizza", "£7.99");
            Console.WriteLine("___Menu___");
            for (int i = 0; i < fleet.Length; i++)
            {
                fleet[i].Describe();
            }
        }
    }
}

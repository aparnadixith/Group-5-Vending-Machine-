using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vending_Machine;

namespace Vending_Machine
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        protected Product (int id, string name, int cost)
        {
            Id = id;
            Name = name;
            Cost = cost;

        }

        public abstract string Examine();
        public abstract string Use();
    }
}

public class Drink : Product
{
     public int Volume { get; set; }
    //public string Flavor { get; set; }
    public Drink (int id, string name, int cost, int volume)
        :base(id, name, cost)
    {
        Volume = volume;
    }
    public override string Examine()
    {
        return $"Drink: {Name}, Cost: {Cost}kr, Volume: {Volume}ml";
    }
 
    public override string Use()
    {
        return $"You drink the {Name}";
    }
}
public class Snack : Product
{
    public string Size { get; set; }
    public Snack(int id, string name, int cost, string size)
        :base(id, name, cost)
    {
        Size = size;
    }

    public override string Examine()
    {
        return $"Snack: {Name}, Cost: {Cost}kr, Size: {Size}";
    }

    public override string Use()
    {
        return $"You eat the {Size} chips.";
    }
}
public class Toy : Product
{
    public string Material{ get; set; }
    public Toy(int id, string name, int cost, string material)
        :base(id, name, cost)
    {
        Material = material;
    }

    public override string Examine()
    {
        return $"Toy: {Name}, Cost: {Cost}kr, Material: {Material}%";
    }

    public override string Use()
    {
        return $"You play with the {Material} material.";
    }
}


using System;

class Item
{
    public string Name { get; set; }
    public int CurrentStock { get; set; }
    public int RestockThreshold { get; set; }

    public Item(string name, int initialStock, int restockThreshold)
    {
        Name = name;
        CurrentStock = initialStock;
        RestockThreshold = restockThreshold;
    }

    public void CheckRestock()
    {
        if (CurrentStock <= RestockThreshold)
        {
            Console.WriteLine($"Restock {Name} needed!");
        }
    }
}

class Program
{
    static void Main()
    {
        Item[] items = {
            new Item("Soda", 100, 40),
            new Item("Chips", 40, 20),
            new Item("Candy", 60, 40)
        };

        foreach (var item in items)
        {
            Console.Write($"How many {item.Name} have been sold today? {item.CurrentStock} in stock: ");
            if (int.TryParse(Console.ReadLine(), out int sold))
            {
                if (sold <= item.CurrentStock)
                {
                    item.CurrentStock -= sold;
                    Console.WriteLine($"Remaining stock of {item.Name}: {item.CurrentStock}");
                }
                else
                {
                    Console.WriteLine("Too high - stock not adjusted.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        Console.WriteLine("\nRestocking Status:");
        foreach (var item in items)
        {
            item.CheckRestock();
        }
    }
}
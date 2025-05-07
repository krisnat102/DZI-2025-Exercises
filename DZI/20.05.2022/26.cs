namespace ConsoleApp1._05._2022;

public class Item : IComparable<Item> {
    public Item(string description, float price)
    {
        if(description == "" || price <= 0) throw new Exception("Wrong data");
            
        this.description = description;
        this.price = price;
    }

    private readonly string description;
    private readonly float price;
    
    public int CompareTo(Item? other)
    {
        if (other.description.Length > description.Length) return -1;
        else if (other.description.Length < description.Length) return 1;
        else if (other.price > this.price) return -1;
        else return 0;
    }

    public override string ToString()
    {
        return $"{description} ({price})";
    }
}

public class ItemList
{
    public List<Item> items = new List<Item>();
    
    public int Count => items.Count;

    public Item Get(int i)
    {
        try
        {
            return items[i];
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("IndexOutOfRangeException");
            return null;
        }
    }
    
    public void Add(Item item)
    {
        if (items.Contains(item))
        {
            throw new Exception("Item already exists");
        }
            
        items.Add(item);
        items.Sort();
    }
}

public class Input
{
    /*public void InsertData(string path)
    {
        StreamReader reader = new StreamReader(path);
        ItemList list = new ItemList();
        var line = reader.ReadLine();
        int itemNum = int.Parse(line);

        while (itemNum != 0)
        {
            itemNum--;

            line = reader.ReadLine();
            var input = line.Split(' ');

            try
            {
                Item item = new Item(input[0], int.Parse(input[1]));
                list.Add(item);
            }
            catch
            {
                throw new Exception("Wrong data");
            }
        }

        foreach (var item in list.items)
        {
            Console.WriteLine(item.ToString());
        }

        reader.Close();
    }*/

    public void InsertData()
    {
        ItemList list = new ItemList();
        
        try
        {
            int itemNum = int.Parse(Console.ReadLine());

            while (itemNum != 0)
            {
                itemNum--;

                var input = Console.ReadLine().Split(' ');

                Item item = new Item(input[0], int.Parse(input[1]));
                list.Add(item);
            }
        }
        catch
        {
            throw new Exception("Wrong data");
        }
        
        foreach (var item in list.items)
        {
            Console.WriteLine(item.ToString());
        }
    }

    /*public static void Main(string[] args)
    {
        Input input = new Input();
        input.InsertData("C:\\Users\\alcho\\RiderProjects\\ConsoleApp1\\ConsoleApp1\\05.2022\\items.txt");
    }*/
}
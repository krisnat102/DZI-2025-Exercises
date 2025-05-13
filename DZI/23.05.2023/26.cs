namespace ConsoleApp1._05._2023;

public class _26
{
    private List<string> list = new();

    private void CommandManager()
    {
        var input = Console.ReadLine().Split(' ', 2);
        
        switch (input[0])
        {
            case "Add":
                Add(input[1]);
                break;
            case "Remove":
                Remove(int.Parse(input[1]));
                break;
            case "Search":
                Search(input[1]);
                break;
            case "Insert":
                var insert = input[1].Split(' ');
                Insert(int.Parse(insert[0]), insert[1]);
                break;
            case "Length":
                Length(int.Parse(input[1]));
                break;
            case "Update":
                Update();
                break;
            case "Print":
                Print();
                break;
            case "END":
                return;
        }
        
        CommandManager();
    }

    private void Add(string s)
    {
        var words = s.Split(' ');

        foreach (var word in words)
        {
            list.Add(word);
        }
    }

    private void Remove(int i) => list.RemoveAt(i);

    private void Search(string s) => Console.WriteLine(list.Contains(s) ? s : "Not contained");

    private void Insert(int i, string s)
    {
        try
        {
            list.Insert(i, s);
        }
        catch (Exception e)
        {
            Console.WriteLine("There are not enough items in the list.");
        }
    }

    private void Length(int i)
    {
        bool counter = false;
        
        foreach (var c in list)
        {
            if (c.Length == i)
            {
                if (counter) Console.Write("-");
                Console.Write(c);
                counter = true;
            }
        }
        
        if (!counter) Console.WriteLine("Not contained");
    }

    private void Update()
    {
        for (int i = 0; i < list.Count; i++)
        {
            var upper = Char.ToUpper(list[i][0]);
            list[i] = list[i].Remove(0, 1);
            list[i] = upper + list[i];
        }
    }

    private void Print()
    {
        bool counter = false;
        
        foreach (var c in list)
        {
            if (counter) Console.Write("; ");
            Console.Write(c);
            counter = true;
        }
    }

    public static void Main(string[] args)
    {
        _26 cmd = new _26();
        cmd.CommandManager();
    }
}
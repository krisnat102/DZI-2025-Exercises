using System.Collections;

public class Note : IComparable
{
    private readonly string values = "A BbB C C#D D#E F#G G#";
    public string Name { get; set; }
    public char Octave { get; set; }
    public int Duration { get; set; }

    public Note(string name, char octave, int dur)
    {
        Name = name;
        Octave = octave;
        Duration = dur;
    }

    public Note(string s)
    {
        var parts = s.ToCharArray();
        Name = parts[0] + "";
        Octave = parts[1];
        Duration = parts[2];
    }

    public override string ToString()
    {
        return Name + Octave;
    }

    public int CompareTo(object obj)
    {
        if (obj is Note other)
        {
            return String.Compare(Name + Octave, other.Name + other.Octave, StringComparison.Ordinal);
        }
        throw new ArgumentException("Object is not a Note");
    }
}

public class Instrument
{
    public string Name { get; set; }
    public string Kind { get; set; }
    private Note lowest;
    private Note highest;

    public Instrument(string k, string nm, Note low, Note high)
    {
        Name = nm;
        Kind = k;
        lowest = low;
        highest = high;
    }

    public Note GetLowest()
    {
        return lowest;
    }

    public Note GetHighest()
    {
        return highest;
    }

    public override string ToString()
    {
        return Name;
    }

    public int CompareTo(object obj)
    {
        if (obj is Instrument other)
        {
            return String.Compare(Name, other.Name, StringComparison.Ordinal);
        }
        throw new ArgumentException("Object is not a Note");
    }
}


public class Chordophone : Instrument
{
    public Chordophone(string name, Note low, Note high) : base("Chordophone", name, low, high)
    {
    }
}

public class Aerophone : Instrument
{
    protected string subKind;
    public Aerophone(string name, Note low, Note high) : base("Aerophone", name, low, high)
    {
    }

    public override global::System.String ToString()
    {
        return base.ToString();
    }
}

public class Woodwind : Aerophone
{
    public Woodwind(string name, Note low, Note high) : base(name, low, high)
    {
        subKind = "Woodwind";
    }
}

public class Brass : Aerophone
{
    public Brass(string name, Note low, Note high) : base(name, low, high)
    {
        subKind = "Brass";
    }
}

public class Test
{
    public static void Main(string[] args)
    {
        string lines = Console.ReadLine();
        List<Instrument> instruments = new();

        for (int i = 0; i < lines.Length; i++)
        {
            string input = Console.ReadLine();
            var inputs = input.Split(' ');
            inputs[0].ToLower();
            Instrument instrument;
            Note note1 = new Note(inputs[2]);
            Note note2 = new Note(inputs[3]);

            switch (inputs[0])
            {
                case "c":
                    instrument = new Chordophone(inputs[1], note1, note2);
                    instruments.Add(instrument);
                    break;
                case "w":
                    instrument = new Woodwind(inputs[1], note1, note2);
                    instruments.Add(instrument);
                    break;
                case "b":
                    instrument = new Brass(inputs[1], note1, note2);
                    instruments.Add(instrument);
                    break;
            }
        }

        IEnumerable sorted =
            from inst in instruments
            orderby inst.Name
            select inst;

        foreach (var inst in sorted)
        {
            Console.WriteLine(inst);
        }
    }
}



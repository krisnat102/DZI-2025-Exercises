namespace ConsoleApp1._08._2024;

public abstract class ClubMember
{
    public ClubMember(string firstName, string lastName, int age, float salary)
    {
        if (firstName == "" || lastName == "") throw new Exception("The name can’t be an empty string!");
        if (age < 18) throw new Exception("Age must be greater than 17 years");
        if (salary < 0) throw new Exception("Salary must be a positive number!");
        
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }
    
    public string firstName;
    public string lastName;
    public int age;
    public float salary;
    
    public abstract void Info();
}

public class Director : ClubMember
{
    public string directorType;

    public Director(string firstName, string lastName, int age, float salary, string directorType) : base(firstName, lastName, age, salary)
    {
        this.directorType = directorType;
    }

    public override void Info()
    {
        Console.WriteLine($"{directorType} director: {firstName} {lastName}");
        Console.WriteLine($"salary {salary}lv");
        Console.WriteLine($"age {age} years");
    }
}

public class Coach : ClubMember
{
    private string coachType;
    private int coachLength;

    public Coach(string firstName, string lastName, int age, float salary, string coachType, int coachLength) : base(firstName, lastName, age, salary)
    {
        this.coachType = coachType;
        this.coachLength = coachLength;
    }

    public override void Info()
    {
        Console.WriteLine($"{coachType} coach: {firstName} {lastName}");
        Console.WriteLine($"salary {salary}lv");
        Console.WriteLine($"age {age} years");
    }
}

public class FootballPlayer : ClubMember
{
    private string position;
    private int contactLength;
    private int matches;
    public int goals;
    private int assists;

    public FootballPlayer(string firstName, string lastName, int age, float salary, string position, int contactLength, int matches, int goals, int assists) : base(firstName, lastName, age, salary)
    {
        this.position = position;
        this.contactLength = contactLength;
        this.matches = matches;
        this.goals = goals;
        this.assists = assists;
    }

    public override void Info()
    {
        Console.WriteLine($"{firstName} {lastName}: {position}");
        Console.WriteLine($"salary {salary}lv");
        Console.WriteLine($"age {age} years");
        Console.WriteLine($"{goals} goals and {assists} assists in {matches} matches");
    }
}

public class ClubManager
{
    private List<ClubMember> members = new List<ClubMember>();
    private List<FootballPlayer> footbalPlayers = new List<FootballPlayer>();
    
    private void FileReader(string file)
    {
        StreamReader reader = new StreamReader(file);
        var input = reader.ReadLine();

        while (!reader.EndOfStream)
        {
            CreateMember(input);
            
            input = reader.ReadLine();
        }
    }
    
    private void CreateMember(string input)
    {
        var data = input.Split(' ');

        ClubMember member;

        try
        {
            switch (data[0])
            {
                case "Coach":
                    member = new Coach(data[1], data[2], int.Parse(data[3]), float.Parse(data[4]), data[5], int.Parse(data[6]));
                    break;
                case "FootballPlayer":
                    member = new FootballPlayer(data[1], data[2], int.Parse(data[3]), float.Parse(data[4]), data[5], int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]), int.Parse(data[9]));
                    FootballPlayer player = new FootballPlayer(data[1], data[2], int.Parse(data[3]), float.Parse(data[4]), data[5], int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]), int.Parse(data[9]));
                    footbalPlayers.Add(player);
                    break;
                default:
                    member = new Director(data[1], data[2], int.Parse(data[3]), float.Parse(data[4]), data[5]);
                    break;
            }
            
            members.Add(member);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    private void OrderMembers()
    {
        members = (from member in members
                  orderby member.age
                  select member).ToList();
    }

    private void PrintList()
    {
        foreach (var member in members)
        {
            member.Info();
            Console.WriteLine("********************");
        }
    }

    private void BonusInfo()
    {
        var highestSalary =
            (from member in members
                orderby member.salary descending
                select member).ToList()[0];
        Console.WriteLine($"The person with the highest salary in the club is {highestSalary.firstName} {highestSalary.lastName} with {highestSalary.salary} lv salary.");
        
        var topScorer =
            (from player in footbalPlayers
                orderby player.goals descending
                select player).ToList()[0];
            Console.WriteLine($"The team's top scorer is {topScorer.firstName} {topScorer.lastName} with {topScorer.goals} goals.");
    }

    public static void Main(string[] args)
    {
        ClubManager clubManager = new ClubManager();
        clubManager.FileReader("C:\\Users\\alcho\\RiderProjects\\ConsoleApp1\\ConsoleApp1\\08.2024\\input.txt");
        clubManager.OrderMembers();
        clubManager.PrintList();
        clubManager.BonusInfo();
    }
}

using System.Diagnostics;

public class Human
{
    private readonly string firstName;
    private readonly string lastName;
    private readonly int age;

    public Human(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{firstName} {lastName}, {age} years old";
    }
}

public class Student : Human
{
    private readonly float grade;

    public Student(string firstName, string lastName, int age, float grade) : base(firstName, lastName, age)
    {
        this.grade = MathF.Round(grade, 2);
    }

    public override string ToString()
    {
        return base.ToString() + $", grade: {grade}";
    }
}

public class Worker : Human
{
    private readonly float wage;
    private readonly int workHours;

    public Worker(string firstName, string lastName, int age, float wage, int workHours) : base(firstName, lastName, age)
    {
        this.wage = MathF.Round(wage, 2);
        this.workHours = workHours;
    }

    public float Salary()
    {
        return wage * workHours;
    }

    public override string ToString()
    {
        return base.ToString() + $", salary: {wage}";
    }
}

public class Zad26
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var list = new List<Human>();

        for (int i = 0; i < n; i++)
        {
            string fName = Console.ReadLine();
            string lName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            char type = char.Parse(Console.ReadLine());

            switch (type)
            {
                case 'w':
                    float wage = float.Parse(Console.ReadLine());
                    int hours = int.Parse(Console.ReadLine());
                    var worker = new Worker(fName, lName, age, wage, hours);
                    list.Add(worker);
                    break;
                case 's':
                    float grade = float.Parse(Console.ReadLine());
                    var student = new Student(fName, lName, age, grade);
                    list.Add(student);
                    break;
            }
        }

        foreach (var person in list)
        {
            Console.WriteLine(person.ToString());
        }
    }
}


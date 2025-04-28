
using System.Diagnostics;

namespace ConsoleApp1
{
    public abstract class AcademyMember
    {
        private string firstName;
        private string lastName;
        protected int age;
        private float salary;

        public string FirstName { get => firstName; private set => firstName = value; }
        public string LastName { get => lastName; private set => lastName = value; }
        public float Salary { get => salary; private set => salary = value; }

        protected AcademyMember(string firstName, string lastName, int age, float salary)
        {
            if (firstName == "" || lastName == "")
            {
                Console.WriteLine("The name can’t be an empty string!");
                return;
            }
            if (age <= 16)
            {
                Console.WriteLine("Age must be greater than 16 years!");
                return;
            }
            if (salary < 0)
            {
                Console.WriteLine("Salary must be a positive number!");
                return;
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.age = age;
            this.Salary = salary;
        }

        public abstract void Info();
    }

    public class Director : AcademyMember
    {
        private string directorType;

        public Director(string firstName, string lastName, int age, float salary, string directorType) : base(firstName, lastName, age, salary)
        {
            this.directorType = directorType;
        }

        public override void Info()
        {
            Console.WriteLine($"Name: {FirstName} {LastName} age: {age} director type: {directorType.ToString()} salary: {Salary}");
        }
    }

    public class Coach : AcademyMember
    {
        private string sportType;
        private int experienceYears;

        public Coach(string firstName, string lastName, int age, float salary, string sportType, int experienceYears) : base(firstName, lastName, age, salary)
        {
            this.sportType = sportType;
            this.experienceYears = experienceYears;
        }

        public override void Info()
        {
            Console.WriteLine($"Name: {FirstName} {LastName} age: {age} sport type: {sportType.ToString()} salary: {Salary} experience: {experienceYears}");
        }
    }

    public abstract class Athlete : AcademyMember
    {
        protected string sportType;
        protected int matchesPlayed;

        public Athlete(string firstName, string lastName, int age, float salary, string sportType, int matchesPlayed) : base(firstName, lastName, age, salary)
        {
            this.sportType = sportType;
            this.matchesPlayed = matchesPlayed;
        }

        public abstract void PerformanceStats();
    }

    public class FootballPlayer : Athlete
    {
        private int goalsScored;
        private int assists;

        public FootballPlayer(string firstName, string lastName, int age, float salary, string sportType, int matchesPlayed, int goalsScored, int assists) : base(firstName, lastName, age, salary, sportType, matchesPlayed)
        {
            this.goalsScored = goalsScored;
            this.assists = assists;
        }

        public override void Info()
        {
            Console.WriteLine($"Name: {FirstName} {LastName} age: {age} salary: {Salary} sport type: {sportType}");
        }

        public override void PerformanceStats()
        {
            Console.WriteLine($"Name: {FirstName} {LastName} sport type: {sportType} matches played: {matchesPlayed} goals scored: {goalsScored} assists: {assists}");
        }
    }

    public class BasketballPlayer : Athlete
    {
        private int pointsScored;
        private int rebounds;

        public BasketballPlayer(string firstName, string lastName, int age, float salary, string sportType, int matchesPlayed, int pointsScored, int rebounds) : base(firstName, lastName, age, salary, sportType, matchesPlayed)
        {
            this.pointsScored = pointsScored;
            this.rebounds = rebounds;
        }

        public override void Info()
        {
            Console.WriteLine($"Name: {FirstName} {LastName} age: {age} salary: {Salary} sport type: {sportType}");
        }

        public override void PerformanceStats()
        {
            Console.WriteLine($"Name: {FirstName} {LastName} sport type: {sportType} matches played: {matchesPlayed} points scored: {pointsScored} rebounds: {rebounds}");
        }
    }

    public class TennisPlayer : Athlete
    {
        private int tournamentsWon;
        private int rank;

        public TennisPlayer(string firstName, string lastName, int age, float salary, string sportType, int matchesPlayed, int tournamentsWon, int rank) : base(firstName, lastName, age, salary, sportType, matchesPlayed)
        {
            this.tournamentsWon = tournamentsWon;
            this.rank = rank;
        }

        public override void Info()
        {
            Console.WriteLine($"Name: {FirstName} {LastName} age: {age} salary: {Salary} sport type: {sportType}");
        }

        public override void PerformanceStats()
        {
            Console.WriteLine($"Name: {FirstName} {LastName} sport type: {sportType} matches played: {matchesPlayed} tournaments won: {tournamentsWon} rank: {rank}");
        }
    }

    public class AcademyManager
    {
        public void Test()
        {
            StreamReader reader = new StreamReader("academy_data.txt");
            var members = new List<AcademyMember>();

            var line = reader.ReadLine();

            while (line != null)
            {
                string[] inputs = line.Split(',');

                AcademyMember member;
                
                switch (inputs[0])
                {
                    case "Director":
                        member = new Director(inputs[1], inputs[2], int.Parse(inputs[3]), int.Parse(inputs[4]), inputs[5]);
                        break;
                    case "Coach":
                        member = new Coach(inputs[1], inputs[2], int.Parse(inputs[3]), int.Parse(inputs[4]), inputs[5], int.Parse(inputs[6]));
                        break;
                    case "FootballPlayer":
                        member = new FootballPlayer(inputs[1], inputs[2], int.Parse(inputs[3]), int.Parse(inputs[4]), inputs[5], int.Parse(inputs[6]), int.Parse(inputs[7]), int.Parse(inputs[8]));
                        break;
                    case "BasketballPlayer":
                        member = new FootballPlayer(inputs[1], inputs[2], int.Parse(inputs[3]), int.Parse(inputs[4]), inputs[5], int.Parse(inputs[6]), int.Parse(inputs[7]), int.Parse(inputs[8]));
                        break;
                    case "TennisPlayer":
                        member = new FootballPlayer(inputs[1], inputs[2], int.Parse(inputs[3]), int.Parse(inputs[4]), inputs[5], int.Parse(inputs[6]), int.Parse(inputs[7]), int.Parse(inputs[8]));
                        break;
                    default:
                        member = new Director(inputs[1], inputs[2], int.Parse(inputs[3]), int.Parse(inputs[4]), inputs[5]);
                        break;
                }
                members.Add(member);

                line = reader.ReadLine();
            }

            var sortedMembers = from member in members
                                orderby member.FirstName, member.LastName
                                select member;

            foreach (var member in sortedMembers)
            {
                member.Info();
            }

            var bestPaid = members.Max(y => y.Salary);
            Console.WriteLine(bestPaid);

            reader.Close();
        }
    }
}

/*
Задача 3: Задание: Управление на Академия за Спортни Таланти
Създайте обектно-ориентирано приложение за Академия за спортни таланти, в която работят директори, треньори и атлети. Атлетите могат да бъдат футболисти, баскетболисти и тенисисти. Програмата трябва да извършва обработка на данни от файл, сортиране, статистика и валидации.
Изисквания към класовете:
1) Абстрактен клас AcademyMember (основен клас)
	Полета:
•	firstName (име) – низ
•	lastName (фамилия) – низ
•	age (възраст) – цяло число
•	salary (заплата) – реално число
	Методи:
•	Конструктор с валидации:
o	Името не може да е празен низ → “The name can’t be an empty string!”
o	Възрастта трябва да е над 16 → “Age must be greater than 16 years!”
o	Заплатата трябва да е положително число → “Salary must be a positive number!”
•	Абстрактен метод info()
2) Клас Director (наследява AcademyMember)
	 Допълнително поле:
•	directorType (вид директор) – една от стойностите: executive, technical, sports
	 Методи:
•	Конструктор
•	Предефиниран info()
3) Клас Coach (наследява AcademyMember)
	Допълнителни полета:
•	sportType (спорт) – една от стойностите: football, basketball, tennis
•	experienceYears (години опит) – цяло число
	Методи:
•	Конструктор
•	Предефиниран info()
4) Абстрактен клас Athlete (наследява AcademyMember)
	Допълнителни полета:
•	sportType (спорт)
•	matchesPlayed (изиграни мачове)
	 Методи:
•	Конструктор
•	Абстрактен метод performanceStats()
5) Клас FootballPlayer (наследява Athlete)
	 Допълнителни полета:
•	goalsScored (брой голове)
•	assists (асистенции)
	 Методи:
•	Конструктор
•	Предефиниран info()
•	Реализация на performanceStats()
6) Клас BasketballPlayer (наследява Athlete)
	 Допълнителни полета:
•	pointsScored (вкарани точки)
•	rebounds (борби)
	 Методи:
•	Конструктор
•	Предефиниран info()
•	Реализация на performanceStats()
7) Клас TennisPlayer (наследява Athlete)
	Допълнителни полета:
•	tournamentsWon (спечелени турнири)
•	rank (ранг)
	 Методи:
•	Конструктор
•	Предефиниран info()
•	Реализация на performanceStats()
8) Основен клас AcademyManager
	Чете данни от файл academy_data.txt
	 Сортира и отпечатва информацията
	 Намира:
•	Най-високо платен член
•	Атлетът с най-добра статистика във всеки спорт*/



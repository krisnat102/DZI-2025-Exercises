namespace School
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        public string brand;
        public int hPower;

        public Car(string brand, int hPower)
        {
            this.brand = brand;
            this.hPower = hPower;
        }

        public override string ToString()
        {
            return $"{brand}, {hPower}";
        }
    }

    public class Pilot
    {
        public string name;
        public int age;
        public Car carp;
        public string category;

        public Pilot(string name, int age, Car carp, string category)
        {
            this.name = name;
            this.age = age;
            this.carp = carp;
            this.category = category;
        }

        public override string ToString()
        {
            return $"{name}, {age}, {category}, {carp.brand}, {carp.hPower}";
        }
    }

    public class Rally
    {
        private string name;
        private int year;
        private List<Pilot> pilots;

        public Rally(string name, int year, List<Pilot> pilots)
        {
            this.name = name;
            this.year = year;
            this.pilots = pilots;
        }

        public void AddParticipant(Pilot pilot)
        {
            pilots.Add(pilot);
        }

        public void PrintInformation()
        {
            Console.WriteLine($"Rally: {name} - {year}");
            foreach (Pilot pilot in pilots)
            {
                Console.WriteLine($"{pilot.name}, {pilot.age}, {pilot.category}, {pilot.carp.brand}, {pilot.carp.hPower}");
            }
        }
    }

    public class Main
    {
        public void MakeRally()
        {
            string name = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());

            var list = new List<Pilot>();

            Rally rally = new Rally(name, year, list);

            string input = Console.ReadLine();

            while (input != "q")
            {
                switch (input)
                {
                    case "a":
                        string pilotName = Console.ReadLine();
                        int age = int.Parse(Console.ReadLine());
                        string category = Console.ReadLine();
                        string carModel = Console.ReadLine();
                        int carPower = int.Parse(Console.ReadLine());
                        var car = new Car(carModel, carPower);
                        var pilot = new Pilot(pilotName, age, car, category);
                        rally.AddParticipant(pilot);
                        break;
                    case "v":

                        rally.PrintInformation();
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }

    public class Test
    {
        static public void Main(string[] args)
        {
            Main main = new Main();

            main.MakeRally();
        }
    }
}

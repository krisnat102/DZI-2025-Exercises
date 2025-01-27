using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peev.DZI._20._05._2024
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string id;

        public Person(string firstName, string lastName, string id)
        {
            if(id.Length != 10)
            {
                Console.WriteLine($"{firstName} {lastName} - invalid identifier!");
                return;
            }
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
        }
    }

    public class Kid : Person
    {
        private int age;
        private string group;  
        private string parentLastName;
        private string parentGSM;

        public Kid(string firstName, string lastName, string id, int age, string parentLastName, string parentGSM) : base(firstName, lastName, id)
        {
            this.age = age;
            this.parentLastName = parentLastName;
            this.parentGSM = parentGSM;

            switch (age){
                case 3: 
                    group = "I";
                    break;
                case 4:
                    group = "II";
                    break;
                case 5:
                    group = "III";
                    break;
                case 6:
                    group = "IV";
                    break;
                default:
                    Console.WriteLine($"The child {firstName} {lastName} age is invalid - {age}");
                    break;
            }
        }
    }
}

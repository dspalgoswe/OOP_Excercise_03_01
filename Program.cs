using System;

namespace OOP_Excercise_03_01
{
    // Gränssnitt för hantering av Person-objekt
    public interface IPersonHandler
    {
        Person CreatePerson(int age, string fname, string lname, double height, double weight);
        void SetAge(Person pers, int age);
        // Ytterligare metoder för att hantera person-objekt kan läggas till här
    }

    public class Person
    {
        // Privata fält
        private int age;
        private string fName;
        private string lName;
        private double height;
        private double weight;

        // Publik property för Age
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Åldern skall vara större än 0.");
                age = value;
            }
        }

        // Publik property, FName
        public string FName
        {
            get { return fName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value.Length > 10)
                    throw new ArgumentException("Förnamnet skall vara mellan 2 och 10 tecken.");
                fName = value;
            }
        }

        // Publik property, LName
        public string LName
        {
            get { return lName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 15)
                    throw new ArgumentException("Efternamnet skall vara mellan 3 och 15 tecken.");
                lName = value;
            }
        }

        // Publika properties, height och weight
        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Längden måste vara över 0!");
                height = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Vikten måste vara större än 0!");
                weight = value;
            }
        }
    }

    public class PersonHandler : IPersonHandler
    {
        public Person CreatePerson(int age, string fname, string lname, double height, double weight)
        {
            Person person = new Person()
            {
                Age = age,
                FName = fname,
                LName = lname,
                Height = height,
                Weight = weight
            };
            return person;
        }

        public void SetAge(Person pers, int age)
        {
            pers.Age = age; // Sätter åldern via Age property
        }

        // Kan infoga fler metoder m a p person-objekt här
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PersonHandler handler = new PersonHandler();

                // Skapa person enl. nedan
                Person person1 = handler.CreatePerson(25, "Anders", "Andersson", 180.0, 75.0);
                Console.WriteLine($"Skapad person: {person1.FName} {person1.LName}, Ålder: {person1.Age}");

                // Testa ogiltiga värden för exceptions
                //handler.SetAge(person1, -5); // Throwing exception
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Fel: {ex.Message}");
            }
        }
    }
}


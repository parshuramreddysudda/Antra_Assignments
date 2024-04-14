using System.Collections;

namespace Delegates
{
    class Program
    {
       
     
        public class Person
        {
            public string Name { get; private set; }
            public int Age { get; private set; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }   static void ChangePerson(Person person)
        {
            person = new Person("Wendy", 42);
        }

        static void Main(string[] args)
        {string name = null;
            Console.WriteLine(name?.Length);
   
            Person person = new Person("Jack", 28);
            ChangePerson(person);

            Console.WriteLine(person.Age);

     
            var countryList = new List<string>()
            {
                "Germany", "Thailand", "France", "Spain",
                "Italy", "United States", "Romania", "Russia",
                "Greece", "Argentina", "Canada", "Mexico",
                "Ireland", "Albania", "Slovenia", "Kazakhstan"
            };
            Console.WriteLine($"{countryList.All((country)=>country.Length>=9)}");
            var employees = new List<Employee>()
            {
                new Employee() { FullName = "John Doe", Age = 32, Salary = 170000m },
                new Employee() { FullName = "Chris Patrick", Age = 24, Salary = 156000m },
                new Employee() { FullName = "Amanda Watson", Age = 25, Salary = 165000m },
                new Employee() { FullName = "Adam Smith", Age = 24, Salary = 120000m },
                new Employee() { FullName = "Kirk Marks", Age = 29, Salary = 210000m },
                new Employee() { FullName = "Bree Lang", Age = 25, Salary = 320000m }
            };

            var employlist = from employee in employees
                let count = 100
                select new Employee()
                {
                    Salary = count * 100
                };
            
            var firstNames = new List<string>()
            {
                "John", "Patrick", "Lynda", "Albert", "Lionel", "Amanda"
            };

            var lastNames = new List<string>()
            {
                "Davids", "Brooke", "Chappell", "Links", "Johnson"
            };
            var filteredEmployees = employlist.OrderBy((emp) => emp.FullName)
                .Select((emp) => emp.Salary);
            
            foreach (var str in filteredEmployees)
            {
                Console.WriteLine($"Employee Name is {str}");
            }
            var TestObj = new { Name = "This is Test", Age = 34, anotherObject = new { childName = "Child" } };

            Console.WriteLine($"{TestObj.GetType()}");

            var list = new ArrayList();
            list.Add(34);
            list.Add(35);
            list.Add(39);
            
            
            Console.WriteLine($" Size of list is {list.Capacity}");
            
            list.TrimToSize();
            Console.WriteLine($" Size of list is {list.Capacity}");

          
            foreach (var li in list)
            {
                // Console.WriteLine($"Item is {li}");
            }
            Console.WriteLine($"{list.ToArray()}");
            Func<int, int,int> math = (a, b) => a + b;

            Console.WriteLine($"{math.Invoke(34, 67)}");

            
            Predicate<int> isEven = (i => i % 2 == 0);
            Console.WriteLine($"{isEven(23857982)}");
        }
    }
    
        public class Employee
        {
            public string FullName { get; set; }
            public int Age { get; set; }
            public decimal Salary { get; set; }
        }
}
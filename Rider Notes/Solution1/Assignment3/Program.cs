/*
. What are the six combinations of access modifier keywords and what do they do? 
Public - Classes and members are accessible from anywhere
Private - Classes and Memebers are accessible from the same class only
Protected - Classes and Members are accessible from the defined class or Derived classes only
Internal -  Classes and Members are accessible only in the defined assembly
Protected Internal -  members are accessible from all classes in the current assembly and derived classes in other assemblies.
Private Protected - members can’t be accessed from derived classes that reside in other assemblie
2. What is the difference between the static, const, and readonly keywords when applied to a type member?
-  static: Shared among all instances, can be changed but belongs to the type.
   const: Compile-time constant, cannot be changed after initialization.
   readonly: Can be changed only in the constructor or at initialization, and then becomes constant.
3. What does a constructor do?
- It used to initialize the object or instance an object. it is also helps in initializing the values or modify the values depending upon its usage. 
4. Why is the partial keyword useful?
- 
5. What is a tuple?
   A tuple can hold multiple elements of different types.

6. What does the C# record keyword do?
   It simplifies the process of creating classes that are primarily used to store data by automatically generating useful 
   methods such as equality comparison, hash code calculation, and string representation.
   
7. What does overloading and overriding mean?
   Overloading refers to defining multiple methods in the same class with the same name but different parameter lists.
   Overriding means providing a new implementation for a method in a derived class that already exists in a base class.
8. What is the difference between a field and a property?   
   A field is a variable within a class that holds data.
   A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field.
9. How do you make a method parameter optional?
   In C#, you can make a method parameter optional by providing a default value for it in the method signature.
10.What is an interface and how is it different from an abstract class?
   An interface is a contract that defines a set of methods and properties that a class must implement. 
   An interface only contains method and property declarations without any implementation.
11. What accessibility level are members of an interface?
- By default, members of an interface are public
12. True/False. Polymorphism allows derived classes to provide different implementations
of the same method.
True
13. True/False. The override keyword is used to indicate that a method in a derived class is
providing its own implementation of a method.
True
14. True/False. The new keyword is used to indicate that a method in a derived class is
providing its own implementation of a method.
True
15. True/False. Abstract methods can be used in a normal (non-abstract) class. 
False
16.True/False. Normal (non-abstract) methods can be used in an abstract class. 
True
17. True/False. Derived classes can override methods that were virtual in the base class. 
True
18. True/False. Derived classes can override methods that were abstract in the base class. 
True
19. True/False. In a derived class, you can override a method that was neither virtual non abstract in the
base class.
False
20. True/False. A class that implements an interface does not have to provide an
implementation for all of the members of the interface.
False
21. True/False. A class that implements an interface is allowed to have other members that
aren’t defined in the interface.
True
22. True/False. A class can have more than one base class.
False
23. True/False. A class can implement more than one interface.
True
*/

//Working with Methods

class Program
{

   static void Array()
   {
      int[] numbers = GenerateNumbers(10);
      PrintNumbers(numbers);
      Reverse(ref numbers);
      PrintNumbers(numbers);
   }

   static int[] GenerateNumbers(int length)
   {
      int[] numbers = new int[length];
      Random ran = new Random();
      for (int i = 0; i < length; i++)
      {
         numbers[i] = ran.Next(1, 21);
      }

      return numbers;
   }

   static void Reverse(ref int[] num)
   {
      System.Array.Reverse(num);
   }

   static void PrintNumbers(int[] ints)
   {
      foreach (int num in ints)
      {
         Console.Write(num + " ");
      }
      Console.WriteLine();
   }
}


class SecondAssignment
{

   public static void Main(string[] args)
   {
      ActionExample();
   }
   public static void ActionExample()
   {
      Action<int> fib = new Action<int>(Fibonacci);
      fib(560);

   }
   public static void Fibonacci(int num)
   {
      int[] fib = new int[num+1];
      fib[1] = 1;
      fib[2] = 1;
      for (int i = 2; i <= num; i++)
      {
         fib[i] = fib[i - 1] + fib[i - 2];
      }
      Console.WriteLine(fib.ToString());
      Console.WriteLine(fib[1..(num + 1)]);

      // return fib[num];
   }
}

/*Write a program that that demonstrates use of four basic principles of
object-oriented programming /Abstraction/, /Encapsulation/, /Inheritance/ and
                                                                        /Polymorphism/.      

2. Use /Abstraction/ to define different classes for each person type such as Student
and Instructor. These classes should have behavior for that type of person.
3. Use /Encapsulation/ to keep many details private in each class.
4. Use /Inheritance/ by leveraging the implementation already created in the Person
class to save code in Student and Instructor classes.
5. Use /Polymorphism/ to create virtual methods that derived classes could override to
   create specific behavior such as salary calculations.
6. Make sure to create appropriate /interfaces/ such as ICourseService, IStudentService,
IInstructorService, IDepartmentService, IPersonService, IPersonService (should have
person specific methods). IStudentService, IInstructorService should inherit from
IPersonService.
   Person
   Calculate Age of the Person
Calculate the Salary of the person, Use decimal for salary
   Salary cannot be negative number
Can have multiple Addresses, should have method to get addresses
   Instructor
   */
//Abstract Classes

abstract class Person
{
   public abstract void Behavior();
   public virtual void CurrentInstitution()
   {
      Console.WriteLine("Antra Inc");
   }
}



//Inheritance
class Student:Person
{
   //Encapsulation
   public String Name { get; set; }
   private int Marks { get; set; }
   
   public override void Behavior()
   {
      Console.WriteLine(" I am Student");
   }

   public override void CurrentInstitution()
   {
      Console.WriteLine(" Google ");
   }
}

class Instructor:Person
{
   //Encapsulation
   public String Name { get; set; }
   private int Salary { get; set; }
   public override void Behavior()
   {
      Console.WriteLine(" I can Instructor");
   }
   public override void CurrentInstitution()
   {
      Console.WriteLine(" Microsoft ");
   }
}

interface ICourseService
{
   void isCourseAvailable();
   void RegisterationDetails();

}

interface IFacultyService
{
   double Salary();
   void Attendence();
}

interface IStudentService
{
   void Fees();

   void Attendence();
}

class InstructorService(): IFacultyService
{
   private int years { get; set; }
   private int salary { get; set; }
   private int bonus { get; set; }
   public double Salary()
   {
      double totalSalary = years * salary * bonus * 10;
      if (totalSalary!=0)
      {
         return totalSalary;
      }

      new Exception("Error with Salary Calculation");
      return 0;
   }

   public void Attendence()
   {
      throw new NotImplementedException();
   }
}

class StudentService() : IStudentService
{
   public void Fees()
   {
      throw new NotImplementedException();
   }

   public void Attendence()
   {
      throw new NotImplementedException();
   }
}
   
   

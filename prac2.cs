using System;

// Interface
interface IPayable
{
    double CalculateSalary();
}

// Abstract Base Class
abstract class Employee : IPayable
{
    protected int Id;
    protected string Name;
    protected double BasicSalary;

    public Employee(int id, string name, double salary)
    {
        Id = id;
        Name = name;
        BasicSalary = salary;
    }

    public abstract double CalculateSalary();

    public virtual void Display()
    {
        Console.WriteLine("\n--------------------------------");
        Console.WriteLine("Employee ID   : " + Id);
        Console.WriteLine("Employee Name : " + Name);
        Console.WriteLine("Basic Salary  : " + BasicSalary);
    }
}

// Manager Class
class Manager : Employee
{
    public Manager(int id, string name, double salary)
        : base(id, name, salary) { }

    public override double CalculateSalary()
    {
        return BasicSalary + (BasicSalary * 0.30);
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Designation   : Manager");
        Console.WriteLine("Net Salary    : " + CalculateSalary());
    }
}

// Developer Class
class Developer : Employee
{
    public Developer(int id, string name, double salary)
        : base(id, name, salary) { }

    public override double CalculateSalary()
    {
        return BasicSalary + (BasicSalary * 0.20);
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Designation   : Developer");
        Console.WriteLine("Net Salary    : " + CalculateSalary());
    }
}

// Intern Class
class Intern : Employee
{
    public Intern(int id, string name, double salary)
        : base(id, name, salary) { }

    public override double CalculateSalary()
    {
        return BasicSalary + 2000;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Designation   : Intern");
        Console.WriteLine("Net Salary    : " + CalculateSalary());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== EMPLOYEE PAYROLL SYSTEM =====");
        Console.WriteLine("1. Manager");
        Console.WriteLine("2. Developer");
        Console.WriteLine("3. Intern");

        Console.Write("Enter Employee Type (1-3): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Basic Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Employee emp;

        switch (choice)
        {
            case 1:
                emp = new Manager(id, name, salary);
                break;

            case 2:
                emp = new Developer(id, name, salary);
                break;

            case 3:
                emp = new Intern(id, name, salary);
                break;

            default:
                Console.WriteLine("Invalid Employee Type!");
                return;
        }

        Console.WriteLine("\n===== PAYROLL DETAILS =====");
        emp.Display();

        Console.WriteLine("\nPress Enter to Exit...");
        Console.ReadLine();
    }
}
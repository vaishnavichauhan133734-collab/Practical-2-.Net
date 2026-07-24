using System;

namespace AdmissionManagementSystem
{
    // Class: Blueprint for creating student profiles
    public class Student
    {
        // Access Modifiers: 'private' fields ensure Encapsulation (data protection)
        private string name;
        private string branch;
        private double percentage;
        private double baseFee;
        private bool needsTransport;
        private string zone;

        // Constructor: Automatically called when using 'new Student(...)'
        public Student(string name, string branch, double percentage, double baseFee, bool needsTransport, string zone)
        {
            this.name = name;
            this.branch = branch;
            this.percentage = percentage;
            this.baseFee = baseFee;
            this.needsTransport = needsTransport;
            this.zone = zone.ToUpper();
        }

        // Method: Calculates scholarship fee based on criteria
        public double CalculateAcademicFee()
        {
            if (percentage >= 95)
            {
                return 0.0; // 95% + Above pays $0 fee
            }
            else if (percentage >= 80 && percentage < 95)
            {
                return baseFee * 0.20; // 80% to 94.9% pays 20% of fee
            }
            else
            {
                return baseFee; // Below 80% pays full fee
            }
        }

        // Method: Calculates transport fee based on selected zone
        public double CalculateTransportFee()
        {
            if (!needsTransport) return 0.0;

            switch (zone)
            {
                case "A": return 1000.0;
                case "B": return 2000.0;
                case "C": return 3000.0;
                default:  return 1500.0;
            }
        }

        // Method: Prints the generated invoice
        public void DisplayAdmissionDetails()
        {
            double academicFee = CalculateAcademicFee();
            double transportFee = CalculateTransportFee();
            double totalFee = academicFee + transportFee;

            Console.WriteLine("\n=============================================");
            Console.WriteLine($"           ADMISSION RECEIPT - {name.ToUpper()}");
            Console.WriteLine("=============================================");
            Console.WriteLine($"Selected Branch     : {branch}");
            Console.WriteLine($"Academic Percentage : {percentage}%");
            Console.WriteLine($"Branch Base Fee     : ${baseFee:N2}");
            Console.WriteLine($"Scholarship Applied : {(percentage >= 95 ? "100% Free ($0 Fee)" : percentage >= 80 ? "80% Discount (Pays 20%)" : "No Discount (Full Fee)")}");
            Console.WriteLine($"Final Academic Fee  : ${academicFee:N2}");
            Console.WriteLine($"Transport Required  : {(needsTransport ? $"Yes (Zone {zone})" : "No")}");
            Console.WriteLine($"Transport Fee       : ${transportFee:N2}");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"TOTAL FEE PAYABLE   : ${totalFee:N2}");
            Console.WriteLine("=============================================\n");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== SYSTEM INITIALIZED ===");
            
            // 1. Get Student Name
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            // 2. Select Branch
            Console.WriteLine("\nSelect Branch:");
            Console.WriteLine("1. Computer Science Engineering (CSE) - $15,000");
            Console.WriteLine("2. Artificial Intelligence & Data Science (AI/DS) - $16,500");
            Console.WriteLine("3. Mechanical Engineering (ME) - $11,000");
            Console.WriteLine("4. Electrical Engineering (EE) - $12,000");
            Console.Write("Enter Branch Number (1-4): ");
            string choice = Console.ReadLine();

            string branch = "Computer Science Engineering";
            double baseFee = 15000.0;

            if (choice == "2") { branch = "AI & Data Science"; baseFee = 16500.0; }
            else if (choice == "3") { branch = "Mechanical Engineering"; baseFee = 11000.0; }
            else if (choice == "4") { branch = "Electrical Engineering"; baseFee = 12000.0; }

            // 3. Get Percentage
            Console.Write("\nEnter Academic Percentage (0-100): ");
            double.TryParse(Console.ReadLine(), out double percentage);

            // 4. Transport Choice
            Console.Write("Does the student require transport? (yes/no): ");
            string transportInput = Console.ReadLine().Trim().ToLower();
            bool needsTransport = (transportInput == "yes" || transportInput == "y");

            // 5. Transport Zone
            string zone = "NONE";
            if (needsTransport)
            {
                Console.Write("Enter Transport Zone (A, B, or C): ");
                zone = Console.ReadLine().Trim().ToUpper();
            }

            // Object Creation: Creating an instance of Student using the inputs
            Student student = new Student(name, branch, percentage, baseFee, needsTransport, zone);

            // Display invoice output
            student.DisplayAdmissionDetails();
        }
    }
}
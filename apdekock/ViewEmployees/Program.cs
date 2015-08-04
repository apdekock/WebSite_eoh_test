using System;
using ViewEmployees.EmployeeService;

namespace ViewEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Async get employees");
                EmployeeServiceClient sc = new EmployeeServiceClient();
                sc.GetEmployeesCompleted += Completed;
                sc.GetEmployeesAsync();
                Console.WriteLine("Done");
                Console.ReadLine();
            }
        }

        private static void Completed(object sender, GetEmployeesCompletedEventArgs e)
        {
            Console.WriteLine("Async call completed");
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
            }
            else
            {
                foreach (var employee in e.Result)
                {
                    Console.WriteLine(employee);
                }
            }
            Console.WriteLine("Press any key to retrieve again.");
        }
    }
}

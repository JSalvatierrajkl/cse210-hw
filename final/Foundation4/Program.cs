using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>();

        while (true)
        {
            Console.WriteLine("1. Add Running activity");
            Console.WriteLine("2. Add Cycling activity");
            Console.WriteLine("3. Add Swimming activity");
            Console.WriteLine("4. View Summary");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter the duration of your Running activity in minutes: ");
                int duration = int.Parse(Console.ReadLine());
                Console.Write("Enter the distance of your Running activity in miles: ");
                double distance = double.Parse(Console.ReadLine());
                activities.Add(new Running(duration, distance));
                Console.WriteLine("Running activity added successfully.");
            }
            else if (choice == 2)
            {
                Console.Write("Enter the duration of your Cycling activity in minutes: ");
                int duration = int.Parse(Console.ReadLine());
                Console.Write("Enter the speed of your Cycling activity in mph: ");
                double speed = double.Parse(Console.ReadLine());
                activities.Add(new StationaryBicycles(duration, speed));
                Console.WriteLine("Cycling activity added successfully.");
            }
            else if (choice == 3)
            {
                Console.Write("Enter the duration of your Swimming activity in minutes: ");
                int duration = int.Parse(Console.ReadLine());
                Console.Write("Enter the number of laps in your Swimming activity: ");
                int laps = int.Parse(Console.ReadLine());
                activities.Add(new Swimming(duration, laps));
                Console.WriteLine("Swimming activity added successfully.");
            }
            else if (choice == 4)
            {
                Console.WriteLine("Exercise Activities Summary:");
                foreach (Activity activity in activities)
                {
                    Console.WriteLine(activity.GetSummary());
                }
            }
            else if (choice == 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine();
        }
    }

    private static string GetExerciseTypeInput()
    {
        Console.WriteLine("Exercise Types:");
        Console.WriteLine("R - Running");
        Console.WriteLine("C - Cycling");
        Console.WriteLine("S - Swimming");
        Console.WriteLine("Q - Quit");
        Console.Write("Enter the exercise type (R/C/S/Q): ");
        string exerciseType = Console.ReadLine().Trim();
        return exerciseType;
    }

    private static DateTime GetDateInput(string prompt)
    {
        Console.Write(prompt);
        DateTime date;
        while (!DateTime.TryParse(Console.ReadLine(), out date))
        {
            Console.WriteLine("Invalid date. Please try again.");
            Console.Write(prompt);
        }
        return date;
    }

    private static int GetIntInput(string prompt)
    {
        Console.Write(prompt);
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Invalid input. Please enter an integer value.");
            Console.Write(prompt);
        }
        return value;
    }

    private static double GetDoubleInput(string prompt)
    {
        Console.Write(prompt);
        double value;
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
            Console.Write(prompt);
        }
        return value;
    }
}
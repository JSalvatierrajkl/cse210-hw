using System;
public class Program
{
    private static List<Event> events = new List<Event>();
    public static void Main(string[] args)
    {
        Console.WriteLine("Event Planning Program");
        Console.WriteLine();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Event");
            Console.WriteLine("2. View Events");
            Console.WriteLine("3. Exit");
            Console.WriteLine();

            int choice = GetMenuChoice(1, 3);

            if (choice == 1)
            {
                CreateNewEvent();
            }
            else if (choice == 2)
            {
                ViewEvents();
            }
            else if (choice == 3)
            {
                running = false;
            }

            Console.WriteLine();
        }
    }

    private static void CreateNewEvent()
    {
        Console.WriteLine("Create New Event");

        Console.WriteLine("Select Event Type:");
        Console.WriteLine("1. Lecture");
        Console.WriteLine("2. Reception");
        Console.WriteLine("3. Outdoor Gathering");
        Console.WriteLine();

        int eventTypeChoice = GetMenuChoice(1, 3);
        Event newEvent = null;

        string title = GetInput("Title: ");
        string description = GetInput("Description: ");
        DateTime date = GetDateTimeInput("Date (MM/dd/yyyy): ");
        TimeSpan time = GetTimeInput("Time (HH:mm): ");
        string street = GetInput("Street: ");
        string city = GetInput("City: ");
        string state = GetInput("State: ");
        string country = GetInput("Country: ");
        Address address = new Address(street, city, state, country);

        if (eventTypeChoice == 1)
        {
            string speaker = GetInput("Speaker: ");
            int capacity = GetIntInput("Capacity: ");
            newEvent = new Lecture(title, description, date, time, address, speaker, capacity);
        }
        else if (eventTypeChoice == 2)
        {
            string rsvpEmail = GetInput("RSVP Email: ");
            newEvent = new Reception(title, description, date, time, address, rsvpEmail);
        }
        else if (eventTypeChoice == 3)
        {
            string weatherForecast = GetInput("Weather Forecast: ");
            newEvent = new OutdoorGathering(title, description, date, time, address, weatherForecast);
        }

        events.Add(newEvent);
        Console.WriteLine("Event created successfully!");
    }

    private static void ViewEvents()
    {
        if (events.Count == 0)
        {
            Console.WriteLine("No events found.");
            return;
        }

        Console.WriteLine("View Events");
        Console.WriteLine();

        foreach (Event ev in events)
        {
            Console.WriteLine("Event Details:");
            Console.WriteLine(ev.GenerateFullMessage());
            Console.WriteLine();
        }
    }

    private static int GetMenuChoice(int min, int max)
    {
        int choice = GetIntInput("Enter your choice: ");
        while (choice < min || choice > max)
        {
            Console.WriteLine("Invalid choice. Please try again.");
            choice = GetIntInput("Enter your choice: ");
        }
        return choice;
    }

    private static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    private static DateTime GetDateTimeInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }
    }

    private static TimeSpan GetTimeInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid time format. Please try again.");
            }
        }
    }

    private static int GetIntInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }
    }
}
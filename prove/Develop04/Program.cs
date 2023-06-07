using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();
        string menuOption = "";
        while (menuOption != "4")
        {
            breathingActivity.DisplayPrincipalMenu();
            menuOption = Console.ReadLine();
            if (menuOption == "1")
            {
                breathingActivity.DisplayStartingMessage();
                Console.Clear();
                breathingActivity.Run();
            }
            else if (menuOption == "2")
            {
                reflectingActivity.DisplayStartingMessage();
                Console.Clear();
                reflectingActivity.Run();
            }
            else if (menuOption == "3")
            {
                listingActivity.DisplayStartingMessage();
                Console.Clear();
                listingActivity.Run();
            }
            else if (menuOption == "4")
            {
                Environment.Exit(0);
            }
            Console.Clear();
        }
    }
}
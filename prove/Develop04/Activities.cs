public class Activities
{
    private string _activityName;
    private string _description;
    private int _durationInSeconds;

    public void DisplayPrincipalMenu ()
    {
        Console.Write("Select a choice from the menu");
        Console.WriteLine("Menu Options: ");
        Console.WriteLine(" 1. Start breathing activity");
        Console.WriteLine(" 2. Start reflecting activity");
        Console.WriteLine(" 3. Start listing activity");
        Console.WriteLine(" 4. Quit");
    }

    public Activities()
    {
        _activityName = "";
        _description = "";
    }

    public void SetActivityName (string activityName)
    {
        _activityName = activityName;
    }
    public void SetDescription (string description)
    {
        _description = description;
    }
    public int GetDurationInSeconds()
    {
        return _durationInSeconds;
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity.");
        Console.WriteLine();
        Console.WriteLine($"{_description}");
        Console.WriteLine();
        Console.WriteLine("How long, in seconds, would you like for your session?");
        _durationInSeconds = int.Parse(Console.ReadLine());
    }

    public void SpinnerShow(int duration)
    {
        List<string> gifStrings = new List<string>();
        gifStrings.Add("|");
        gifStrings.Add("/");
        gifStrings.Add("-");
        gifStrings.Add("\\");
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            string spinner =gifStrings[i];
            Console.Write(spinner);
            Thread.Sleep(400);
            Console.Write("\b \b");
            i++;
            if (i >= gifStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed another {_durationInSeconds} seconds of the {_activityName} Activity.");
        SpinnerShow(4);
    }
}
public class ListingActivity: Activities
{
    private List<string> _promptList = new List<string>();

    public ListingActivity()
    {
        SetActivityName("Listing");
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        _promptList.Add("Who are people who you appreciate?");
        _promptList.Add("What are personal strengths of yours?");
        _promptList.Add("Who are the people that you helped this week?");
        _promptList.Add("When have you felt the Holy Ghost this month?");
        _promptList.Add("Who are some of your personal heroes?");
    }
    public void Run()
    {
        Random random = new Random();
        int randomIndex = random.Next(0,4);
        string randomPrompt = _promptList[randomIndex];
        int itemsAmount = 0;
        int durationInSeconds = GetDurationInSeconds();
        Console.WriteLine("Get ready...");
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt: ");
        Console.WriteLine();
        Console.WriteLine($" --- {randomPrompt} --- ");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(durationInSeconds);
        Console.WriteLine("");
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("> ");
            Console.ReadLine();
            itemsAmount ++;
        }
        Console.WriteLine($"You listed {itemsAmount} items!");
        Console.WriteLine();
        DisplayEndingMessage();
        SpinnerShow(4);
    }
    
}
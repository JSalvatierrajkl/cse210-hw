class Program
{
    private List<Goal> goals;
    private int userScore;
    private string filename = "goals.txt";

    private static int totalEarnedPoints = 0;

    public Program()
    {
        goals = new List<Goal>();
        userScore = 0;
    }

    public void Run()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest - Main Menu");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record an event");
            Console.WriteLine("6. Exit");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ViewGoals();
                ViewScore();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                exit = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }


    private void ViewGoals()
    {
        Console.WriteLine("=== Goals ===");

        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetGoalStatus()} {goal.GetGoalDetails()}");
        }
    }

    private void CreateGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
    
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple goal (complete once)");
        Console.WriteLine("2. Eternal goal (record multiple times)");
        Console.WriteLine("3. Checklist goal (record multiple times, with bonus)");
    
        Console.Write("Enter goal type: ");
        string goalTypeChoice = Console.ReadLine();
    
        if (goalTypeChoice == "1")
        {
            Console.Write("Enter points for completing the goal: ");
            int points = int.Parse(Console.ReadLine());
            Goal simpleGoal = new SimpleGoal(name, points);
            goals.Add(simpleGoal);
            Console.WriteLine("Simple goal created successfully.");
        }
        else if (goalTypeChoice == "2")
        {
            Console.Write("Enter points for each record: ");
            int pointsPerRecord = int.Parse(Console.ReadLine());
            Goal eternalGoal = new EternalGoal(name, pointsPerRecord);
            goals.Add(eternalGoal);
            Console.WriteLine("Eternal goal created successfully.");
        }
        else if (goalTypeChoice == "3")
        {
            Console.Write("Enter points for each record: ");
            int pointsPerRecordChecklist = int.Parse(Console.ReadLine());
            Console.Write("Enter required count: ");
            int requiredCount = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            Goal checklistGoal = new ChecklistGoal(name, pointsPerRecordChecklist, requiredCount, bonusPoints);
            goals.Add(checklistGoal);
            Console.WriteLine("Checklist goal created successfully.");
        }
        else
        {
            Console.WriteLine("Invalid goal type. Please try again.");
        }
    }


    private void RecordEvent()
    {
        ViewGoals();
        Console.Write("Wich goal did you acomplish? ");
        int goalNumber;
        if (!int.TryParse(Console.ReadLine(), out goalNumber) || goalNumber < 1 || goalNumber > goals.Count)
        {
            Console.WriteLine("Invalid goal number. Please try again.");
            return;
        }

        Goal goal = goals[goalNumber - 1];

        if (goal is ChecklistGoal checklistGoal)
        {
            checklistGoal.RecordEvent();
            int checklistPoints = checklistGoal.GetPoints();
            userScore += checklistGoal.GetPoints();
            Console.WriteLine($"Event recorded successfully. You earned {checklistPoints}");
        }
        else
        {
            goal._completed = true;
            int goalPoints = goal.GetPoints();
            userScore += goal.GetPoints();
            Console.WriteLine($"Goal completed successfully. You earned {goalPoints}");
        }
    }

    private void ViewScore()
    {
        Console.WriteLine($"Your current score is: {userScore}");
    }

    private void LoadGoals()
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
    
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
    
                if (parts.Length >= 4)
                {
                    string goalType = parts[0];
                    string goalName = parts[1];
                    bool completed = bool.Parse(parts[2]);
                    int currentCount = int.Parse(parts[3]);
    
                    if (goalType == "SimpleGoal")
                    {
                        if (parts.Length >= 5)
                        {
                            int points = int.Parse(parts[4]);
                            Goal simpleGoal = new SimpleGoal(goalName, points);
                            simpleGoal._completed = completed;
                            goals.Add(simpleGoal);
                        }
                    }
                    else if (goalType == "EternalGoal")
                    {
                        if (parts.Length >= 5)
                        {
                            int pointsPerRecord = int.Parse(parts[4]);
                            Goal eternalGoal = new EternalGoal(goalName, pointsPerRecord);
                            eternalGoal._completed = completed;
                            goals.Add(eternalGoal);
                        }
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        if (parts.Length >= 7)
                        {
                            int pointsPerRecordChecklist = int.Parse(parts[4]);
                            int requiredCount = int.Parse(parts[5]);
                            int bonusPoints = int.Parse(parts[6]);
                            Goal checklistGoal = new ChecklistGoal(goalName, pointsPerRecordChecklist, requiredCount, bonusPoints);
                            checklistGoal._completed = completed;
                            ((ChecklistGoal)checklistGoal)._currentCount = currentCount;
                            goals.Add(checklistGoal);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid goal type: {goalType}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid data format: {line}");
                }
            }
    
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }

    private void SaveGoals()
    {
        int totalEarnedPoints = CalculateTotalEarnedPoints();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Total Earned Points: {totalEarnedPoints}");

            foreach (Goal goal in goals)
            {
                string goalType = goal.GetType().Name;
                string goalDetails = goal.GetGoalDetails();
                bool completed = goal._completed;
                int currentCount = (goal is ChecklistGoal checklistGoal) ? checklistGoal._currentCount : 0;

                outputFile.WriteLine($"{goalType},{goalDetails},{completed},{currentCount}");
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    private int CalculateTotalEarnedPoints()
    {
        int totalEarnedPoints = 0;

        foreach (Goal goal in goals)
        {
            if (goal._completed)
            {
                totalEarnedPoints += goal.GetPoints();
            }
        }

        return totalEarnedPoints;
    }
}
abstract class Goal
{
    public string _name { get; set; }
    public bool _completed { get; set; }

    public Goal(string name)
    {
        _name = name;
        _completed = false;
    }

    public abstract int GetPoints();

    public virtual string GetGoalStatus()
    {
        return _completed ? "[X]" : "[ ]";
    }
    
    public virtual string GetGoalDetails()
    {
        return _name;
    }
    
    public override string ToString()
    {
        // Serialize the goal object into a string representation
        string type = GetType().Name;
        string details = GetGoalDetails();
        bool completed = _completed;

        return $"{type}:{details}:{completed}";
    }
}
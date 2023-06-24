class SimpleGoal : Goal
{
    public int _points { get; set; }

    public SimpleGoal(string name, int points) : base(name)
    {
        _points = points;
    }

    public override int GetPoints()
    {
        return _points;
    }
}
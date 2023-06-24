class EternalGoal : Goal
{
    public int _pointsPerRecord { get; set; }

    public EternalGoal(string name, int pointsPerRecord) : base(name)
    {
        _pointsPerRecord = pointsPerRecord;
    }

    public override int GetPoints()
    {
        return _pointsPerRecord;
    }
}
class ChecklistGoal : Goal
{
    public int _pointsPerRecord { get; set; }
    public int _requiredCount { get; set; }
    public int _bonusPoints { get; set; }
    public int _currentCount { get; set; }
    public ChecklistGoal(string name, int pointsPerRecord, int requiredCount, int bonusPoints) : base(name)
    {
        _pointsPerRecord = pointsPerRecord;
        _requiredCount = requiredCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int GetPoints()
    {
        if (_currentCount < _requiredCount)
            return _pointsPerRecord;
        else
            return _pointsPerRecord + _bonusPoints;
    }

    public override string GetGoalStatus()
    {
        string _completedString = _completed ? "[X]" : "[ ]";
        return $"{_completedString} {_currentCount}/{_requiredCount}";
    }

    public string GetGoalCheck()
    {
        return $"Currently completed {_currentCount}/{_requiredCount}";
    }

    public void RecordEvent()
    {
        _currentCount++;
    }
}

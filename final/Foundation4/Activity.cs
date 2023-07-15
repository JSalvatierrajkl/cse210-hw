public abstract class Activity
{
    public DateTime date;
    public int durationInMinutes;

    public Activity(int durationInMinutes)
    {
        this.date = DateTime.Today;
        this.durationInMinutes = durationInMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string activityType = GetType().Name;
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string summary = $"{date.ToString("dd MMM yyyy")} {activityType} ({durationInMinutes} min) - ";
        summary += $"Distance: {distance} miles, Speed: {speed} mph, Pace: {pace} min per mile";

        return summary;
    }
}
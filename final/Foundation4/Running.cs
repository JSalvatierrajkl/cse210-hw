public class Running : Activity
{
    private double distance;

    public Running(int durationInMinutes, double distance) : base(durationInMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (durationInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return durationInMinutes / distance;
    }
}
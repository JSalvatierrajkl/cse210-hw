public class Swimming : Activity
{
    private int laps;

    public Swimming(int durationInMinutes, int laps) : base(durationInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50.0 / 1000 * 0.62; // Convert laps to miles
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        return distance / (durationInMinutes / 60.0);
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return durationInMinutes / distance;
    }
}

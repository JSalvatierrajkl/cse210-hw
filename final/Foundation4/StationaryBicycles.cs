public class StationaryBicycles : Activity
{
    private double speed;

    public StationaryBicycles(int durationInMinutes, double speed) : base(durationInMinutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return speed * (durationInMinutes / 60.0);
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60.0 / speed;
    }
}
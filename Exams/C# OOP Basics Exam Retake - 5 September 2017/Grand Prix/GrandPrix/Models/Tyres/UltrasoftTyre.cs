public class UltrasoftTyre : Tyre
{
    private const double UltrasoftTyreDegradationLowerBound = 30;

    private double grip;

    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        this.Grip = grip;
    }

    public double Grip
    {
        get => this.grip;
        private set => this.grip = value;
    }

    public override double DegradationLowerBound => UltrasoftTyreDegradationLowerBound;

    public override void Degradate()
    {
        base.Degradate();
        base.Degradation -= this.Grip;
    }
}
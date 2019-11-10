public class Point
{
    private double x;
    private double y;

    public Point(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public double X
    {
        get => x;
        set => x = value;
    }

    public double Y
    {
        get => y;
        set => y = value;
    }
}
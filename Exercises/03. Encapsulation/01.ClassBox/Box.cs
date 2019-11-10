public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public double LateralSurfaceArea => 2 * (this.length * this.height + this.width * this.height);
    public double SurfaceArea => this.LateralSurfaceArea + 2 * this.length * this.width;
    public double Volume => this.length * this.width * this.height;
}
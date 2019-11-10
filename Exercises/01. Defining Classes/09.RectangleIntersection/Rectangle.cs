using System;

public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double[] topLeftCoordinates;

    public Rectangle(string id, double width, double height, double xCoordinate, double yCoordinate)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.topLeftCoordinates = new double[2];
        this.topLeftCoordinates[0] = xCoordinate;
        this.topLeftCoordinates[1] = yCoordinate;
    }

    public string Id
    {
        get => id;
        set => id = value;
    }

    public double Width
    {
        get => width;
        set => width = value;
    }

    public double Height
    {
        get => height;
        set => height = value;
    }

    public double TopLeftXCoordinate => this.topLeftCoordinates[0];
    public double TopLeftYCoordinate => this.topLeftCoordinates[1];

    public bool Intersects(Rectangle other)
    {
        double xOffset = Math.Abs(this.TopLeftXCoordinate - other.TopLeftXCoordinate);
        double yOffset = Math.Abs(this.TopLeftYCoordinate - other.TopLeftYCoordinate);

        Rectangle left = this.TopLeftXCoordinate <= other.TopLeftXCoordinate ? this : other;
        Rectangle upper = this.TopLeftYCoordinate <= other.TopLeftYCoordinate ? this : other;

        return
            left.Width >= xOffset &&
            upper.Height >= yOffset;
    }
}
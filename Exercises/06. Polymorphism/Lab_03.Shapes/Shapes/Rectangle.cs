using System;

public class Rectangle : Shape
{
    private const string RectangleInvalidSideLength = "Side must be non-zero and positive!";

    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Height
    {
        get => this.height;

        set
        {
            this.ValidateSide(value, nameof(this.Height));

            this.height = value;
        }
    }

    public double Width
    {
        get => this.width;

        set
        {
            this.ValidateSide(value, nameof(this.Width));

            this.width = value;
        }
    }

    private double ValidateSide(double value, string paramName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(paramName, RectangleInvalidSideLength);
        }

        return value;
    }

    public override double CalculateArea()
    {
        double area = this.Height * this.Width;

        return area;
    }

    public override double CalculatePerimeter()
    {
        double perimeter = 2 * (this.Height + this.Width);

        return perimeter;
    }
}
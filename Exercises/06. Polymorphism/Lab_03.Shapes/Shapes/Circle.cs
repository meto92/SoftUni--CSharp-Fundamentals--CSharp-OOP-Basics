using System;

public class Circle : Shape
{
    private const string CircleInvalidRadiusMessage = "Radius must be non-zero and positive!";

    private double radius;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius
    {
        get => this.radius;

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Radius), CircleInvalidRadiusMessage);
            }

            this.radius = value;
        }
    }

    public override double CalculateArea()
    {
        double area = Math.PI * this.Radius * this.Radius;

        return area;
    }

    public override double CalculatePerimeter()
    {
        double perimeter = 2 * Math.PI * this.Radius;

        return perimeter;
    }
}
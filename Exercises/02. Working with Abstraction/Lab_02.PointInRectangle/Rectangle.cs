public class Rectangle
{
    private Point topLeft;
    private Point bottomRight;

    public Rectangle(Point topLeft, Point bottomRight)
    {
        this.TopLeft = topLeft;
        this.BottomRight = bottomRight;
    }

    public Point TopLeft
    {
        get => topLeft;
        set => topLeft = value;
    }

    public Point BottomRight
    {
        get => bottomRight;
        set => bottomRight = value;
    }    

    public double Width => bottomRight.X - topLeft.X;
    public double Height => bottomRight.Y - topLeft.Y;

    public bool Contains(Point point)
    {
        return
            this.TopLeft.X <= point.X &&
            this.BottomRight.X >= point.X &&
            this.TopLeft.Y <= point.Y &&
            this.BottomRight.Y >= point.Y;
    }
}
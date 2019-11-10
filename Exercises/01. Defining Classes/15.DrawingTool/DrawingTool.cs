public class DrawingTool
{
    private Shape shape;

    public DrawingTool(Shape shape)
    {
        this.Shape = shape;
    }

    public Shape Shape
    {
        get => shape;
        set => shape = value;
    }

    public void Draw()
    {
        this.Shape.Draw();
    }
}
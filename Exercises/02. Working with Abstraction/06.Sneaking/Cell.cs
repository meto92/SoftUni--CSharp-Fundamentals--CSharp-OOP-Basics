public class Cell
{
    private int row;
    private int col;

    public Cell()
        : this(0, 0)
    { }

    public Cell(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }

    public int Row
    {
        get => row;
        set => row = value;
    }

    public int Col
    {
        get => col;
        set => col = value;
    }

    public override string ToString()
    {
        return $"{this.Row}, {this.Col}";
    }
}
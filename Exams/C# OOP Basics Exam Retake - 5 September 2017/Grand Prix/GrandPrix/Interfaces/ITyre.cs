public interface ITyre : INameable
{
    double Hardness { get; }

    double Degradation { get; }

    void Degradate();
}
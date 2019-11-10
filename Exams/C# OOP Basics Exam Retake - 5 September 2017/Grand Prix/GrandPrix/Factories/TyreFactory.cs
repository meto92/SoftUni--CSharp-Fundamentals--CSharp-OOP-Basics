using System;

public class TyreFactory
{
    public Tyre CreateTyre(string[] tyreArgs)
    {
        string type = tyreArgs[0] + nameof(Tyre);
        double hardness = double.Parse(tyreArgs[1]);

        Tyre tyre = null;

        switch (type)
        {
            case nameof(HardTyre):
                tyre = new HardTyre(hardness);
                break;
            case nameof(UltrasoftTyre):
                double grip = double.Parse(tyreArgs[2]);

                tyre = new UltrasoftTyre(hardness, grip);
                break;
            default:
                throw new NotSupportedException();
        }

        return tyre;
    }
}
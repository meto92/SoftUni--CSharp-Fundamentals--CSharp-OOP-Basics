using System;

public class Car : ICar
{
    private const int FuelTankCapacity = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get => this.hp;
        private set => this.hp = value;
    }

    public double FuelAmount
    {
        get => this.fuelAmount;

        private set
        {
            this.fuelAmount = Math.Min(value, FuelTankCapacity);

            if (this.fuelAmount < 0)
            {
                throw new OutOfFuelException();
            }
        }
    }

    public Tyre Tyre
    {
        get => this.tyre;
        private set => this.tyre = value;
    }

    public void ChangeTyres(Tyre newTyres)
    {
        this.Tyre = newTyres;
    }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ReduceFuel(double fuelAmount)
    {
        this.FuelAmount -= fuelAmount;
    }
}
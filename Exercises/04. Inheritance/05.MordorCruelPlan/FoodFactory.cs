using System;

public static class FoodFactory
{
    public static Food GetFood(Food.Foods food)
    {
        switch (food)
        {
            case Food.Foods.Cram:
                return new Cram();
            case Food.Foods.Lembas:
                return new Lembas();
            case Food.Foods.Apple:
                return new Apple();
            case Food.Foods.Melon:
                return new Melon();
            case Food.Foods.HoneyCake:
                return new HoneyCake();
            case Food.Foods.Mushrooms:
                return new Mushrooms();
            case Food.Foods.OtherFood:
                return new OtherFood();
            default:
                throw new NotSupportedException();
        }
    }
}
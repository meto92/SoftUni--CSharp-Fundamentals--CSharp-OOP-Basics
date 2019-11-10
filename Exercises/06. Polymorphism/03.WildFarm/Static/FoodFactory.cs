public class FoodFactory
{
    public static Food GetFood(string[] foodParams)
    {
        Food food = null;

        string type = foodParams[0];
        int quantity = int.Parse(foodParams[1]);

        switch (type)
        {
            case "Vegetable":
                food = new Vegetable(quantity);
                break;
            case "Fruit":
                food = new Fruit(quantity);
                break;
            case "Meat":
                food = new Meat(quantity);
                break;
            case "Seeds":
                food = new Seeds(quantity);
                break;
        }

        return food;
    }
}
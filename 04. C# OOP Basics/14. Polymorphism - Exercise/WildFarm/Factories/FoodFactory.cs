public static class FoodFactory
{
    public static Food GetFood(string[] foodParam)
    {
        string type = foodParam[0];
        int quantity = int.Parse(foodParam[1]);

        switch (type)
        {
            case "Vegetable":
                return new Vegetable(quantity);

            case "Meat":
                return new Meat(quantity);

            case "Fruit":
                return new Fruit(quantity);

            case "Seeds":
                return new Seeds(quantity);

            default:
                throw new System.ArgumentException();
        }
    }
}
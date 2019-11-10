public static class AnimalFactory
{
    public static Animal GetAnimal(string[] animalParams)
    {
        Animal animal = null;

        string type = animalParams[0];
        string name = animalParams[1];
        double weight = double.Parse(animalParams[2]);
        double wingSize = 0;
        string livingRegion = animalParams[3];
        string breed = null;

        switch (type)
        {
            case "Owl":
                wingSize = double.Parse(animalParams[3]);
                animal = new Owl(name, weight, wingSize);
                break;
            case "Hen":
                wingSize = double.Parse(animalParams[3]);
                animal = new Hen(name, weight, wingSize);
                break;
            case "Mouse":
                animal = new Mouse(name, weight, livingRegion);
                break;
            case "Dog":
                animal = new Dog(name, weight, livingRegion);
                break;
            case "Cat":
                breed = animalParams[4];
                animal = new Cat(name, weight, livingRegion, breed);
                break;
            case "Tiger":
                breed = animalParams[4];
                animal = new Tiger(name, weight, livingRegion, breed);
                break;
        }

        return animal;
    }
}
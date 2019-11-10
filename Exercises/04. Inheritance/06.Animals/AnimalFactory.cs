using System;

public static class AnimalFactory
{
    public static Animal GetAnimal(Animal.SupportedAnimals animalType, string name, string ageStr, string gender)
    {
        switch (animalType)
        {
            case Animal.SupportedAnimals.Dog:
                return new Dog(name, ageStr, gender);
            case Animal.SupportedAnimals.Frog:
                return new Frog(name, ageStr, gender);
            case Animal.SupportedAnimals.Cat:
                return new Cat(name, ageStr, gender);
            case Animal.SupportedAnimals.Kitten:
                return new Kitten(name, ageStr, gender);
            case Animal.SupportedAnimals.Tomcat:
                return new Tomcat(name, ageStr, gender);
        }

        throw new NotSupportedException();
    }
}
using System;
using System.Text;
using System.Collections.Generic;

public class Person
{
    private class Company
    {
        private string name;
        private string department;
        private decimal salary;

        public Company(string name, string department, decimal salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Department
        {
            get => department;
            set => department = value;
        }

        public decimal Salary
        {
            get => salary;
            set => salary = value;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Department} {this.Salary:f2}";
        }
    }    

    private class Car
    {
        private string model;
        private int speed;

        public Car(string model, int speed)
        {
            this.Model = model;
            this.Speed = speed;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }

        public int Speed
        {
            get => speed;
            set => speed = value;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.Speed}";
        }
    }

    private class Pokemon
    {
        private string name;
        private string type;

        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Type}";
        }
    }

    private class Relation
    {
        private string name;
        private string birthday;

        public Relation(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Birthday
        {
            get => birthday;
            set => birthday = value;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }

    private string name;
    private Company company;
    private Car car;
    private List<Pokemon> pokemons;
    private List<Relation> parents;
    private List<Relation> children;

    public Person(string name)
    {
        this.Name = name;
        this.company = null;
        this.car = null;
        this.pokemons = new List<Pokemon>();
        this.parents = new List<Relation>();
        this.children = new List<Relation>();
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public void SetCompany(string companyName, string department, decimal salary)
    {
        Company company = new Company(companyName, department, salary);

        this.company = company;
    }

    public void SetCar(string carModel, int carSpeed)
    {
        Car car = new Car(carModel, carSpeed);

        this.car = car;
    }

    public void AddPokemon(string pokemonName, string pokemonType)
    {
        Pokemon pokemon = new Pokemon(pokemonName, pokemonType);

        this.pokemons.Add(pokemon);
    }

    public void AddParent(string parentName, string parentBirthday)
    {
        Relation parent = new Relation(parentName, parentBirthday);

        this.parents.Add(parent);
    }

    public void AddChild(string childName, string childBirthday)
    {
        Relation child = new Relation(childName, childBirthday);

        this.children.Add(child);
    }

    private string FormatString(string str)
    {
        return $"{Environment.NewLine}{str}{Environment.NewLine}";
    }

    private string GetCompanyInfo()
    {
        return
            this.company == null
            ? Environment.NewLine
            : FormatString(this.company.ToString());
    }

    private string GetCarInfo()
    {
        return
            this.car == null
            ? Environment.NewLine
            : FormatString(this.car.ToString());
    }

    private object GetPokemonsInfo()
    {
        return this.pokemons.Count == 0
            ? Environment.NewLine
            : FormatString(string.Join(Environment.NewLine, this.pokemons));
    }

    private object GetPeopleInfo(List<Relation> people)
    {
        return
            people.Count == 0
            ? Environment.NewLine
            : FormatString(string.Join(Environment.NewLine, people));
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"{this.Name}{Environment.NewLine}");
        sb.Append($"Company:{GetCompanyInfo()}");
        sb.Append($"Car:{GetCarInfo()}");
        sb.Append($"Pokemon:{GetPokemonsInfo()}");
        sb.Append($"Parents:{GetPeopleInfo(this.parents)}");
        sb.Append($"Children:{GetPeopleInfo(this.children)}");

        return sb.ToString().TrimEnd();
    }
}
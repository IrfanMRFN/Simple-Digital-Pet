namespace Simple_Digital_Pet;

public class Pet
{
    // Properties
    public string Name { get; private set; }
    public int Hunger { get; private set; }
    public int Happiness { get; private set; }
    public int Energy { get; private set; }

    // Constructor
    public Pet(string name)
    {
        Name = name;
        Hunger = 5;     // 0 = full, 10 = very hungry
        Happiness = 5;  // 0 = sad, 10 = very happy
        Energy = 5;     // 0 = exhausted, 10 = full of energy
    }

    // Methods
    public void Feed()
    {
        if (Hunger <= 0)
        {
            Console.WriteLine($"{Name} is not hungry!");
            return;
        }

        Hunger -= 3;
        if (Hunger < 0)
            Hunger = 0;

        Energy += 2;
        if (Energy > 10)
            Energy = 10;

        Happiness += 1;
        if (Happiness > 10)
            Happiness = 10;

        Console.WriteLine($"{Name} has been fed.");
    }

    public void Play()
    {
        if (Energy <= 0)
        {
            Console.WriteLine($"{Name} is too tired to play!");
            return;
        }

        if (Hunger >= 10)
        {
            Console.WriteLine($"{Name} is too hungry to play!");
            return;
        }

        Happiness += 3;
        if (Happiness > 10)
            Happiness = 10;

        Energy -= 2;
        if (Energy < 0)
            Energy = 0;

        Hunger += 1;
        if (Hunger > 10)
            Hunger = 10;

        Console.WriteLine($"{Name} played happily!");
    }

    public void Sleep()
    {
        if (Energy >= 10)
        {
            Console.WriteLine($"{Name} is not tired!");
            return;
        }

        Energy = 10;

        Hunger += 1;
        if (Hunger > 10)
            Hunger = 10;

        Happiness -= 2;
        if (Happiness < 0)
            Happiness = 0;

        Console.WriteLine($"{Name} has slept and is full of energy!");
    }

    public void DoNothing()
    {
        Hunger += 1;
        if (Hunger > 10)
            Hunger = 10;

        Energy -= 1;
        if (Energy < 0)
            Energy = 0;

        Happiness -= 1;
        if (Happiness < 0)
            Happiness = 0;

        Console.WriteLine($"{Name} did nothing and feels a bit worse.");
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"{Name}'s Status:");
        Console.WriteLine($"Hunger: {Hunger}/10");
        Console.WriteLine($"Happiness: {Happiness}/10");
        Console.WriteLine($"Energy: {Energy}/10");
    }

    public bool IsAlive()
    {
        return Hunger < 10 && Energy > 0;
    }
}

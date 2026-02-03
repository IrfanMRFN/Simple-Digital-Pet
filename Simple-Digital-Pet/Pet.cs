namespace Simple_Digital_Pet;

public class Pet
{
    // Fields
    private const int _maxStat = 10;
    private const int _minStat = 0;

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
    public string Feed()
    {
        if (Hunger <= _minStat)
        {
            return $"{Name} is not hungry!";
        }

        Hunger = Math.Clamp(Hunger - 3, _minStat, _maxStat);
        Energy = Math.Clamp(Energy + 2, _minStat, _maxStat);
        Happiness = Math.Clamp(Happiness + 1, _minStat, _maxStat);

        return $"{Name} has been fed.";
    }

    public string Play()
    {
        if (Energy <= _minStat)
        {
            return $"{Name} is too tired to play!";
        }

        if (Hunger >= _maxStat)
        {
            return $"{Name} is too hungry to play!";
        }

        Happiness = Math.Clamp(Happiness + 3, _minStat, _maxStat);
        Energy = Math.Clamp(Energy - 2, _minStat, _maxStat);
        Hunger = Math.Clamp(Hunger + 1, _minStat, _maxStat);

        return $"{Name} played happily!";
    }

    public string Sleep()
    {
        if (Energy >= _maxStat)
        {
            return $"{Name} is not tired!";
        }

        Energy = 10;
        Hunger = Math.Clamp(Hunger + 1, _minStat, _maxStat);
        Happiness = Math.Clamp(Happiness - 2, _minStat, _maxStat);

        return $"{Name} has slept and is full of energy!";
    }

    public string DoNothing()
    {
        Hunger = Math.Clamp(Hunger + 1, _minStat, _maxStat);
        Energy = Math.Clamp(Energy - 1, _minStat, _maxStat);
        Happiness = Math.Clamp(Happiness - 1, _minStat, _maxStat);

        return $"{Name} did nothing and feels a bit worse.";
    }

    public override string ToString()
    {
        return $"{Name}'s Status:\n Hunger: {Hunger}/10\n Happiness: {Happiness}/10\n Energy: {Energy}/10";
    }

    public bool IsAlive()
    {
        return Hunger < 10 && Energy > 0;
    }
}

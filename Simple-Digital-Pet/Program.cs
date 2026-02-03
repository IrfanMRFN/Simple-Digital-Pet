namespace Simple_Digital_Pet;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Simple Digital Pet ===");
        Console.Write("To start, please enter a name for your pet:");
        string? petName = Console.ReadLine();
        
        while (string.IsNullOrWhiteSpace(petName))
        {
            Console.Write("Pet name cannot be empty. Please enter a valid name for your pet:");
            petName = Console.ReadLine();
        }
        Pet myPet = new Pet(petName.Trim());
        Console.WriteLine($"Great! Your pet's name is {myPet.Name}.");
        
        bool exit = false;
        do
        {
            if (!myPet.IsAlive())
            {
                Console.WriteLine($"\nSadly, {myPet.Name} has passed away due to neglect.");
                Console.WriteLine("Game Over. Thank you for playing!");
                exit = true;
                break;
            }

            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Feed");
            Console.WriteLine("2. Play");
            Console.WriteLine("3. Sleep");
            Console.WriteLine("4. Do Nothing");
            Console.WriteLine("5. Check Status");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6): ");
            string? choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    myPet.Feed();
                    break;
                case "2":
                    myPet.Play();
                    break;
                case "3":
                    myPet.Sleep();
                    break;
                case "4":
                    myPet.DoNothing();
                    break;
                case "5":
                    myPet.DisplayStatus();
                    break;
                case "6":
                    exit = true;
                    Console.WriteLine("Thank you for playing! Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a number between 1 and 6.");
                    break;
            }
        } while (!exit);
    }
}
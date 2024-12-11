using System.ComponentModel.DataAnnotations.Schema;

namespace MyCatExhibition;

class Cat 
{
    public int CatId { get; set; }
    public string Name { get; set; }
}

class Owner
{
    public int OwnerId { get; set; }
    public string Name { get; set; }
}

class Program
{
    static DatabaseRepository repo = new DatabaseRepository();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Print ownerss");
            Console.WriteLine("2. Add owner");
            Console.WriteLine("3. Update owner");
            Console.WriteLine("4. Exit");
            Console.Write("Select: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    PrintOwners();
                    break;
                case "2":
                    InsertOwner();
                    break;
                case "3":
                    UpdateOwner();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static void PrintOwners()
    {
        IEnumerable<Owner> owners = repo.GetOwners();
        
        foreach (Owner s in owners)
        {
            Console.WriteLine($"Id: {s.OwnerId} Name: {s.Name}");
        }
    }

    static void InsertOwner()
    {
        // Läsa in namn för ägare
        Console.Write("Name: ");
        string name = Chelp.ReadString();

        repo.InsertOwner(name);
    }

    static void UpdateOwner()
    {
        Console.Write("Ange id på den du vill uppdatera: ");
        int id = Chelp.ReadInt();

        // Uppdatera ägarens namn
        Console.Write("Name: ");
        string name = Chelp.ReadString();

        repo.UpdateOwner(id, name);
    }
}
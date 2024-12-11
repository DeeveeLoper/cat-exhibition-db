using System.ComponentModel.DataAnnotations.Schema;

namespace MyCatExhibition;


class Owner
{
    public int OwnerId { get; set; }
    public string Name { get; set; }
}

class Exhibition
{
    public int ExhibitionId { get; set; }
    public string Name { get; set; }
    public DateTime ExhibitionDate { get; set; }
}

class Cat
{
    public int CatId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}


class Program
{
    static DatabaseRepository repo = new DatabaseRepository();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Visa alla ägare");
            Console.WriteLine("2. Lägg till ägare");
            Console.WriteLine("3. Uppdatera ägare");
            Console.WriteLine("4. Ta bort ägare");

            Console.WriteLine("----------------");
            Console.WriteLine("5. Visa alla utställningar");
            Console.WriteLine("6. Lägg till utställning");
            Console.WriteLine("7. Uppdatera utställning");
            Console.WriteLine("8. Ta bort utställning");

            Console.WriteLine("----------------");
            Console.WriteLine("9. Visa alla katter");
            Console.WriteLine("10. Lägg till katt");
            Console.WriteLine("11. Uppdatera katt");
            Console.WriteLine("12. Ta bort katt");

            Console.WriteLine("----------------");
            Console.WriteLine("a. Avsluta");

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
                    DeleteOwner();
                    break;

                case "5":
                    PrintExhibitions();
                    break;
                case "6":
                    InsertExhibition();
                    break;
                case "7":
                    UpdateExhibition();
                    break;
                case "8":
                    DeleteExhibition();
                    break;

                case "9":
                    PrintCats();
                    break;
                case "10":
                    InsertCat();
                    break;
                case "11":
                    UpdateCat();
                    break;
                case "12":
                    DeleteCat();
                    break;

                case "a":
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    //---------------- Ägare ----------------------------

    static void PrintOwners()
    {
        IEnumerable<Owner> owners = repo.GetOwners();
        
        foreach (Owner s in owners)
        {
            Console.WriteLine($"Id: {s.OwnerId} Namn: {s.Name}");
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
        Console.Write("Ange id på den ägare du vill uppdatera: ");
        int id = Chelp.ReadInt();

        // Uppdatera ägarens namn
        Console.Write("Namn: ");
        string name = Chelp.ReadString();

        repo.UpdateOwner(id, name);
    }

    static void DeleteOwner()
    {
        Console.Write("Ange id på den ägare du vill ta bort: ");
        int id = Chelp.ReadInt();

        repo.DeleteOwner(id);
    }


    //---------------- Utställning ----------------------------

    static void PrintExhibitions()
    {
        IEnumerable<Exhibition> exhibitions = repo.GetExhibitions();

        foreach (Exhibition s in exhibitions)
        {
            Console.WriteLine($"Id: {s.ExhibitionId} Namn: {s.Name} Datum: {s.ExhibitionDate}");
        }
    }

    static void InsertExhibition()
    {
        // Läsa in namn för ägare
        Console.Write("Namn: ");
        string name = Chelp.ReadString();

        Console.Write("Datum för utställning: ");
        DateTime exhibitionDate = Chelp.ReadDate();


        repo.InsertExhibition(name, exhibitionDate);
    }

    static void UpdateExhibition()
    {
        Console.Write("Ange id på den utställning du vill uppdatera: ");
        int id = Chelp.ReadInt();

        // Uppdatera ägarens namn
        Console.Write("Namn: ");
        string name = Chelp.ReadString();

        Console.Write("Datum för utställning: ");
        DateTime exhibitionDate = Chelp.ReadDate();

        repo.UpdateExhibition(id, name, exhibitionDate);
    }

    static void DeleteExhibition()
    {
        Console.Write("Ange id på den utställning du vill ta bort: ");
        int id = Chelp.ReadInt();

        repo.DeleteExhibition(id);
    }


    //---------------- Katt ----------------------------

    static void PrintCats()
    {
        IEnumerable<Cat> cats = repo.GetCats();

        foreach (Cat c in cats)
        {
            Console.WriteLine($"Id: {c.CatId} Namn: {c.Name} Ålder: {c.Age}");
        }
    }

    static void InsertCat()
    {
        // Läsa in namn för ägare
        Console.Write("Namn: ");
        string name = Chelp.ReadString();
        
        Console.Write("Ålder: ");
        int age = Chelp.ReadInt();

        repo.InsertCat(name, age);
    }

    static void UpdateCat()
    {
        Console.Write("Ange id på den katt du vill uppdatera: ");
        int id = Chelp.ReadInt();

        // Uppdatera ägarens namn
        Console.Write("Namn: ");
        string name = Chelp.ReadString();

        Console.Write("Ålder: ");
        int age = Chelp.ReadInt();

        repo.UpdateCat(id, name, age);
    }

    static void DeleteCat()
    {
        Console.Write("Ange id på den katt du vill ta bort: ");
        int id = Chelp.ReadInt();

        repo.DeleteCat(id);
    }
}
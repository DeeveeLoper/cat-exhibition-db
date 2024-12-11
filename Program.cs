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
}


class Program
{
    static DatabaseRepository repo = new DatabaseRepository();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Print owners");
            Console.WriteLine("2. Add owner");
            Console.WriteLine("3. Update owner");
            Console.WriteLine("4. Delete owner");

            Console.WriteLine("----------------");
            Console.WriteLine("5. Print exhibitions");
            Console.WriteLine("6. Add exhibition");
            Console.WriteLine("7. Update exhibition");
            Console.WriteLine("8. Delete exhibition");

            Console.WriteLine("----------------");
            Console.WriteLine("9. Print cats");
            Console.WriteLine("10. Add cat");
            Console.WriteLine("11. Update cat");

            Console.WriteLine("12. Delete cat");

            Console.WriteLine("----------------");
            Console.WriteLine("e. Exit");

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
       //             PrintCat();
                    break;
                case "10":
         //           InsertCat();
                    break;
                case "11":
          //          UpdateCat();
                    break;
                case "12":
            //        DeleteCat();
                    break;

                case "e":
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    //---------------- Owner ----------------------------

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

    static void DeleteOwner()
    {
        Console.Write("Ange id på den ägare du vill ta bort: ");
        int id = Chelp.ReadInt();

        repo.DeleteOwner(id);
    }



    //---------------- Exhibition ----------------------------

    static void PrintExhibitions()
    {
        IEnumerable<Exhibition> exhibitions = repo.GetExhibitions();

        foreach (Exhibition s in exhibitions)
        {
            Console.WriteLine($"Id: {s.ExhibitionId} Name: {s.Name} Date: {s.ExhibitionDate}");
        }
    }

    static void InsertExhibition()
    {
        // Läsa in namn för ägare
        Console.Write("Name: ");
        string name = Chelp.ReadString();

        Console.Write("Date of exhibition: ");
        DateTime exhibitionDate = Chelp.ReadDate();


        repo.InsertExhibition(name, exhibitionDate);
    }

    static void UpdateExhibition()
    {
        Console.Write("Ange id på utställning du vill uppdatera: ");
        int id = Chelp.ReadInt();

        // Uppdatera ägarens namn
        Console.Write("Name: ");
        string name = Chelp.ReadString();

        Console.Write("Date of exhibition: ");
        DateTime exhibitionDate = Chelp.ReadDate();

        repo.UpdateExhibition(id, name, exhibitionDate);
    }

    static void DeleteExhibition()
    {
        Console.Write("Ange id på den utställning du vill ta bort: ");
        int id = Chelp.ReadInt();

        repo.DeleteExhibition(id);
    }

}
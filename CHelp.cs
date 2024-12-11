static class Chelp 
{
    public static int ReadInt()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Ogiltig inmatning, försök igen");
        }
        return input;
    }

    public static string ReadString() 
    {
        string input;
        while (string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            Console.WriteLine("Ogiltigt inmatning, försök igen");
        }
        return input;
    }

    // Användas till exhibition
    public static DateTime ReadDate()
    {
        DateTime input;
        while (!DateTime.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Ogiltigt datumformat, försöker igen (åååå-mm-dd)");
        }
        return input;
    }
}
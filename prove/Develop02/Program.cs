using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Search journal");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    myJournal.AddEntry();
                    break;
                case "2":
                    myJournal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    myJournal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    myJournal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    Console.Write("Enter keyword to search: ");
                    string keyword = Console.ReadLine();
                    myJournal.SearchEntries(keyword);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}

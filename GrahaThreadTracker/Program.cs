internal class Program
{
    private static void Main(string[] args)
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }
    }
    private static bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Month Header");
        Console.WriteLine("2) Thread");
        Console.WriteLine("3) Exit");
        Console.Write("\r\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                CodeMonth();
                return true;
            case "2":
                CodeThread();
                return true;
            case "3":
                return false;
            default:
                return true;
        }
    }
    private static void CodeMonth()
    {
        Console.Clear();
        Console.WriteLine("Enter month and year:");
        string fullMonth = Console.ReadLine();
        Console.WriteLine("<div style=\"width:850px;font-family:Arial Black, Gadget;font-size:30px;letter-spacing:5px;text-transform:uppercase;text-align:right;\">" + fullMonth.ToUpper() + "</div>");
        Console.WriteLine("<div style=\"width:100%;text-align:justify;border-radius:10px;border-top: 15px solid #5DA2D3;padding:15px;\">");
        Console.WriteLine("Place your entries here");
        Console.WriteLine("</div>");
        Console.Write("\r\nPress Enter to return to Main Menu");
        Console.ReadLine();
    }
    private static void CodeThread()
    {
        Console.Clear();
        Console.WriteLine("This thread is:");
        Console.WriteLine("1) My post");
        Console.WriteLine("2) My top level");
        Console.WriteLine("3) A tag out");
        Console.WriteLine("4) A new thread on a pre-existing tracker entry");
        Console.Write("\r\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                Console.Clear();
                string finalCode = Entry(true);
                int tagIns = TagIns();
                while (tagIns > 0)
                {
                    finalCode += SingleThread();
                    tagIns--;
                }
                Console.WriteLine("\r\nYour final code is:");
                Console.WriteLine(finalCode + "\r\n</ul>");
                Console.WriteLine("\r\nPress Enter to return to Main Menu");
                Console.ReadLine();
                return;
            case "2":
                Console.Clear();
                finalCode = Entry(false);
                Console.WriteLine("Enter top-level URL:");
                string threadURL = Console.ReadLine();
                finalCode += $"<li><b><a href=\"{threadURL}\" style=\"text-decoration:none;color:#5DA2D3;\">Top Level:</a></b></li>\r\n<ul>";
                tagIns = TagIns();
                while (tagIns > 0)
                {
                    Console.WriteLine("Enter character name:");
                    string charName = Console.ReadLine();
                    Console.WriteLine("Enter character journal name:");
                    string charJournal = Console.ReadLine();
                    finalCode += $"\r\n<li>{charName} (<user name=\"{charJournal}\">)</li>";
                    tagIns--;
                }
                Console.WriteLine("\r\nYour final code is:");
                Console.WriteLine(finalCode + "\r\n</ul>");
                Console.WriteLine("\r\nPress Enter to return to Main Menu");
                Console.ReadLine();
                return;
            case "3":
                Console.Clear();
                finalCode = Entry(false) + SingleThread() + "\r\n</ul>";
                Console.WriteLine("\r\nYour final code is:");
                Console.WriteLine(finalCode);
                Console.WriteLine("\r\nPress Enter to return to Main Menu");
                Console.ReadLine();
                return;
            case "4":
                Console.Clear();
                finalCode = SingleThread();
                Console.WriteLine("\r\nYour final code is:");
                Console.WriteLine(finalCode);
                Console.WriteLine("\r\nPress Enter to return to Main Menu");
                Console.ReadLine();
                return;
            default:
                return;
        }
    }
    private static int TagIns()
    {
        Console.WriteLine("How many tag ins?");
        return Convert.ToInt32(Console.ReadLine());
    }
    private static string SingleThread()
    {
        Console.WriteLine("Enter thread URL:");
        string threadURL = Console.ReadLine();
        Console.WriteLine("Enter character name:");
        string charName = Console.ReadLine();
        Console.WriteLine("Enter character journal name:");
        string charJournal = Console.ReadLine();
        return $"\r\n<li><b><a href=\"{threadURL}\" style=\"text-decoration:none;color:#93762D;\">Thread:</a></b> {charName} (<user name=\"{charJournal}\">)</li>";
    }
    private static string Entry(bool myEntry)
    {
        Console.WriteLine("Enter entry URL:");
        string entryURL = Console.ReadLine();
        Console.WriteLine("Enter entry date:");
        string entryDate = Console.ReadLine();
        Console.WriteLine("Enter entry name:");
        string entryName = Console.ReadLine();

        //An entry my character is the OP for has a different text color than one I tag into
        if (myEntry == true)
        {
            return $"<p><B>&#9203; <a href=\"{entryURL}\" style=\"text-decoration:none;color:#5DA2D3;\">{entryDate} -- {entryName}</A></B>\r\n<ul>";
        }
        else
        {
            return $"<p><B>&#9203; <a href=\"{entryURL}\" style=\"text-decoration:none;color:#93762D;\">{entryDate} -- {entryName}</A></B>\r\n<ul>";
        }
    }
}
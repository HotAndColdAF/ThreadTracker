using GrahaThreadTracker;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    const string saveFile = "savefile.txt";
    public static List<Chara> charas = new List<Chara>();
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
        Console.WriteLine("1) Select Character");
        Console.WriteLine("2) Add Character");
        Console.WriteLine("3) Delete Character");
        Console.WriteLine("4) Exit");
        Console.Write("\r\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                bool showChara = true;
                while (showChara)
                {
                    showChara = CharaMenu();
                }
                return true;
            case "2":
                SaveSettings();
                return true;
            case "3":
                bool showDelete = true;
                while (showDelete)
                {
                    showDelete = DeleteSettings();
                }
                return true;
            case "4":
                return false;
            default:
                return true;
        }
    }
    private static bool CharaMenu()
    {
        Console.Clear();
        LoadSettings();
        Console.WriteLine("Select Character:");
        int listNum = 1;
        foreach (Chara aChar in charas)
        {
            Console.WriteLine(listNum + ") " + aChar.name);
            listNum++;
        }
        Console.WriteLine(listNum + ") Return to previous menu");
        Console.Write("\r\nSelect an option: ");
        try
        {
            int charSelect = Convert.ToInt32(Console.ReadLine());
            if (charSelect == listNum)
            {
                return false;
            }
            else if (charSelect < listNum)
            {
                CodeMenu(charas.ElementAt(charSelect - 1));
                return true;
            }
            else
            {
                return true;
            }
        }
        catch (Exception)
        {
            return true;
        }
    }
    private static bool CodeMenu(Chara chara)
    {
        Console.Clear();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Month Header");
        Console.WriteLine("2) Thread");
        Console.WriteLine("3) Return to previous menu");
        Console.Write("\r\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                CodeMonth(chara);
                return true;
            case "2":
                bool showThread = true;
                while (showThread)
                {
                    showThread = CodeThread(chara);
                }
                return true;
            case "3":
                return false;
            default:
                return true;
        }
    }
    private static void CodeMonth(Chara chara)
    {
        Console.Clear();
        Console.WriteLine("Enter month and year:");
        string fullMonth = Console.ReadLine();
        Console.WriteLine("<div style=\"width:850px;font-family:Arial Black, Gadget;font-size:30px;letter-spacing:5px;text-transform:uppercase;text-align:right;\">" + fullMonth.ToUpper() + "</div>");
        Console.WriteLine($"<div style=\"width:100%;text-align:justify;border-radius:10px;border-top: 15px solid {chara.header};padding:15px;\">");
        Console.WriteLine("Place your entries here");
        Console.WriteLine("</div>");
        Console.Write("\r\nPress Enter to return");
        Console.ReadLine();
    }
    private static bool CodeThread(Chara chara)
    {
        Console.Clear();
        Console.WriteLine("This thread is:");
        Console.WriteLine("1) My post");
        Console.WriteLine("2) My top level");
        Console.WriteLine("3) A tag out");
        Console.WriteLine("4) A new thread on a pre-existing tracker entry");
        Console.WriteLine("5) Return to previous menu");
        Console.Write("\r\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                Console.Clear();
                string finalCode = Entry(true, chara);
                int tagIns = TagIns();
                while (tagIns > 0)
                {
                    finalCode += SingleThread(chara);
                    tagIns--;
                }
                finalCode += "\r\n</ul>";
                FinalCode(finalCode);
                return true;
            case "2":
                Console.Clear();
                finalCode = Entry(false, chara);
                Console.WriteLine("Enter top-level URL:");
                string threadURL = Console.ReadLine();
                finalCode += $"<li><b><a href=\"{threadURL}\" style=\"text-decoration:none;color:{chara.op};\">Top Level:</a></b></li>\r\n<ul>";
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
                finalCode += "\r\n</ul>";
                FinalCode(finalCode);
                return true;
            case "3":
                Console.Clear();
                finalCode = Entry(false, chara) + SingleThread(chara) + "\r\n</ul>";
                FinalCode(finalCode);
                return true;
            case "4":
                Console.Clear();
                finalCode = SingleThread(chara);
                FinalCode(finalCode);
                return true;
            case "5":
                return false;
            default:
                return true;
        }
    }
    private static int TagIns()
    {
        Console.WriteLine("How many tag ins?");
        return Convert.ToInt32(Console.ReadLine());
    }
    private static string SingleThread(Chara chara)
    {
        Console.WriteLine("Enter thread URL:");
        string threadURL = Console.ReadLine();
        Console.WriteLine("Enter character name:");
        string charName = Console.ReadLine();
        Console.WriteLine("Enter character journal name:");
        string charJournal = Console.ReadLine();
        return $"\r\n<li><b><a href=\"{threadURL}\" style=\"text-decoration:none;color:{chara.normal};\">Thread:</a></b> {charName} (<user name=\"{charJournal}\">)</li>";
    }
    private static string Entry(bool myEntry, Chara chara)
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
            return $"<p><B>{chara.bullet}; <a href=\"{entryURL}\" style=\"text-decoration:none;color:{chara.op};\">{entryDate} -- {entryName}</A></B>\r\n<ul>";
        }
        else
        {
            return $"<p><B>{chara.bullet}; <a href=\"{entryURL}\" style=\"text-decoration:none;color:{chara.normal};\">{entryDate} -- {entryName}</A></B>\r\n<ul>";
        }
    }
    private static void FinalCode(string finalCode)
    {
        Console.WriteLine("\r\nYour final code is:");
        Console.WriteLine(finalCode);
        Console.WriteLine("\r\nPress Enter to return to Main Menu");
        Console.ReadLine();
    }
    private static void LoadSettings()
    {
        int charaNum = 0;
        if (File.Exists(saveFile))
        {
            charas.Clear();
            foreach (string line in File.ReadLines(saveFile))
            {
                string[] charGen = line.Split(',');
                charas.Add(new Chara(charGen[0], charGen[1], charGen[2], charGen[3], charGen[4]));
                charaNum++;
            }
        }
        return;
    }
    private static void SaveSettings()
    {
        Console.Clear();
        string addText;
        Console.WriteLine("Enter character name:");
        if (File.Exists(saveFile))
        {
            addText = Environment.NewLine + Console.ReadLine() + ",";
        }
        else
        {
            addText = Console.ReadLine() + ",";
        }
        Console.WriteLine("Enter Unicode value for bullet (HTML code, ex. &#9203):");
        addText += Console.ReadLine() + ",";
        Console.WriteLine("Enter hex code for header color (include #):");
        addText += Console.ReadLine() + ",";
        Console.WriteLine("Enter hex code for normal link color (include #):");
        addText += Console.ReadLine() + ",";
        Console.WriteLine("Enter hex code for link color to use when your charcter is the OP (include #):");
        addText += Console.ReadLine();
        File.AppendAllText(saveFile, addText);
        Console.WriteLine("Character information saved. Press Enter to return to previous menu.");
        Console.ReadLine();
    }
    private static bool DeleteSettings()
    {
        Console.Clear();
        LoadSettings();
        Console.WriteLine("Select Character for deletion:");
        int listNum = 1;
        foreach (Chara aChar in charas)
        {
            Console.WriteLine(listNum + ") " + aChar.name);
            listNum++;
        }
        Console.WriteLine(listNum + ") Return to previous menu");
        Console.Write("\r\nSelect an option: ");
        try
        {
            int charSelect = Convert.ToInt32(Console.ReadLine());
            if (charSelect == listNum)
            {
                return false;
            }
            else if (charSelect < listNum)
            {
                charas.Remove(charas.ElementAt(charSelect - 1));
                return true;
            }
            else
            {
                return true;
            }
        }
        catch (Exception)
        {
            return true;
        }
    }
}

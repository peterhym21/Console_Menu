using System.Diagnostics;

namespace Projekt_626_2023_Menu
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(new List<string>() { "--== Kim's Joy Junction ==--", "Snake", "MushroomTD", "Mystic-Woods", "Exit" });
            do
            {
                Console.Clear();
                menu.Select();
                Console.Clear();

                switch (menu.GetResult())
                {
                    case "Snake":
                        _ = Process.Start(@"C:\Games\Snake\Snake.exe");
                        break;
                    case "MushroomTD":
                        _ = Process.Start(@"C:\Games\MushroomTD\MushroomTD.exe");
                        break;
                    case "Mystic-Woods":
                        _ = Process.Start(@"C:\Games\Mystic-Woods\Mystic-Woods.exe");
                        break;
                    default:
                        break;

                }

            } while (menu.GetResult() != "Exit");
        }
    }
}
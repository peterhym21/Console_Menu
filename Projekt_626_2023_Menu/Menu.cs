namespace Projekt_626_2023_Menu
{
    public class Menu
    {
        int index = 0;
        ConsoleKeyInfo lastKeyPressed;
        List<string> items;
        string choice = "";
        ConsoleColor menuColor;
        int x_akse;
        int y_akse;

        public Menu(List<string> items, ConsoleColor menuColor = ConsoleColor.DarkRed)
        {
            Console.CursorVisible = false;
            this.items = items;
            this.menuColor = menuColor;
            x_akse = Console.WindowWidth;
            y_akse = Console.WindowHeight;
        }

        public void Select()
        {
            do
            {
                #region Select items
                foreach (var item in items)
                {
                    int maxSize = FindLongestItemLength(items);
                    Console.CursorTop = Console.WindowHeight / 2 - items.Count + items.IndexOf(item) + 1;

                    #region Select item

                    #region Padding
                    Console.CursorLeft = Console.WindowWidth / 2 - maxSize / 2 - 2;
                    Console.Write(new String(' ', maxSize / 2 - item.Length / 2));
                    #endregion

                    #region Select item text
                    if (items.IndexOf(item) == index)
                    {
                        Console.Write($"[ ");
                        Console.ForegroundColor = menuColor;
                        Console.Write(item);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" ]");
                    }
                    else
                    {
                        Console.Write($"  {item}  ");
                    }
                    #endregion

                    #region Padding
                    Console.Write(new String(' ', maxSize / 2 + item.Length / 2));
                    Console.WriteLine();
                    #endregion

                    #endregion
                }
                #endregion

                #region Menu controls
                lastKeyPressed = Console.ReadKey();
                switch (lastKeyPressed.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        else
                            index = items.Count - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index < items.Count - 1)
                            index++;
                        else
                            index = 0;
                        break;
                    default:
                        break;
                }
                // for resising af vinduet
                if (x_akse != Console.WindowWidth || y_akse != Console.WindowHeight)
                {
                    x_akse = Console.WindowWidth;
                    y_akse = Console.WindowHeight;
                    Console.Clear();
                    Console.CursorVisible = false;
                }
                #endregion

            } while (lastKeyPressed.Key != ConsoleKey.RightArrow);   // Continue until item is selected
            choice = items[index];   // Save answer
            // Console.CursorVisible = true;    //  til at få markeren tilbage
        }
        public string GetResult()
        {
            return choice;
        }

        #region Internal methods

        static int FindLongestItemLength(List<string> items)
        {
            int maxLength = 0;
            foreach (var item in items)
            {
                if (item.Length > maxLength)
                    maxLength = item.Length;
            }
            return maxLength;
        }

        #endregion
    }
}

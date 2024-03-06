using System.Diagnostics;

namespace ScreenManagerV3
{
    internal class VirtualScreen : Utility
    {
        public static int Width = 155;
        public static int Height = 35;
        static char[,] buffer = new char[Width, Height];

        // Windows Loaded
        public static List<Window> windows = new List<Window>();




        //
        public static void Draw()
        {
            Clear();
            AreaHandler.ClearAreas();

            // Sort windows
            windows.Sort((window1, window2) => window1.Priority.CompareTo(window2.Priority));

            // Draw on the virtual screen first and show later
            foreach (Window win in windows)
            {
                if (win.IsVisible)
                {
                    //-- AreaHandler.AddArea(new Position(win.OffsetX, win.OffsetY), new Position(win.OffsetX+win.Width, win.OffsetY+win.Height));

                    // Create window box and loop through components and draw components?
                    win.Draw();
                    Debug.WriteLine(win.Title + " --");

                    // Loop through components
                    foreach (Drawable com in win.Components)
                    {
                        if (com.IsVisible)
                        {
                            if (com.Interactable == true)
                                AreaHandler.AddArea(new Position(com.OffsetX, com.OffsetY), new Position(com.OffsetX + com.Width, com.OffsetY + com.Height));
                            
                            Debug.WriteLine(com.Title);
                            com.Draw();
                        }
                    }
                }
            }

            AreaHandler.CheckAreas();
            ShowScreen();
        }

        static void ShowScreen()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(buffer[x, y]);
                }

                if (y < Height - 1)
                    Console.WriteLine();
            }
            Console.CursorVisible = true;
        }



        //
        public static void SetPixel(int x, int y, char c)
        {
            bool xExists = x >= 0 && x < buffer.GetLength(0);
            bool yExists = y >= 0 && y < buffer.GetLength(1);

            if (xExists && yExists)
            {
                if (!char.IsLetterOrDigit(c) && c != ' ')
                    c = GetIntersectionCharacter(buffer, x, y, Width, Height, c);

                buffer[x, y] = c;
            }
            else
                Console.WriteLine(x + ", " + y + " : doesnt exist!");
        }

        public static void Clear()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    buffer[x, y] = ' ';
                }
            }
        }
    }
}

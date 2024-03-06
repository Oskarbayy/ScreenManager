using ScreenManagerV3.Objects;

namespace ScreenManagerV3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey(false);

            // Create the MainWindow and its Components
            MainWindow mWin1 = new MainWindow(0, 0, 147, 35, 1, true, "Main Window");
            Button btn = new Button(mWin1, mWin1.Width - 2 - 15, 1, 15, 3, 1, true, "New User!");

            ViewWindow vWin1 = new ViewWindow(mWin1, 2, 4, 143, 30, 2, true, "ViewWindow");

            //

            int dWidth = 30;
            int dHeight = 25;
            DialogWindow dWin1 = new DialogWindow(mWin1.Width / 2 - dWidth / 2, mWin1.Height / 2 - dHeight/2, dWidth, dHeight, 1, false, "Edit Window");
            // Components gets added inside the class ^


            VirtualScreen.Draw();

            // Main loop develop here
            while (true)
            {
                ConsoleKey key = Console.ReadKey(false).Key;
                if (key == ConsoleKey.Q)
                {
                    break;
                }

                mWin1.IsVisible = !mWin1.IsVisible;

                dWin1.IsVisible = !dWin1.IsVisible;

                VirtualScreen.Draw();
            }
        }
    }
}
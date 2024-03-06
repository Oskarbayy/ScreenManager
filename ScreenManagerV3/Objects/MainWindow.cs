using System.Diagnostics;

namespace ScreenManagerV3
{
    internal class MainWindow : Window
    {
        public MainWindow(int offsetX, int offsetY, int width, int height, int priority, bool isVisible, string title)
            : base(offsetX, offsetY, width, height, priority, isVisible, title) 
        {

            // Add to lists
            VirtualScreen.windows.Add(this);
        }

        public override void Draw()
        {
            Debug.WriteLine(this.Priority);
            DrawWindow(this);
            AddText(OffsetX + Width / 2 - Title.Length / 2, OffsetY + 1, Title);
        }
    }
}

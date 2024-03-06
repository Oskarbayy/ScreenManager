using System.Diagnostics;

namespace ScreenManagerV3
{
    internal abstract class Drawable : Utility
    {
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Priority { get; set; }
        public bool IsVisible { get; set; }
        public string Title { get; set; }
        public Window? Parent { get; set; }
        public bool? Interactable { get; set; }
        public Drawable(Window? parent, int offsetX, int offsetY, int width, 
            int height, int priority, bool isVisible, string title, bool interactable)
        {
            OffsetX = offsetX;
            OffsetY = offsetY;
            Width = width;
            Height = height;
            Priority = priority;
            IsVisible = isVisible;
            Title = title;
            Parent = parent;
            Interactable = interactable;
        }

        // Abstract method to be implemented by derived classes.
        public abstract void Draw();
    }

    internal abstract class Window : Drawable
    {
        // Properties all windows should have //
        public List<Window> ChildWindows { get; } = new List<Window>();   // All windows made under this window should be added here
        public List<Drawable> Components { get; } = new List<Drawable>(); // everything that isnt a window under the window should be added here

        public Window(int offsetX, int offsetY, int width, int height, int priority, bool isVisible, string title)
            : base(null, offsetX, offsetY, width, height, priority, isVisible, title, false)
        {

        }

        public abstract override void Draw();
    }
}

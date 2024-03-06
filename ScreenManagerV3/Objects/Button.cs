namespace ScreenManagerV3.Objects
{
    internal class Button : Drawable
    {


        public Button(Window parent, int offsetX, int offsetY, int width, int height, int priority, bool isVisible, string title)
            : base(parent, offsetX, offsetY, width, height, priority, isVisible, title, true)
        {

            Parent.Components.Add(this);
        }

        public override void Draw()
        {
            DrawWindow(this);
            AddText(OffsetX + Width / 2 - Title.Length / 2, OffsetY + 1, Title);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManagerV3.Objects
{
    internal class Combobox : Drawable
    {

        public Combobox(Window parent, int offsetX, int offsetY, int width, int height, int priority, bool isVisible, string title)
            : base(parent, offsetX, offsetY, width, height, priority, isVisible, title, true)
        {

            Parent.Components.Add(this);
        }

        public override void Draw()
        {
            DrawWindow(this);
            DrawBox(OffsetX+Width-2, OffsetY, 2, 2);

            AddText(Parent.OffsetX + 2 /*Parent.Width / 4 - Title.Length / 2*/, OffsetY + 1, Title);

        }
    }
}

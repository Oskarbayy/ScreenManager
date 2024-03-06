using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ScreenManagerV3.Objects
{
    internal class DialogWindow : Window
    {
        string[] inputFields = { 
        "Fornavn",
        "Efternavn",
        "EmailAdr",
        "Mobil",
        "Addresse"
        };

        public DialogWindow(int offsetX, int offsetY, int width, int height, int priority, bool isVisible, string title)
            : base(offsetX, offsetY, width, height, priority, isVisible, title)
        {

            // Create components
            int index = 1;
            foreach (string fieldStr in inputFields)
            {
                InputField input = new InputField(this, OffsetX + Width / 2, OffsetY + 3 * index, Width / 2 - 1, 3, 1, true, fieldStr); // x on exact other side of middle
                index++;
            }

            Combobox cBox = new Combobox(this, OffsetX + Width / 2, OffsetY + 3 * index, Width / 2 - 1, 2, 1, true, "Titel");

            VirtualScreen.windows.Add(this);
        }

        public override void Draw()
        {
            DrawWindow(this);
            AddText(OffsetX + Width / 2 - Title.Length / 2, OffsetY + 1, Title);
        }
    }
}

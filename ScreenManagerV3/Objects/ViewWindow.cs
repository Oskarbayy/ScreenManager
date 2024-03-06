using System.Diagnostics;

namespace ScreenManagerV3.Objects
{
    internal class ViewWindow : Window
    {
        int[] columnsArr = { 8, 17, 20, 25, 13, 23, 23, 11, 11 }; // where every collumn should start Horizontally
        string[] columnsArrNames = {
            "ID",
            "Fornavn",
            "Efternavn",
            "EmailAdr",
            "Mobil",
            "Adresse",
            "Titel",
            "Slet",
            "Edit"
        };

        public ViewWindow(Window Parent, int offsetX, int offsetY, int width, int height, int priority, bool isVisible, string title)
            : base(offsetX, offsetY, width, height, priority, isVisible, title)
        {


            Parent.Components.Add(this);
        }

        public override void Draw()
        {
            DrawWindow(this);

            // Now draw columns
            int curOffset = 0;
            int index = 0;
            foreach (var column in columnsArr)
            {
                DrawBox(OffsetX + curOffset, OffsetY, column, 3);
                AddText(OffsetX + curOffset + column/2 - columnsArrNames[index].Length / 2, OffsetY + 1, columnsArrNames[index]);
                DrawBox(OffsetX + curOffset, OffsetY, column, Height);

                curOffset += column-1;
                index++;
            }
        }
    }
}

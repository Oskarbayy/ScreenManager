using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManagerV3
{
    public struct Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    internal class Area
    {
        public Position TopLeft { get; set; }
        public Position BottomRight { get; set; }

        public Area(Position topLeft, Position bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }
    }

    internal class AreaHandler
    {
        static List<Area> areas  = new List<Area>();

        public static void AddArea(Position topL, Position bottomR)
        {
            areas.Add(new Area(topL, bottomR));
        }

        public static void CheckAreas()
        {
            foreach (Area area in areas)
            {
                Debug.WriteLine($"{area.TopLeft.X}, {area.TopLeft.Y} / {area.BottomRight.X}, {area.BottomRight.Y}");
            }
        }

        public static void ClearAreas()
        {
            areas.Clear();
        }
    }
}

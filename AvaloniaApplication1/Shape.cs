using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;

namespace AvaloniaApplication1
{
    abstract class Shape
    {
        protected int x { get; set; }
        protected int y { get; set; }
        protected static int r;
        public abstract bool IsInside(double xx, double yy);
        public bool IsMoving { get; set; }
        static Shape()
        {
            r = 25;
        }
        protected Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get => x;
            set => x = value;
        }

        public int Y
        {
            get => y;
            set => y = value;
        }
        public abstract void Draw(DrawingContext dc);
    }
}

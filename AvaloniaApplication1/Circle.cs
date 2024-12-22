using System;
using Avalonia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaApplication1
{
    class Circle : Shape
    {
        public Circle(int x, int y) : base(x, y)
        {
        }
        public override bool IsInside(double xx, double yy)
        {
            return (x - xx) * (x - xx) + (y - yy) * (y - yy) <= r * r;
        }

        public override void Draw(DrawingContext dc)
        {
            Pen pen = new Pen(Brushes.Chocolate, thickness: 2, lineCap: PenLineCap.Square);
            Brush brush = new SolidColorBrush(Colors.Black);
            dc.DrawEllipse(brush, pen, new Point(200, 200), radiusX: 10, radiusY: 10);
            Console.WriteLine("drawing");
        }
    }
}

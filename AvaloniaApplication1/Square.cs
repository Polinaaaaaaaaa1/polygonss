using System;
using Avalonia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;

namespace AvaloniaApplication1
{
    class Square : Shape
    {
        public Square(int x, int y) : base(x, y) { }
        public override bool IsInside(double xx, double yy)
        {
            double halfSide =r/2.0;

            double left = x - halfSide;   // Левая граница
            double right = x + halfSide;  // Правая граница
            double top = y + halfSide;    // Верхняя граница
            double bottom = y - halfSide; // Нижняя граница
            return (xx >= left && xx <= right && yy >= bottom && yy <= top);
        }
        public override void Draw(DrawingContext dc)
        {
            Pen pen = new Pen(Brushes.Chocolate, thickness: 2, lineCap: PenLineCap.Square);
            Brush brush = new SolidColorBrush(Colors.Black);
            var r2 = r / (float)Math.Sqrt(2);
            var p1 = new Point(x - r2, y + r2);
            var p2 = new Point(x + r2, y + r2);
            var p3 = new Point(x + r2, y - r2);
            var p4 = new Point(x - r2, y - r2);
            dc.DrawLine(pen, p1,p2);
            dc.DrawLine(pen, p2, p3);
            dc.DrawLine(pen, p3, p4);
            dc.DrawLine(pen, p4, p1);
            //dc.DrawLine(pen, p4, p5);
            // dc.DrawLine(pen, p5, p6);
        }
    }
}

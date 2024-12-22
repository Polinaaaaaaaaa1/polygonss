using System;
using Avalonia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;

namespace AvaloniaApplication1
{
    class Triangle : Shape
    {
        public Triangle(int x, int y) : base(x, y) { }
        private Point _p1, _p2, _p3;

        public override void Draw(DrawingContext dc)
        {
            Pen pen = new Pen(Brushes.Chocolate, thickness: 2, lineCap: PenLineCap.Square);
            Brush brush = new SolidColorBrush(Colors.Black);
            var p1 = new Point(x, y - r);
            var p2 = new Point(x - r * (float)Math.Sqrt(3) / 2, y + (float)r / 2);
            var p3 = new Point(x + r * (float)Math.Sqrt(3) / 2, y + (float)r / 2);
            dc.DrawLine(pen, p1, p2);
            dc.DrawLine(pen, p2, p3);
            dc.DrawLine(pen, p3, p1);
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
        }

        public double SemiPerimeter(Point p1, Point p2,  Point p3)//полупериметр
        {
            double a = Distance(p2,p1);
            double b = Distance(p3, p2);
            double c = Distance(p3, p1);
            return (a + b + c) / 2;
        }
        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
         public double TriangleArea(Point p1, Point p2, Point p3)
    {
        double semiPerimeter = SemiPerimeter(p1, p2, p3);
        double a = Distance(p1, p2);
        double b = Distance(p2, p3);
        double c = Distance(p3, p1);
        return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
    }

    public override bool IsInside(double xx, double yy)
    {
        var pointClick = new Point(xx, yy);
        double totalArea = TriangleArea(_p1, _p2, _p3);
        double area1 = TriangleArea(pointClick, _p2, _p3);
        double area2 = TriangleArea(_p1, pointClick, _p3);
        double area3 = TriangleArea(_p1, _p2, pointClick);

        return Math.Abs(totalArea - (area1 + area2 + area3)) < 1e-6;
    }
    }
}

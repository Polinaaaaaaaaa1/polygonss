using System;
using Avalonia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Controls.Shapes;


namespace AvaloniaApplication1
{
    public class CustomControl : UserControl
    {
       private double cx, cy;
        private int _prevX, _prevY;
        private List<Shape> _draggedShapes = new List<Shape>();


        private List<Shape> _shapes = new List<Shape>();

        private void InitializeShapes()
        {
            _shapes = new List<Shape>
    {
        new Circle(100, 100),
        new Circle(300, 300),
        new Triangle(200, 400),
        new Square(500, 300)
    };
        }


        // Метод для отрисовки фигур
        public override void Render(DrawingContext drawingContext)
        {
            // Отрисовка всех фигур
            foreach (var shape in _shapes)
            {
                shape.Draw(drawingContext);
            }

            Console.WriteLine("Drawing");
        }

        public void Click(int clickedX, int clickedY)
        {
            foreach (var shape in _shapes)
            {
                if (shape.IsInside(clickedX, clickedY)) // Если точка внутри фигуры
                {
                    Console.WriteLine("Figure clicked"); 

                    _prevX = clickedX;
                    _prevY = clickedY;

                    shape.IsMoving = true;

                    //_draggedShapes.Add(shape);
                }
            }
            InvalidateVisual(); // Перерисовать окно
        }
        public void Move(int newX, int newY)
        {
            foreach (var shape in _draggedShapes)
            {
                Console.WriteLine("Moving shape");

                shape.X += newX - _prevX;
                shape.Y += newY - _prevY;
            }

            _prevX = newX;
            _prevY = newY;

            InvalidateVisual();
        }

        public void Release(int newX, int newY)
        {
            foreach (var shape in _draggedShapes)
            {
                Console.WriteLine("Releasing shape");

                shape.X += newX - _prevX;
                shape.Y += newY - _prevY;

                shape.IsMoving = false;
            }

            _draggedShapes.Clear();

            _prevX = newX;
            _prevY = newY;

            InvalidateVisual();
        }





    }
}

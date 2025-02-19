using Avalonia.Controls;
using Avalonia.Input;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnPointerPressed(object sender, PointerPressedEventArgs e)
        {
            CustomControl? customControl = this.Find<CustomControl>("MyCustomControl");
            customControl?.Click((int)e.GetPosition(customControl).X, (int)e.GetPosition(customControl).Y);
        }

        private void OnPointerMoved(object? sender, PointerEventArgs e)
        {
            CustomControl? customControl = this.Find<CustomControl>("MyCustomControl");
            customControl?.Move((int)e.GetPosition(customControl).X, (int)e.GetPosition(customControl).Y);
        }

        private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            CustomControl? customControl = this.Find<CustomControl>("MyCustomControl");
            customControl?.Release((int)e.GetPosition(customControl).X, (int)e.GetPosition(customControl).Y);
        }
    }
}
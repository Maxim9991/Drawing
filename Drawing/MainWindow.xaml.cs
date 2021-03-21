using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Drawing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RGB color { get; set; }
        public Color clr { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;

            color = new RGB();
            color.Red = 0;
            color.Green = 0;
            color.Blue = 0;
            lblCOLOR.Background = new SolidColorBrush(Color.FromRgb(color.Red, color.Green, color.Blue));

            myInkCanvas.DefaultDrawingAttributes.Width = 10;
            myInkCanvas.DefaultDrawingAttributes.Height = 10;
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            myInkCanvas.DefaultDrawingAttributes.Color = Colors.Red;
        }

        private void btnBlue_Click(object sender, RoutedEventArgs e)
        {
            myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            myInkCanvas.DefaultDrawingAttributes.Color = Colors.Blue;
        }

        private void btnYellow_Click(object sender, RoutedEventArgs e)
        {
            myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            myInkCanvas.DefaultDrawingAttributes.Color = Colors.Yellow;
        }

        private void btnBlack_Click(object sender, RoutedEventArgs e)
        {
            myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            myInkCanvas.DefaultDrawingAttributes.Color = Colors.Black;
        }

        private void sld_Color_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;

            var slider = sender as Slider;
            string crlName = slider.Name;
            double value = slider.Value;

            if (crlName.Equals("sldRed"))
            {
                color.Red = Convert.ToByte(value);
            }
            if (crlName.Equals("sldGreen"))
            {
                color.Green = Convert.ToByte(value);
            }
            if (crlName.Equals("sldBlue"))
            {
                color.Blue = Convert.ToByte(value);
            }

             
            clr = Color.FromRgb(color.Red, color.Green, color.Blue);
            
            lblCOLOR.Background = new SolidColorBrush(Color.FromRgb(color.Red, color.Green, color.Blue));

            myInkCanvas.DefaultDrawingAttributes.Color = clr;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            myInkCanvas.Strokes.Clear();
        }

        private void btn_Select_Click(object sender, RoutedEventArgs e)
        {
            myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
        }

        private void btn_AddText_Click(object sender, RoutedEventArgs e)
        {
            TextBox tb = new TextBox
            {
                Width = 100,
                Height = 50,
                BorderThickness = new Thickness(1),
                BorderBrush = new SolidColorBrush(Color.FromRgb(5, 5, 5)),
                Margin = new Thickness(20, 20, 0, 0)
            };
            
            myInkCanvas.Children.Add(tb);
            tb.Focus();
        }

        private void btnRubber_Click(object sender, RoutedEventArgs e)
        {
            myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        private void sldSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;

            myInkCanvas.DefaultDrawingAttributes.Width = slider.Value;
            myInkCanvas.DefaultDrawingAttributes.Height = slider.Value;
        }
    }
}

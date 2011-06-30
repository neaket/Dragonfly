using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Indicle.Dragonfly.Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isCreatePolygon;
        private Polygon polygon;

        public MainWindow()
        {
            InitializeComponent();
            drawingCanvas.MouseLeftButtonUp += new MouseButtonEventHandler(drawingCanvas_MouseLeftButtonUp);
            
        }

        void drawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isCreatePolygon)
            {

                polygon.Points.Add(e.GetPosition(drawingCanvas));

                string output = "";

                foreach (var p in polygon.Points)
                {
                    output += String.Format("{0},{1} ", p.X, p.Y);
                }

                consoleOutput.Text = output;
            }
        }

        private void createPolygonBtn_Click(object sender, RoutedEventArgs e)
        {
            isCreatePolygon = true;
            if (polygon != null)
            {
                drawingCanvas.Children.Remove(polygon);
            }
            polygon = new Polygon();
            polygon.Stroke = Brushes.Black;
            polygon.StrokeThickness = 2;

            drawingCanvas.Children.Add(polygon);
        }
    }
}

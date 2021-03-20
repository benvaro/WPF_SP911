using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace _02_Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<int> Size { get; set; } = new List<int>();
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = Size;

            for (int i = 1; i <= 20; i++)
            {
                Size.Add(i);
            }

            ink.EditingMode = InkCanvasEditingMode.GestureOnly;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //(sender as Button).Background = Brushes.BlueViolet;
            Title = textBox.Text;
        }

        private void Link_Click(object sender, RoutedEventArgs e)
        {
            Process.Start((sender as Hyperlink).NavigateUri.ToString());
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;

            if (rb.IsChecked.HasValue && rb.IsChecked.Value)
            {
                //Title = rb.Content.ToString();
                textInfo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(rb.Content.ToString()));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;
                media.Source = new Uri(filePath);
            }
        }

        private void Play_click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }

        private void Volume_change(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Volume = (sender as Slider).Value;
        }

        private void Ink_Click(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Erase_Click(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void color_change(object sender, SelectionChangedEventArgs e)
        {
            ink.DefaultDrawingAttributes.Color = (Color)ColorConverter
                .ConvertFromString((cbColor.SelectedItem as StackPanel).Tag.ToString());
        }

        private void Save_click(object sender, RoutedEventArgs e)
        {
            ink.Strokes.Save(new FileStream($"{Guid.NewGuid().ToString()}.strokes", FileMode.Create, FileAccess.Write));
        }

        private void open_click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.ShowDialog();

            var stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.ReadWrite);
            ink.Strokes.Add(new StrokeCollection(stream));
        }

        private void Close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowPopup(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = !popup.IsOpen;
        }

        private void stop_click(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }
    }
}

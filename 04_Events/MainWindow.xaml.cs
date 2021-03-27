using System;
using System.Collections.Generic;
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

namespace _04_Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddInfo(sender, e);
        }

        private void AddInfo(object sender, MouseButtonEventArgs e)
        {
            var text = "Sender: " + sender.ToString();
            text += "\nSource: " + e.Source + "\n";
            text += "Strategy: " + e.RoutedEvent.RoutingStrategy + "\n";

            // e.Handled = true; // Bubbling виконуватись не буде, бо подія оброблена
            list.Items.Add(text);
        }

        private void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
        }

        private void Rectangle_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddInfo(sender, e);
         //   e.Handled = true;
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddInfo(sender, e);
        }

        private void stack_panelMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddInfo(sender, e);
        }

        private void radioBtn_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is RadioButton)
            {
                rect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString((e.Source as RadioButton).Content.ToString()));
            }
        }

        private void btn_event(object sender, RoutedEventArgs e)
        {
            Title = e.Source.ToString();
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            list.Items.Add(e.Key);
        }

        private void textBox_onKeyDown(object sender, KeyEventArgs e)
        {
            Title += e.Key;
            // e.Handled = true;
        }
    }
}

// MVVM model view viewmodel
// MVC model view controller
// mvp model view presenter
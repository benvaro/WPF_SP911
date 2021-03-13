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

namespace _01_Wpf_Intro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btn.Background = Brushes.Blue;

            var btn3 = new Button()
            {
                Content = "Custom btn",
                FontSize = 30
            };

            //  Canvas.SetBottom(btn3, 20);
            Grid.SetColumn(btn3, 1);
            Grid.SetRow(btn3, 0);
            panel.Children.Add(btn3);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _06_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> FruitsSimple { get; set; } = new List<string>();
        public ObservableCollection<string> Fruits { get; set; } = new ObservableCollection<string>();

        public CustomColor CustomColor { get; set; } = new CustomColor();

        public MainWindow()
        {
            InitializeComponent();
            var binding = new Binding
            {
                ElementName = "slider2", // 
                Path = new PropertyPath("Value"),
                Mode = BindingMode.TwoWay
            };

            lbl2.SetBinding(Label.FontSizeProperty, binding);

            // set foreground of the label via color entered into the textBox
            var binding2 = new Binding
            {
                ElementName = "txtColor",
                Path = new PropertyPath("Text"),
                Mode = BindingMode.TwoWay
            };

            lbl2.SetBinding(Label.ForegroundProperty, binding2);

            FruitsSimple.AddRange(new[] { "Apple", "Banana" });

            Fruits.Add("Apple");
            Fruits.Add("Cherry");
            box2.DataContext = Fruits;
            box1.DataContext = FruitsSimple;

            CustomColor.Blue = CustomColor.Green = CustomColor.Red = 100;
            this.DataContext = CustomColor;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            lbl1.FontSize = 20;
        }

        private void AddSimple(object sender, RoutedEventArgs e)
        {
            FruitsSimple.Add("Banana");
        }
        private void AddUpdatable(object sender, RoutedEventArgs e)
        {
            Fruits.Add("Banana");
        }
}
}

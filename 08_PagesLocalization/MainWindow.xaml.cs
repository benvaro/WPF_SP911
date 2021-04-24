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

namespace _08_PagesLocalization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadDictionary("ua");
        }

        private void changeLang(object sender, RoutedEventArgs e)
        {
            LoadDictionary((sender as MenuItem).Tag.ToString());
        }

        private void LoadDictionary(string name)
        {
            var dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("Localization/" + name + ".xaml", UriKind.Relative);

            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}

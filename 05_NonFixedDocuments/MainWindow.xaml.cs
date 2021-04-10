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

namespace _05_NonFixedDocuments
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var run = new Run(txtBox.Text);
            var bold = new Bold(run);

            var paragraph = new Paragraph();
            paragraph.Inlines.Add(bold);
            paragraph.FontSize = 40;

            var doc = new FlowDocument();
            doc.Blocks.Add(paragraph);

            reader.Document = doc;
        }
    }
}

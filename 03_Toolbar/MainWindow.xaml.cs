using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace _03_Toolbar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var span = new Span();
            // Inline: Bold, Underline, Italic, Hyperlink, Run
            var bold = new Bold();
            var run = new Run();
            run.Text = "dynamic text";
            var underline = new Underline(run);
            bold.Inlines.Add(underline);
            span.Inlines.Add(new Run("Hello"));
            span.Inlines.Add(bold);
            
            textInfo.Content = span;
        }

        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            info.Content = calendar.SelectedDate + " selected";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            testPanel.Visibility = testPanel.Visibility == Visibility.Collapsed
                ? testPanel.Visibility = Visibility.Visible
                : Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            scrollViewer.LineDown();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            scrollViewer.LineUp();
        }
    }
}

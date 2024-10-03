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
using WorkProject.Main.ProcedureReverser;
using WorkProject.Main.TagEditor;

namespace WorkProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeEncodingButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeEncoding changeEncoding = new ChangeEncoding();
            changeEncoding.Show();
        }

        private void ExtractHtmlText_Click(object sender, RoutedEventArgs e)
        {
            ExtractHtmlTextWindow extractHtmlTextWindow = new ExtractHtmlTextWindow();
            extractHtmlTextWindow.Show();
        }

        private void TextPresetsButton_Click(object sender, RoutedEventArgs e)
        {
            TextTemplatesWindow textPresets = new TextTemplatesWindow();
            textPresets.Show();
        }

        private void ButtonTagEditor_Click(object sender, RoutedEventArgs e)
        {
            WindowTagEditor windowTagEditor = new WindowTagEditor();
            windowTagEditor.Show();
        }

        private void ProcedureReverserButton_Click(object sender, RoutedEventArgs e)
        {
            ProcedureReverserWindow procedureReverserWindow = new ProcedureReverserWindow();
            procedureReverserWindow.Show();
        }
    }
}

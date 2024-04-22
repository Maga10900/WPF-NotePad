using Microsoft.Win32;

using System.IO;
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

using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        string yoxlanis { get; set; } = null;
        string fileName {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 9; i < 101; i++)
            {
                CMb.Items.Add(i);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //File dialog button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var open = new OpenFileDialog();
            open.Filter = "File text | *.txt";
            open.DefaultExt = ".txt";
            bool? op = open.ShowDialog();
            if (op == true)
            {
                txtBox.Text = open.FileName;
            }
            FlowDocument myFlowDoc = new FlowDocument();
            RichTextBox.Document = myFlowDoc;


            TextRange textRange = new TextRange(
                RichTextBox.Document.ContentStart,
                RichTextBox.Document.ContentEnd
            );
            textRange.Text = File.ReadAllText(open.FileName);
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var a = MessageBox.Show("Save etmek istedyiniz File movucdur?", "Save File", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (a == MessageBoxResult.Yes)
            {
                SaveFileDialog save = new();
                save.Filter = "File text | *.txt";
                save.DefaultExt = ".txt";
                var content = new TextRange(
                RichTextBox.Document.ContentStart,
                RichTextBox.Document.ContentEnd
            ).Text;
                bool? op = save.ShowDialog();
                if (op == true)
                {
                    File.WriteAllText(save.FileName, content);

                }
            }
            else if (a == MessageBoxResult.No)
            {
                var content = new TextRange(
                RichTextBox.Document.ContentStart,
                RichTextBox.Document.ContentEnd
            ).Text;
                File.WriteAllText("NotePad.txt", content);
                MessageBox.Show("Sizin ucun exenin yaninda NotePad.txt adli file yaradildi ve data ora yazildi.");
            }

        }

        //avto save
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        //paste
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RichTextBox.Paste();
        }


        //cut
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RichTextBox.Cut();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            RichTextBox.Copy();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            RichTextBox.SelectAll();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RichTextBox.FontSize = Convert.ToDouble(CMb.SelectedItem);
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string richText = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Text;
            if (CH_Box.IsChecked == true)
            {
                if (yoxlanis == null)
                {
                    var a = MessageBox.Show("Save etmek istedyiniz File movucdur?", "Save File", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (a == MessageBoxResult.Yes)
                    {
                        SaveFileDialog save = new();
                        save.Filter = "File text | *.txt";
                        save.DefaultExt = ".txt";
                        var content = new TextRange(
                        RichTextBox.Document.ContentStart,
                        RichTextBox.Document.ContentEnd
                    ).Text;
                        bool? op = save.ShowDialog();
                        if (op == true)
                        {
                            File.WriteAllText(save.FileName, content);
                            fileName = save.FileName;
                            yoxlanis = "a";
                        }
                    }
                    else if (a == MessageBoxResult.No)
                    {
                        var content = new TextRange(
                        RichTextBox.Document.ContentStart,
                        RichTextBox.Document.ContentEnd
                    ).Text;
                        File.WriteAllText("NotePad.txt", content);
                        fileName = "NotePad.txt";
                        yoxlanis = "b";
                        MessageBox.Show("Sizin ucun exenin yaninda NotePad.txt adli file yaradildi ve data ora yazildi.");
                    }
                }
                if(yoxlanis == "a")
                {
                    File.WriteAllText(fileName, richText);
                }
                else if(yoxlanis == "b")
                {
                    File.WriteAllText(fileName, richText);
                }

            }
        }
    }
}
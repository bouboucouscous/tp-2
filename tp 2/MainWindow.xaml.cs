using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace tp_2
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
   
            if (openFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(openFolderDialog.SelectedPath);
                textbox.Text = openFolderDialog.SelectedPath;
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    if (file.Extension == ".jpg")
                    {
                        listbox.Items.Add(file.FullName);
                    }
                }
            }
        }

        private void listbox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            lb1.Content = listbox.SelectedItem.ToString();
        }
    }
}
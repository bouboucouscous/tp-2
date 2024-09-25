using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace tp_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Photo 
            ph;


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
            ph = new Photo(listbox.SelectedItem.ToString());

            lb2.Content = ph.Metadata.DateTaken;
            lb3.Content = ph.Metadata.Titre;
            lb4.Content = ph.Metadata.Camera;
            lb5.Content = ph.Metadata.Application;
            lb6.Content = ph.Metadata.IsoSpeed;
            lb7.Content = ph.Metadata.IsoOpenValue;
            lb8.Content = ph.Metadata.IsoFocalDist;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Diaporama diaporama = new Diaporama();
            foreach (var item in listbox.Items)
            {
                diaporama.sDiapo.Add(item.ToString());
            }
            diaporama.ShowDialog();
        }
    }
}
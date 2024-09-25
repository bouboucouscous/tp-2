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
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace tp_2
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Diaporama : Window
    {
        int indice = 0;

        public Diaporama()
        {
            InitializeComponent();
        }

        public List<String> sDiapo = new List<String>();

        private void Window_Activated_1(object sender, EventArgs e)
        {
            ImageSourceConverter s = new ImageSourceConverter();
            Image1.Source = (ImageSource)s.ConvertFromString(sDiapo[0]);
        }
        private void VisibleToInvisible_Completed(object sender, EventArgs e)
        {
            ImageSourceConverter s = new ImageSourceConverter();
            
            try
            {
                indice += 1;
                Image1.Source = (ImageSource)s.ConvertFromString(sDiapo[indice]);
            }
            catch 
            {
                indice = 0;
            }
            
            Storyboard sb = (Storyboard)this.FindResource("InvisibleToVisible");
            sb.Begin();
        }

        private void InvisibleToVisible_Completed(object sender, EventArgs e)
        {
            ImageSourceConverter s = new ImageSourceConverter();
            
            indice += 1;
            if (indice >= sDiapo.Count)
            {                
                Image1.Source = (ImageSource)s.ConvertFromString(sDiapo[indice]);
            }
            else
            {
                indice = 0;
            }

            Storyboard sb = (Storyboard)this.FindResource("VisibleToInvisible");
            sb.Begin();
        }
    }
}

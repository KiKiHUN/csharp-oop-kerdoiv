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
using WpfAnimatedGif;

namespace beadando
{
    /// <summary>
    /// Interaction logic for loadingWindow.xaml
    /// </summary>
    public partial class loadingWindow : Window
    {
        public loadingWindow()
        {
            InitializeComponent();
            loadgif();
        }
        private void loadgif()
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"pack://application:,,,/kepek/cat-what.gif", UriKind.Absolute);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(kep, image);
        }
    }
}

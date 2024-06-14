using beadando.Osztalyok;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml;
using System.Xml.Linq;
using WpfAnimatedGif;

namespace beadando
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            loadgif();
            Thread t = new Thread(readPermission);
            t.Start();
        }
        private void loadgif()
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"pack://application:,,,/kepek/cat-what.gif", UriKind.Absolute);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(kep, image);
        }
        private void readPermission()
        {
            string path = System.IO.Directory.GetCurrentDirectory();

            if (System.IO.File.Exists(path+"\\config.xml"))
            {
                try
                {
                    var xml = XDocument.Load(@path + "\\config.xml");
                    string jog = ReadPermission(xml);

                    //Trace.WriteLine(jog.First());
                    
                    if (jog == "admin")
                    {
                        Thread.Sleep(1000);
                        Application.Current.Dispatcher.Invoke((Action)delegate {
                            AdminMain a = new AdminMain(jog);
                            a.Show();
                            this.Close();
                        });
                           
                    }
                    else if (jog == "nemadmin")
                    {
                        Thread.Sleep(1000);
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                UserMain u = new UserMain(jog+";" + ReadData(xml));
                                u.Show();
                                this.Close();
                            });
                    }
                    else
                    {
                        Thread.Sleep(3000);
                        MessageBox.Show("Nincs jól kitöltve az xml.");
                        Environment.Exit((int)hibakodok.config_nincskitoltva);
                    }
                   
                }
                catch (XmlException)
                {
                    newxml(path);
                    Thread.Sleep(3000);
                    MessageBox.Show("hibás vagy hiányos config.xml fájl");
                    Environment.Exit((int)hibakodok.config_hibashianyos);
                }
            }
            else 
            {
                newxml(path);
                Thread.Sleep(3000);
                MessageBox.Show("nincs config.xml fájl");
                Environment.Exit((int)hibakodok.config_nincs);
            }
        }
        private void newxml(string path)
        {
            XMLfunkciok xMLfunkciok= new XMLfunkciok();
            xMLfunkciok.WriteTemlplateXML(path);
        }
        private string ReadData(XDocument xml)
        {

            IEnumerable<string> adatok= from fajl in xml.Root.Descendants("SzemelyiAdatok")
                    select
                    (string)fajl.Element("email") + ";" +
                    (string)fajl.Element("nem") + ";" +
                    (string)fajl.Element("kor") + ";" +
                    (string)fajl.Element("vegzettseg");

            if (adatok.Count() > 0)
            {
                return adatok.First();
            }
            else
            {
                throw new XmlException();
            }
       
        }
        private string ReadPermission(XDocument xml)
        {
            IEnumerable<string> jog = from fajl in xml.Root.Descendants("BejelentkezesTipus")
                         select(string)fajl.Element("tipus");

            if (jog.Count() > 0)
            {
                return jog.First();
            }
            else
            {
             throw new XmlException();
            }
        }
    }
}

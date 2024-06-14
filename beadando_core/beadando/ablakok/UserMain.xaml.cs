using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using beadando.Osztalyok;
using beadando.Osztalyok.DBrelated;
using Org.BouncyCastle.Crypto.Utilities;
using Application = System.Windows.Application;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;

namespace beadando
{
    /// <summary>
    /// Interaction logic for UserMain.xaml
    /// </summary>
    public partial class UserMain : Window
    {
      
        Adatok adatok=new Adatok();
        DBFunkciok dBFunkciok= new DBFunkciok();
        ToltoFunkcio tolt = new ToltoFunkcio();
        List<Kerdes> kerdeslista = null;
        int index = 0;
        List<Tuple<int, Tuple<int,int>>> kerdes_valasz = new List<Tuple<int, Tuple<int,int>>>();//kerdesID, valaszID, valaszComboIndex
        
        private bool selectrionTrigger = false;


        public UserMain(string beadat)
        {
            InitializeComponent();
            adatok.setMinden(dBFunkciok.Stringsplitter(beadat,';')) ;
            string alma=adatok.getRole();
            Thread t = new Thread(DBStart);
            t.Start();
           
        }



        private void DBStart()
        {

            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                tolt.ShowLoading();
            });
            switch (dBFunkciok.FindDB())
            {
                case hibakodok.DB_nincs_kapcsolat:
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        tolt.ShowLoading(false);
                    });
                    MessageBox.Show("nincs DB kapcsolat");
                    Environment.Exit(1);
                    break;

                case hibakodok.DB_siker:
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        tolt.ShowLoading(false);
                    });
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        kutataslista.Visibility = Visibility.Visible;
                        List_Update_All();
                    });
                    break;
            }
            
        }
        private void List_Update_All()
        {
            kutataslista.Visibility = Visibility.Visible;
            kutataslista.Items.Clear();
            foreach (var kutatas in dBFunkciok.getStartedKutatas())
            {
               
                    Grid g = new Grid();
                    ColumnDefinition colDef1 = new ColumnDefinition();
                    ColumnDefinition colDef2 = new ColumnDefinition();
                    ColumnDefinition colDef3 = new ColumnDefinition();
                    g.ColumnDefinitions.Add(colDef1);
                    g.ColumnDefinitions.Add(colDef2);
                    g.ColumnDefinitions.Add(colDef3);

                    // Define the Rows
                    RowDefinition rowDef1 = new RowDefinition();
                    RowDefinition rowDef2 = new RowDefinition();
                    RowDefinition rowDef3 = new RowDefinition();
                    RowDefinition rowDef4 = new RowDefinition();
                    g.RowDefinitions.Add(rowDef1);
                    g.RowDefinitions.Add(rowDef2);
                    g.RowDefinitions.Add(rowDef3);
                    g.RowDefinitions.Add(rowDef4);

                    TextBlock txt1 = new TextBlock();
                    if (kutatas.aktivalva)
                    {
                        if (dBFunkciok.checkIfKitoltottKutatasByEmailByID(adatok.getEmail(), kutatas.ID) == hibakodok.db_nincs)
                        {
                            Button btn1 = new Button();
                            btn1.Content = "Kutatás kitoltése";
                            btn1.FontSize = 12;
                            btn1.FontWeight = FontWeights.Bold;
                            btn1.Margin = new Thickness(0, 5, 5, 5);
                            btn1.Click += (sender, EventArgs) => { Kutatas_kitoltese(sender, EventArgs, kutatas.ID); };
                            Grid.SetRow(btn1, 3);
                            Grid.SetColumn(btn1, 0);
                            g.Children.Add(btn1);
                        }else
                        {
                            TextBlock tb=new TextBlock();
                            tb.FontSize = 12;
                            tb.Text = "Már kitöltötte";
                            tb.Foreground=Brushes.Red;
                            tb.Background=Brushes.AliceBlue;
                            Grid.SetRow(tb, 3);
                            Grid.SetColumn(tb, 0);
                            g.Children.Add(tb);
                        }    
                        txt1.Foreground = Brushes.Green;
                      
                    }
                    else
                    {
                        txt1.Foreground = Brushes.Red;
                    }
                    txt1.Text = kutatas.nev;
                    txt1.FontSize = 20;
                    txt1.Margin = new Thickness(0, 0, 0, 5);
                    txt1.FontWeight = FontWeights.Bold;
                    ScrollViewer scroll = new ScrollViewer();
                    scroll.Width = kutataslista.Width;
                    scroll.Margin = new Thickness(0, 0, 10, 0);
                    scroll.Content = txt1;
                    scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                    Grid.SetColumnSpan(scroll, 3);
                    Grid.SetRow(scroll, 0);


                    TextBlock txkert = new TextBlock();
                    txkert.Text = "Elvárt kitoltések: " + kutatas.elvartKitoltes.ToString();
                    txkert.Margin = new Thickness(10, 0, 0, 0);
                    Grid.SetRow(txkert, 1);
                    Grid.SetColumn(txkert, 0);

                    TextBlock txkapott = new TextBlock();
                    txkapott.Text = "Kapott kitoltések: " + kutatas.kapottKitoltes.ToString();
                    txkapott.Margin = new Thickness(10, 0, 0, 0);
                    Grid.SetRow(txkapott, 1);
                    Grid.SetColumn(txkapott, 1);

                    TextBlock txKezdet = new TextBlock();
                    txKezdet.Text = "kezdet: " + kutatas.kezdet.ToString();
                    Grid.SetRow(txKezdet, 2);
                    Grid.SetColumn(txKezdet, 0);

                    TextBlock txVeg = new TextBlock();
                    txVeg.Text = "vég: " + kutatas.veg.ToString();
                    txVeg.Margin = new Thickness(10, 0, 0, 0);
                    Grid.SetRow(txVeg, 2);
                    Grid.SetColumn(txVeg, 1);



               
                    g.Children.Add(scroll);

                    g.Children.Add(txKezdet);
                    g.Children.Add(txVeg);

                    g.Children.Add(txkert);
                    g.Children.Add(txkapott);


                    kutataslista.Items.Add(g);
              
            }
        }
        public void Kutatas_kitoltese(object sender, RoutedEventArgs e, int kutatasID)
        {
            kerdeslista = dBFunkciok.getAllKerdesByID(kutatasID);
            Bekuld.Tag= kutatasID;

            foreach (var kerdes in kerdeslista)
            {
                kerdes_valasz.Add(Tuple.Create(kerdes.ID, Tuple.Create(-1,-1)));
            }
            
            if (kerdeslista != null&&kerdeslista.Count>0)
            {
                kutataslista.Visibility = Visibility.Hidden;
                CANVAS_Kitolto.Visibility= Visibility.Visible;
                DisplayCurrentKerdes();

            }
           
        }
        private void KivannakToltve()
        {
            for (int i = 0; i < kerdes_valasz.Count; i++)
            {
                if (kerdes_valasz[i].Item2.Item2 ==-1)
                {
                    Bekuld.Visibility = Visibility.Hidden;
                    break;
                }
                if (i>= kerdes_valasz[i].Item2.Item2 - 1)
                {
                   Bekuld.Visibility= Visibility.Visible;
                }
            }
        }
        private void DisplayCurrentKerdes()
        {
           
            selectrionTrigger = true;
            box_valasz.Items.Clear();
            TX_Kerdes.Content = kerdeslista[index].szoveg;
            List<Valasz> valaszok= dBFunkciok.getAllValaszByID(kerdeslista[index].ID);
            pageCounter.Content = index + 1 + " / " + kerdes_valasz.Count;
            foreach (var item in valaszok)
            {
                box_valasz.Items.Add(item.szoveg);
            }
            if (index==0)
            {
                Next.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Hidden;
            }
            else if (index==kerdes_valasz.Count -1)
            {
                Next.Visibility = Visibility.Hidden;
                Back.Visibility = Visibility.Visible;
            }
            else
            {
                Next.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
            }
            if (index + 1 > kerdeslista.Count - 1)
            {
                Next.Visibility = Visibility.Hidden;
            }
            if (kerdes_valasz[index].Item2.Item2 != -1)
            {
                box_valasz.SelectedIndex = kerdes_valasz[index].Item2.Item2;
            }
            selectrionTrigger= false;
            KivannakToltve();
        }
        private void nextKerdes()
        {
           
                index++;
           
            DisplayCurrentKerdes();
           
           
           
        }
        private void prevKerdes()
        {
            index--;
            DisplayCurrentKerdes();
           
           
        }

       

        private void NextClick(object sender, RoutedEventArgs e)
        {
            nextKerdes();
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            prevKerdes();
        }
        private void kuldClick(object sender, RoutedEventArgs e)
        {
          
           dBFunkciok.AddKitoltes(adatok.getEmail(), (int)((Button)sender).Tag, adatok.getNem(), adatok.getVegzettseg(), adatok.getKor(), kerdes_valasz);
           
           CANVAS_Kitolto.Visibility= Visibility.Hidden;
            List_Update_All();
        }
        private void box_valasz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!selectrionTrigger)
            {

                kerdes_valasz[index] = Tuple.Create(kerdes_valasz[index].Item1, Tuple.Create( dBFunkciok.getAllValaszByID(kerdeslista[index].ID)[box_valasz.SelectedIndex].ID, box_valasz.SelectedIndex));
                KivannakToltve();
            }
        }
        private void Megsem_Click(object sender, RoutedEventArgs e)
        {
            kutataslista.Visibility = Visibility.Visible;
            CANVAS_Kitolto.Visibility = Visibility.Hidden;
        }
    }
   
}

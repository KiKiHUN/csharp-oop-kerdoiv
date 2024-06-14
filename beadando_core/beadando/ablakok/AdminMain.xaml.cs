using beadando.ablakok;
using beadando.Osztalyok;
using beadando.Osztalyok.DBrelated;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Controls.Button;

namespace beadando
{
    /// <summary>
    /// Interaction logic for AdminMain.xaml
    /// </summary>
    /// 
    public partial class AdminMain 
    {
        Adatok adatok = new Adatok();
        DBFunkciok dBFunkciok= new DBFunkciok();
        ToltoFunkcio tolt = new ToltoFunkcio();
        int szurestipus = 0;//0=all, 1=futo, 2=jovo, 3=volt
        public AdminMain(string beadat)
        {
            InitializeComponent();
            string[] placeholder = { beadat, "_", "_", "-1", "_" };
            adatok.setMinden(placeholder);
            string alma = adatok.getRole();
            Thread t = new Thread(DBStart);
            t.Start();
            for (int i = 0; i < 24; i++)
            {
                Kezdet_ora.Items.Add(i.ToString());
                veg_ora.Items.Add(i.ToString());
            }
            for (int i = 0; i < 60; i++)
            {
                Kezdet_perc.Items.Add(i.ToString());
                veg_perc.Items.Add(i.ToString());
            }
        }

        //szimpla funkciók//
        private void DBStart()
        {

            tolthivas();

            switch (dBFunkciok.FinOrCreateDB())
            {
                case hibakodok.DB_nincs_kapcsolat:
                    tolthivas(false);
                    MessageBox.Show("nincs DB kapcsolat");
                    Environment.Exit(1);
                    break;

                case hibakodok.DB_uj_letrehozva:
                    tolthivas(false);
                    MessageBox.Show("DB létrehozva");
                    break;
                case hibakodok.DB_siker:
                    tolthivas(false);
                    break;
            }
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                Ablak_admin.IsEnabled = true;
                sidemenu_unfolded.Visibility= Visibility.Visible;
               
            });
        }
        

        private void list_update(List<Kutatas> lista=null)
        {
            if (lista == null)
            {
                MessageBox.Show("Nincs DB kapcsolat");
            }
            else
            {
                listbox1.Items.Clear();
                listbox1.Visibility = Visibility.Visible;
                InfoPNG.Visibility = Visibility.Visible;
                RefreshPNG.Visibility = Visibility.Visible;
                foreach (var kutatas in lista)
                {
                    Grid g = new Grid();
                    g.Width = listbox1.Width;
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
                    if (kutatas.veg >= DateTime.Now)
                    {
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
                    scroll.Width = listbox1.Width;
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

                    if (kutatas.kapottKitoltes>0)
                    {
                        Button eredmenyek = new Button();
                        eredmenyek.Content = "Eredmények";
                        eredmenyek.Margin = new Thickness(10, 0, 0, 0);
                        eredmenyek.Click += (sender, EventArgs) => { EredmenyShow(sender, EventArgs, kutatas.ID); };
                        Grid.SetRow(eredmenyek, 1);
                        Grid.SetColumn(eredmenyek, 2);
                        g.Children.Add(eredmenyek);
                    }
               


                    TextBlock txKezdet = new TextBlock();
                    txKezdet.Text = "kezdet: " + kutatas.kezdet.ToString();
                    Grid.SetRow(txKezdet, 2);
                    Grid.SetColumn(txKezdet, 0);

                    TextBlock txVeg = new TextBlock();
                    txVeg.Text = "vég: " + kutatas.veg.ToString();
                    txVeg.Margin = new Thickness(10, 0, 0, 0);
                    Grid.SetRow(txVeg, 2);
                    Grid.SetColumn(txVeg, 1);



                    if (kutatas.kezdet >= DateTime.Now || (kutatas.veg <= DateTime.Now && kutatas.kapottKitoltes < kutatas.elvartKitoltes))
                    {
                        Button btn1 = new Button();
                        btn1.Content = "Kutatás szerkesztése";
                        btn1.FontSize = 12;
                        btn1.FontWeight = FontWeights.Bold;
                        btn1.Margin = new Thickness(0, 5, 5, 5);
                        btn1.Click += (sender, EventArgs) => { Kutatas_Szerkesztes_Click(sender, EventArgs, kutatas.ID, kutatas.nev, kutatas.elvartKitoltes, kutatas.kezdet, kutatas.veg, kutatas.aktivalva); };
                        Grid.SetRow(btn1, 3);
                        Grid.SetColumn(btn1, 0);
                        g.Children.Add(btn1);
                    }


                    if (kutatas.kezdet >= DateTime.Now)
                    {
                        Button btn2 = new Button();
                        btn2.Content = "Kérdések szerkesztése";
                        btn2.FontSize = 12;
                        btn2.FontWeight = FontWeights.Bold;
                        btn2.Margin = new Thickness(0, 5, 5, 5);
                        btn2.Click += (sender, EventArgs) => { Kerdes_Szerkesztes_Click(sender, EventArgs, kutatas.ID); };
                        Grid.SetRow(btn2, 3);
                        Grid.SetColumn(btn2, 1);
                        g.Children.Add(btn2);
                    }


                    Button btn3 = new Button();
                    btn3.Content = "Kutatás törlése";
                    btn3.FontSize = 12;
                    btn3.FontWeight = FontWeights.Bold;
                    btn3.Margin = new Thickness(0, 5, 5, 5);
                    btn3.Click += (sender, EventArgs) => { Kutatas_Torles_Click(sender, EventArgs, kutatas.ID); };
                    Grid.SetRow(btn3, 3);
                    Grid.SetColumn(btn3, 2);
                    g.Children.Add(scroll);

                    g.Children.Add(txKezdet);
                    g.Children.Add(txVeg);

                    g.Children.Add(txkert);
                    g.Children.Add(txkapott);
              

                    g.Children.Add(btn3);
                    listbox1.Items.Add(g);
                }
            }
        }
        private void List_Update_All()
        {
            szurestipus = 0;
            tolthivas();
            List<Kutatas> lista = dBFunkciok.getAllKutatas();
            tolthivas(false);
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                list_update(lista);
            });
            lista = null;
        }
        private void list_Update_Futo()
        {
            szurestipus = 1;
            tolthivas();
            List<Kutatas> lista = dBFunkciok.getStartedKutatas();
            tolthivas(false);
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                list_update(lista);
            });
            lista = null;
        }
        private void list_Update_Jovo()
        {
            szurestipus = 2;
            tolthivas();
            List<Kutatas> lista = dBFunkciok.getNotStartedKutatas();
            tolthivas(false);
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                list_update(lista);
            });
            lista = null;
        }
        private void list_Update_Volt()
        {
            szurestipus = 3;
            tolthivas();
            List<Kutatas> lista = dBFunkciok.getLejartKutatas();
            tolthivas(false);
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                list_update(lista);
            });
            lista = null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(list_Update_Jovo);
            t.Start();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Thread t = new Thread(list_Update_Futo);
            t.Start();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(list_Update_Volt);
            t.Start();
        }
        private void ListAll_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(List_Update_All);
            t.Start();
        }
        private void ListRefresh(object sender, MouseButtonEventArgs e)
        {
            refreshByType();
        }
        private void refreshByType()
        {
            Thread t = null;
            switch (szurestipus)
            {
                case 0:
                    t = new Thread(List_Update_All);
                    break;
                case 1:
                    t = new Thread(list_Update_Futo);
                    break;
                case 2:
                    t = new Thread(list_Update_Jovo);
                    break;
                case 3:
                    t = new Thread(list_Update_Volt);
                    break;
            }
            if (t != null)
            {
                t.Start();
            }
        }
        //UI click funkciók//

        void tolthivas(bool a = true)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                tolt.ShowLoading(a);
            });
        }
        private void UnfoldedClicked(object sender, MouseButtonEventArgs e)
        {
            sidemenu_unfolded.Visibility = Visibility.Collapsed;
            sidemenu_folded.Visibility = Visibility.Visible;
        }
        private void FoldedClicked(object sender, MouseButtonEventArgs e)
        {
            sidemenu_folded.Visibility = Visibility.Collapsed;
            sidemenu_unfolded.Visibility=Visibility.Visible;
        }
       
        private void Kerdes_Szerkesztes_Click(object sender, RoutedEventArgs e,int ID)
        {
            kerdesSzerkeszto kerdesSzerkeszto = new kerdesSzerkeszto(ID);
            kerdesSzerkeszto.ShowDialog();
        }
        private void EredmenyShow(object sender, RoutedEventArgs e, int KutatasID)
        {
            eredmenyWindow eredmeny = new eredmenyWindow(KutatasID);
            eredmeny.Show();
        }
        private void InfoPNG_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Piros név: lejárt kutatás\n Zöld név: nincs elkezdve\n\n Szerkesztés nem látható:\n Vagy elkezdődött a kutatás, vagy lejárt és meglett a kelő kitöltésszám");
        }

        //torles
        private void Kutatas_Torles_Click(object sender, RoutedEventArgs e, int ID)
        {
            switch (dBFunkciok.RemoveKutatas(ID))
            {
                case hibakodok.db_sikertelen:
                    MessageBox.Show("Sikertelen törlés");
                    break;

                case hibakodok.DB_nincs_ID:
                    MessageBox.Show("Nincs ilyen az adatbázisban");
                    break;
            }
            refreshByType();
        }


        //kutats edit
        private void Kutatas_Szerkesztes_Click(object sender, RoutedEventArgs e, int ID, string nev, int elvartdarab,DateTime kezdet,DateTime veg, bool aktivalva)
        {
            canvas_Kutatas_edit_uj.Visibility = Visibility.Visible;
            TB_nev.Text = nev;
            veg_ora.SelectedValue = veg.Hour.ToString();
            veg_perc.SelectedValue = veg.Minute.ToString();
            veg_datum.SelectedDate = veg.Date;
            
            if (kezdet >= DateTime.Now)
            {
                Kezdet_ora.SelectedValue = kezdet.Hour.ToString();
                Kezdet_perc.SelectedValue = kezdet.Minute.ToString();
                Kezdet_datum.SelectedDate = kezdet.Date;
                TX_elvart.Text = elvartdarab.ToString();
                this.aktivalva.IsChecked = aktivalva;
                WindowMode.Tag = "edit";
            }
            else
            {
                kezdetLB.Visibility = Visibility.Collapsed;
                elvartKitoltesekLB.Visibility= Visibility.Collapsed;
                this.aktivalva.IsChecked = true;
                this.aktivalva.IsEnabled= false;
                TB_nev.IsEnabled= false;
                TX_elvart.Visibility= Visibility.Collapsed;
                slider_elvart.Visibility = Visibility.Collapsed;
                DateTimePicker1.Visibility = Visibility.Collapsed;
                WindowMode.Tag = "editEnd";

            }
           
            btn_edit_save.Tag = ID;
        }
        private void slider_elvart_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider_elvart.IsFocused)
            {
                TX_elvart.Text = slider_elvart.Value.ToString();
            }
        }
        private void TX_elvart_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TX_elvart.IsFocused&&TX_elvart.Text!=null)
            {
                try
                {
                   
                    string a = TX_elvart.Text;
                    int i = int.Parse(TX_elvart.Text);
                    if (1 > i || i > 1000)
                    {
                        TX_elvart.Text = 1 + "";
                        i = 1;
                    }
                    slider_elvart.Value = i;
                }
                catch
                {
                    TX_elvart.Text = 1 + "";
                    slider_elvart.Value = 1;
                }
            }
            
        }
        private void Kutatas_edit_Megsem_click(object sender, RoutedEventArgs e)
        {
            canvas_Kutatas_edit_uj.Visibility = Visibility.Hidden;

        }
        private void Kutatas_edit_uj_mentes(object sender, RoutedEventArgs e)
        {
            
            switch (WindowMode.Tag)
            {
                case "editEnd":
                    string time = veg_ora.Text + ":" + veg_perc.Text;
                    DateTime dateTime = new DateTime();
                    dateTime = veg_datum.SelectedDate.Value;
                    DateTime newDateTime = dateTime.Add(TimeSpan.Parse(time));

                    if (hibakodok.DB_siker == dBFunkciok.editKutatasEnd((int)((Button)sender).Tag, newDateTime))
                    {
                        canvas_Kutatas_edit_uj.Visibility = Visibility.Hidden;
                        MessageBox.Show("Sikeres mentés");
                        refreshByType();

                    }
                    else
                    {
                        MessageBox.Show("Sikertelen mentés");
                    }
                    break;
                case "edit":
                    string time2 = veg_ora.Text + ":" + veg_perc.Text;
                    DateTime dateTime2 = new DateTime();
                    dateTime2 = veg_datum.SelectedDate.Value;
                    DateTime newDateTime2 = dateTime2.Add(TimeSpan.Parse(time2));

                    string time3 = Kezdet_ora.Text + ":" + Kezdet_perc.Text;
                    DateTime dateTime3 = new DateTime();
                    dateTime3 = Kezdet_datum.SelectedDate.Value;
                    DateTime newDateTime3 = dateTime3.Add(TimeSpan.Parse(time3));
                    bool engedve = (bool)aktivalva.IsChecked;
                    if (hibakodok.DB_siker == dBFunkciok.editKutatas((int)((Button)sender).Tag,TB_nev.Text,int.Parse(TX_elvart.Text),newDateTime3,newDateTime2,engedve))
                    {
                        canvas_Kutatas_edit_uj.Visibility = Visibility.Hidden;
                        MessageBox.Show("Sikeres mentés");
                        refreshByType();

                    }
                    else
                    {
                        MessageBox.Show("Sikertelen mentés");
                    }
                    break;
                case "Uj":
                    string kezdetido = Kezdet_ora.Text + ":" + Kezdet_perc.Text;
                    DateTime kezdet = Kezdet_datum.SelectedDate.Value;
                    DateTime teljesKezdet = kezdet.Add(TimeSpan.Parse(kezdetido));

                    string vegido = veg_ora.Text + ":" + veg_perc.Text;
                    DateTime veg = veg_datum.SelectedDate.Value;
                    DateTime teljesVeg = veg.Add(TimeSpan.Parse(vegido));

                    if (teljesKezdet>=teljesVeg)
                    {
                        MessageBox.Show("Hibás dátum");
                    }
                    else
                    {
                        bool engedve2 = (bool)aktivalva.IsChecked;

                        if (hibakodok.DB_siker == dBFunkciok.addKutatas(TB_nev.Text, int.Parse(TX_elvart.Text), teljesKezdet, teljesVeg, engedve2))
                        {
                            canvas_Kutatas_edit_uj.Visibility = Visibility.Hidden;
                            MessageBox.Show("Sikeres mentés");
                            refreshByType();
                            int kerdesID = dBFunkciok.getLastKutatasID();   
                            if (kerdesID == -1)
                            {
                                MessageBox.Show("Hibás kutatás ID");
                            }
                            else
                            {
                                Kerdes_Szerkesztes_Click(sender, e, kerdesID);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sikertelen mentés");
                        }
                    }
                    break;
            }
            
        }

      
        private void Ablak_admin_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            buttonList.Height = Ablak_admin.ActualHeight-40;
            sidemenu.Height = Ablak_admin.ActualHeight;
            sidemenu_unfolded.Height = Ablak_admin.ActualHeight;
            hatter.Height = Ablak_admin.ActualHeight;
            sidemenu_line.Height = Ablak_admin.ActualHeight;
        }

        

        private void Uj_Kutatas_click(object sender, RoutedEventArgs e)
        {
            TX_elvart.Text ="1";
            sidemenu_unfolded.Visibility= Visibility.Hidden;
            sidemenu_folded.Visibility= Visibility.Visible;
            canvas_Kutatas_edit_uj.Visibility = Visibility.Visible;
            Kezdet_ora.SelectedValue = DateTime.Now.AddHours(1).Hour.ToString();
            Kezdet_perc.SelectedValue = DateTime.Now.Minute.ToString(); 
            veg_ora.SelectedValue=DateTime.Now.AddHours(2).Hour.ToString();
            veg_perc.SelectedValue= DateTime.Now.Minute.ToString();
            Kezdet_datum.SelectedDate = DateTime.Now.Date;
            veg_datum.SelectedDate = DateTime.Now.Date;
            WindowMode.Tag = "Uj";
        }

       
    }
}

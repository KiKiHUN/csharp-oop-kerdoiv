using beadando.Osztalyok.DBrelated;
using beadando.Osztalyok;
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

namespace beadando.ablakok
{
    /// <summary>
    /// Interaction logic for valaszSzerkeszto.xaml
    /// </summary>
    public partial class valaszSzerkeszto : Window
    {
        DBFunkciok dB = new DBFunkciok();
        ToltoFunkcio tolt = new ToltoFunkcio();
        private int kerdesID;
        public valaszSzerkeszto(int id)
        {
            InitializeComponent();
            kerdesID = id;
            listafeltolt();
        }
    
      
        
        private void listafeltolt()
        {
            ValaszList.Items.Clear();

            List<Valasz> valszok = dB.getAllValaszByID(kerdesID);
            if (valszok == null)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    tolt.ShowLoading(false);
                });
                MessageBox.Show("Nincs DB kapcsolat");
                this.Close();
            }

            foreach (var valasz in valszok)
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
                txt1.Text = valasz.szoveg;
                txt1.FontSize = 20;
                txt1.Margin = new Thickness(0, 0, 0, 5);
                txt1.FontWeight = FontWeights.Bold;
                ScrollViewer scroll = new ScrollViewer();
                scroll.Width = ValaszList.Width;
                scroll.Margin = new Thickness(0, 0, 10, 0);
                scroll.Content = txt1;
                scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                Grid.SetColumnSpan(scroll, 3);
                Grid.SetRow(scroll, 0);
                g.Children.Add(scroll);

                

                Button btn2 = new Button();
                btn2.Content = "Váasz szerkesztése";
                btn2.FontSize = 12;
                btn2.FontWeight = FontWeights.Bold;
                btn2.Margin = new Thickness(0, 5, 5, 5);
                btn2.Click += (sender, EventArgs) => { valasz_szerkesztese(sender, EventArgs, valasz.ID, valasz.szoveg); };
                Grid.SetRow(btn2, 3);
                Grid.SetColumn(btn2, 1);
                g.Children.Add(btn2);


              


                Button btn3 = new Button();
                btn3.Content = "Váasz törlése";
                btn3.FontSize = 12;
                btn3.FontWeight = FontWeights.Bold;
                btn3.Margin = new Thickness(0, 5, 5, 5);
                btn3.Click += (sender, EventArgs) => { valasz_torlese(sender, EventArgs, valasz.ID); };
                Grid.SetRow(btn3, 3);
                Grid.SetColumn(btn3, 2);

                g.Children.Add(btn3);


                ValaszList.Items.Add(g);

            }

        }
        private void BTN_megsem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void valasz_szerkesztese(object sender, RoutedEventArgs e, int id, string szoveg)
        {
            btn_edit_save.Tag = id;
            windowMode.Tag = "edit";
            TX_kerdes.Text = szoveg;
            CANVAS_valasz_edit_uj.Visibility = Visibility.Visible;
            listafeltolt();
        }
       
        private void valasz_torlese(object sender, RoutedEventArgs e, int id)
        {
            switch (dB.RemoveValasz(id))
            {

                case hibakodok.DB_nincs_kapcsolat:
                    MessageBox.Show("nincs db kapcsolat");
                    this.Close();
                    break;
                case hibakodok.DB_siker:
                    MessageBox.Show("sikeres mentés");
                    break;
                case hibakodok.DB_nincs_ID:
                    MessageBox.Show("nincs ID");
                    break;
                case hibakodok.db_sikertelen:
                    MessageBox.Show("sikertelen mentés");
                    break;

            }
            listafeltolt();
        }

        private void BTN_uj_Click(object sender, RoutedEventArgs e)
        {
            windowMode.Tag = "uj";
            TX_kerdes.Text = "";
            CANVAS_valasz_edit_uj.Visibility = Visibility.Visible;
        }

        private void valasz_edit_uj_mentes(object sender, RoutedEventArgs e)
        {
            if (TX_kerdes.Text != "")
            {
                if (windowMode.Tag == "uj")
                {
                    dB.addValasz(kerdesID, TX_kerdes.Text);
                }
                if (windowMode.Tag == "edit")
                {
                    dB.EditValasz((int)((Button)sender).Tag, TX_kerdes.Text);
                }
                CANVAS_valasz_edit_uj.Visibility = Visibility.Hidden;
            }
            listafeltolt();
        }

        private void valasz_edit_Megsem_click(object sender, RoutedEventArgs e)
        {
            CANVAS_valasz_edit_uj.Visibility = Visibility.Hidden;
        }
    }
}

using beadando.Osztalyok;
using beadando.Osztalyok.DBrelated;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for eredmenyWindow.xaml
    /// </summary>
    public partial class eredmenyWindow : Window
    {
        DBFunkciok dBFunkciok = new DBFunkciok();
        private int kutatsID=0;
        public eredmenyWindow( int kutatsID)
        {
            InitializeComponent();
            this.kutatsID=kutatsID;
            szures_kerdesre.IsChecked = true;
        }

        
        private List<int> kerdesIdLista=new List<int>();
        private int index = 0;
        private int szurestipus = 2;

        private void drawDunoutByType()
        {
            if (index>=0)
            {

            
                switch (szurestipus)
                {
                    case 1:
                        var plt2 = diagram.plt;
                        double[] values2=null;
                        string[] labels2=null;
                        switch (index)
                        {
                            case 0:
                                var b = dBFunkciok.getKitoltesNemByKutatasID(kutatsID);
                                values2 = new double[b.Count];
                                labels2 = new string[b.Count];
                                for (int i = 0; i < b.Count; i++)
                                {
                                    values2[i] = b[i].Item2;
                                    labels2[i] = b[i].Item1;
                                }
                                break;
                            case 1:
                                var b2 = dBFunkciok.getKitoltesKorByKutatasID(kutatsID);
                                values2 = new double[b2.Count];
                                labels2 = new string[b2.Count];
                                for (int i = 0; i < b2.Count; i++)
                                {
                                    values2[i] = b2[i].Item2;
                                    labels2[i] = b2[i].Item1.ToString();
                                }
                                break;
                            case 2:
                                var b3 = dBFunkciok.getKitoltesVegzettsegByKutatasID(kutatsID);
                                values2 = new double[b3.Count];
                                labels2 = new string[b3.Count];
                                for (int i = 0; i < b3.Count; i++)
                                {
                                    values2[i] = b3[i].Item2;
                                    labels2[i] = b3[i].Item1;
                                }
                                break;
                        }
                   

                   
                   
                        var pie2 = plt2.AddPie(values2);
                        pie2.SliceLabels = labels2;
                        pie2.ShowPercentages = true;
                        pie2.ShowValues = true;
                        pie2.ShowLabels = true;
                        diagram.Refresh();
                        break;

                    case 2:
                        var a=dBFunkciok.getKitoltesValaszokCountByKerdesID(kerdesIdLista[index]);

                        var a2 = diagram.plt;
                        double[] values=new double[a.Count];
                        string[] labels = new string[a.Count];
                        for (int i = 0; i < a.Count; i++)
                        {
                            values[i] = a[i].Item2;
                            labels[i] = a[i].Item1.szoveg;
                        }
                        var pie =a2.AddPie(values);
                        pie.SliceLabels = labels;
                        pie.ShowPercentages = true;
                        pie.ShowValues = true;
                        pie.ShowLabels = true;
                        diagram.Refresh();
                        break;
                }
            }
        }
        private void combofillByType()
        {
            combo_valaszto.Items.Clear();
            switch (szurestipus)
            {
                case 1:
                    string[] itemek = { "nem", "kor", "képzettség" };
                    foreach (var item in itemek)
                    {
                        combo_valaszto.Items.Add(item);
                    }
                    combo_valaszto.Tag = "feltoltve";
                    combo_valaszto.SelectedIndex = 0;
                    break;
                case 2:
                    List<Kerdes> kerdesek = dBFunkciok.getAllKerdesByID(kutatsID);
                    if (kerdesek.Count>0)
                    {
                        foreach (var item in kerdesek)
                        {
                            kerdesIdLista.Add(item.ID);
                            combo_valaszto.Items.Add(item.szoveg);
                        }
                        combo_valaszto.Tag = "feltoltve";
                        combo_valaszto.SelectedIndex= 0;
                    }
                   
                    break;
            }
            
        }

        private void szures_kerdesre_Checked(object sender, RoutedEventArgs e)
        {
            szures_kitoltokre.IsChecked = false;
            szurestipus = 2;
            combofillByType();
        }

        private void szures_kitoltokre_Checked(object sender, RoutedEventArgs e)
        {
            szures_kerdesre.IsChecked = false;
            szurestipus = 1;
            combofillByType();
        }

        private void combo_valaszto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index = combo_valaszto.SelectedIndex;
            if (((ComboBox)sender).Tag.ToString()== "feltoltve")
            {
                drawDunoutByType();
            }
           
           
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            /*
             
        String nev;
        String datum;
        String tantargy;
        int jegy;
            */
            InitializeComponent();
            Random vel = new Random();
            sliJegy.Value = vel.Next(1, 6);
            List<string> tantargyak = new List<string>() { "Matematika", "Irodalom", "Történelem", "Angol", "Testnevelés" };
            foreach (string tantargy in tantargyak)
            {
                cboTantargy.Items.Add(tantargy);
            }
            cboTantargy.SelectedIndex = vel.Next(0, tantargyak.Count);

        }
        private void sliJegy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblJegy.Content = sliJegy.Value;
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            if (txtNev.Text.Length >= 10)
            {
                if (int.Parse(dpDatum.Text.Split('.')[2]) <= int.Parse(DateTime.Now.ToString().Split('.')[2]))
                {
                    string formazott = $"{txtNev.Text};{cboTantargy.SelectedItem};{dpDatum.Text};{sliJegy.Value}";
                    StreamWriter sr = new StreamWriter("naplo.csv", true);
                    sr.WriteLine(formazott);
                    sr.Close();
                    MessageBox.Show("Sikeres mentés");
                }
            }
        }
    }
}

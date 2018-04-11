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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DruštvoWPF
{
    /// <summary>
    /// Interaction logic for Vnos.xaml
    /// </summary>
    public partial class Vnos : Window
    {
        string pot = Resource1.datoteka;
        public Vnos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Darovi d = new Darovi();
            try
            {
                d.ZapŠt = int.Parse(txtZapŠt.Text);
            }
            catch { }

            d.Datum = dtpDatum.SelectedDate.Value;
            d.Namen = txtNamen.Text;

            try
            {
                d.Znesek = double.Parse(txtZnesek.Text);
            }
            catch { }
            
            d.Opombe = txtOpombe.Text;
            if (d.ZapŠt != 0 && d.Znesek != 0)
            {
                FileStream fs = new FileStream(pot, FileMode.Append);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, d);
                fs.Close();
            }
        }
    }
}

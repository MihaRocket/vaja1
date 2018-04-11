using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Xml.Serialization;

namespace DruštvoWPF
{
    /// <summary>
    /// Interaction logic for Obnovi.xaml
    /// </summary>
    public partial class Obnovi : Window
    {
        List<Darovi> vsi = new List<Darovi>();
        public Obnovi()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = dtpDatum.SelectedDate.Value.ToShortDateString();
                string imeD = @"D:\Pro2\ZascitaWPF" + a + ".xml";
                FileStream fs1 = new FileStream(imeD, FileMode.Open);
                XmlSerializer sr = new XmlSerializer(typeof(List<Darovi>));
                vsi = (List<Darovi>)sr.Deserialize(fs1);
                fs1.Close();

                string pot = Resource1.datoteka;
                FileInfo fi = new FileInfo(pot);
                fi.Delete();

                FileStream fs = new FileStream(pot, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                foreach (Darovi d in vsi)
                {
                    bf.Serialize(fs, d);
                }
                fs.Close();
                MessageBox.Show("Opravljeno");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Na ta dan ni bilo zaščite, poskusi z drugim datumom");
            }
        }
    }
}

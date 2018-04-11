using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
    /// Interaction logic for Zaščita.xaml
    /// </summary>
    public partial class Zaščita : Window
    {
        string pot = Resource1.datoteka;
        List<Darovi> vsi = new List<Darovi>();
        public Zaščita()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //beri iz binarne datoteke
            FileStream fs = new FileStream(pot, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                while (true)
                {
                    Darovi d = (Darovi)bf.Deserialize(fs);
                    vsi.Add(d);
                }
            }
            catch (SerializationException) { }
            //piši v xml datoteko
            string imeD = @"D:\Pro2\ZascitaWPF" + DateTime.Now.ToShortDateString() + ".xml";
            FileStream fs1 = new FileStream(imeD, FileMode.Create);
            XmlSerializer sr = new XmlSerializer(typeof(List<Darovi>));
            sr.Serialize(fs1, vsi);
            fs1.Close();
            MessageBox.Show("Opravljeno");
        }
    }
}

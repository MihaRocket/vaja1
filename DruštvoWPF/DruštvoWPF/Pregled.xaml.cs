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

namespace DruštvoWPF
{
    /// <summary>
    /// Interaction logic for Pregled.xaml
    /// </summary>
    public partial class Pregled : Window
    {
        string pot = Resource1.datoteka;
        List<Darovi> spremembe = new List<Darovi>();
        int štSprememb = 0;
        public Pregled()
        {
            InitializeComponent();
        }

        private void NaložiPodatke(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(pot, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Darovi d;
            try
            {
                while (true)
                {
                    d = (Darovi)bf.Deserialize(fs);
                    spremembe.Add(d);
                }
            }
            catch (SerializationException)
            {

            }
            dgPodatki.ItemsSource = spremembe;
            fs.Close();
        }
    }
}

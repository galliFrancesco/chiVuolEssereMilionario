using System;
using System.Collections.Generic;
using System.IO;
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

namespace ChiVuolEssereMilionario
{
    /// <summary>
    /// Logica di interazione per Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //MainWindow m = new MainWindow();
        CSVReader cs = new CSVReader();
        //private CPunt cp = null;
        public int punt = 0; 

        public Window1()
        {
            InitializeComponent();
            //this.cp = m.p;
        }

        public void setPunt(int punt)
        {
            this.punt = punt;
        }

        private void invioButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameText.Text;
            // passa la stringa al csv reader
            cs.append(name, punt);

            Close();
        }
    }
}

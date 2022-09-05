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

namespace ChiVuolEssereMilionario
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

         CSVReader c = new CSVReader();
        List<CDoamnde> lista = new List<CDoamnde>();

        //public CPunt p = new CPunt(); 
        public Window1 win2 = new Window1();

        int giusta = 0;
        int numEl = 0;  // rappresenta come un "puntatore di domanda", ma potrebbe anceh essere per il punteggio

        public MainWindow()
        {
            InitializeComponent();
            lista = c.toList();

            gerryImage.Source = new BitmapImage(new Uri("/ChiVuolEssereMilionario;component/Imagess/inizio.jpg", UriKind.Relative));
            domandaTextBox.Foreground = Brushes.White;
            ris1Button.Foreground = Brushes.White;
            ris2Button.Foreground = Brushes.White;
            ris3Button.Foreground = Brushes.White;
            ris4Button.Foreground = Brushes.White;
            puntText.Foreground = Brushes.White;

            domandaTextBox.Text = lista[numEl].domanda;
            ris1Button.Content = lista[numEl].ris1;
            ris2Button.Content = lista[numEl].ris2;
            ris3Button.Content = lista[numEl].ris3;
            ris4Button.Content = lista[numEl].ris4;
        }

        private void ris1Button_Click(object sender, RoutedEventArgs e)
        {
            // questo bottone ha valore 1, come il bottone 2 = 2, etc...
            giusta = lista[numEl].giusta;   // prende il valore della risposta giusta
            if (giusta == 1) // la risposta è giusta
                risGiusta(); // allora cambia la domanda 
            else
                risSbagliata();
        }
        private void ris2Button_Click(object sender, RoutedEventArgs e)
        {
            giusta = lista[numEl].giusta;   // prende il valore della risposta giusta
            if (giusta == 2) // la risposta è giusta
                risGiusta(); // allora cambia la domanda 
            else
                risSbagliata();
        }
        private void ris3Button_Click(object sender, RoutedEventArgs e)
        {
            giusta = lista[numEl].giusta;   // prende il valore della risposta giusta
            if (giusta == 3) // la risposta è giusta
                risGiusta(); // allora cambia la domanda 
            else
                risSbagliata();
        }
        private void ris4Button_Click(object sender, RoutedEventArgs e)
        {
            giusta = lista[numEl].giusta;   // prende il valore della risposta giusta
            if (giusta == 4) // la risposta è giusta
                risGiusta(); // allora cambia la domanda 
            else
                risSbagliata();
        }

        private void risGiusta() 
        {
            ris1Button.IsEnabled = true;
            ris2Button.IsEnabled = true;
            ris3Button.IsEnabled = true;
            ris4Button.IsEnabled = true;

            numEl++;

            puntText.Text = numEl + "/15"; 

            if (numEl == 15) // numero di risposte giuste
            {
                MessageBoxResult result =  MessageBox.Show("Congratulazioni, HAI VINTO!" + '\n' + "Vuoi salvare il tuo punteggio? (" + numEl + "/15)", "GG", MessageBoxButton.YesNo, MessageBoxImage.Question);   // messaggio, titolo, risposte, immagine             
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        //p.punteggio = numEl; 
                        win2.setPunt(numEl);
                        win2.ShowDialog();
                        break;
                }
                System.Windows.Application.Current.Shutdown();
            }
            else
            {
                domandaTextBox.Text = lista[numEl].domanda;
                ris1Button.Content = lista[numEl].ris1;
                ris2Button.Content = lista[numEl].ris2;
                ris3Button.Content = lista[numEl].ris3;
                ris4Button.Content = lista[numEl].ris4;
            }
            gerryImage.Source = new BitmapImage(new Uri("/ChiVuolEssereMilionario;component/Imagess/risGiusta.png", UriKind.Relative));
        }

        private void risSbagliata() 
        {
            gerryImage.Source = new BitmapImage(new Uri("/ChiVuolEssereMilionario;component/Imagess/risSbagliata.jpg", UriKind.Relative));
            MessageBoxResult result = MessageBox.Show("Risposta Sbagliata D:" + '\n' + "Vuoi salvare il tuo punteggio? (" + numEl + "/15)" , "Peccato!", MessageBoxButton.YesNo);   // messaggio, titolo, risposte, immagine
            switch (result) 
            {
                case MessageBoxResult.Yes:
                    //p.punteggio = numEl; 
                    win2.setPunt(numEl);
                    win2.ShowDialog();
                    break;
            }
            System.Windows.Application.Current.Shutdown();
        }

        private void _5050button_Click(object sender, RoutedEventArgs e)
        {
            int other = 0; 
            var rand = new Random();
            giusta = lista[numEl].giusta;
            // disabilita tutti i bottoni
            ris1Button.IsEnabled = false;
            ris2Button.IsEnabled = false;
            ris3Button.IsEnabled = false;
            ris4Button.IsEnabled = false;

            do
            {
                other = rand.Next(1, 4);    // imposta che un tasto a caso solo viene abilitato
            } while (other==giusta);

            switch (other) 
            {
                case 1:
                    ris1Button.IsEnabled = true;
                    break;
                case 2:
                    ris2Button.IsEnabled = true;
                    break;
                case 3:
                    ris3Button.IsEnabled = true;
                    break;
                case 4:
                    ris4Button.IsEnabled = true;
                    break;
            }   // attivare il pulsante a caso

            switch (giusta)
            {
                case 1:
                    ris1Button.IsEnabled = true;
                    break;
                case 2:
                    ris2Button.IsEnabled = true;
                    break;
                case 3:
                    ris3Button.IsEnabled = true;
                    break;
                case 4:
                    ris4Button.IsEnabled = true;
                    break;
            }

            _5050button.IsEnabled = false;
        }

        private void callButton_Click(object sender, RoutedEventArgs e)
        {
            // generatore casuale, se è 0 allora ti dice la rispopsat sabgliata, altrimenti è giusta
            var rand = new Random();
            int call = rand.Next(0, 2);

            if(call==1)// allora ti dice la giusta;
                MessageBox.Show("Secondo me quella giusta è la " + lista[numEl].giusta.ToString() , "Ti aiuto io!", MessageBoxButton.OK, MessageBoxImage.Question);   // messaggio, titolo, risposte, immagine
            else // sennò no XD
                MessageBox.Show("Secondo me quella giusta è la " + rand.Next(1,4).ToString(), "Ti aiuto io!", MessageBoxButton.OK, MessageBoxImage.Question);   // messaggio, titolo, risposte, immagine

            callButton.IsEnabled = false; 
        }
    }
}
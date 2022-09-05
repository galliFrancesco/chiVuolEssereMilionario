using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiVuolEssereMilionario
{
    public class CDoamnde
    {
        CSVReader cs = new CSVReader();

        public string domanda { get; set; }
        public string ris1 { get; set; }
        public string ris2 { get; set; }
        public string ris3 { get; set; }
        public string ris4 { get; set; }
        public int giusta { get; set; } // la rispopsta, quella giusta

        public CDoamnde() 
        {
            domanda = "";
            ris1 = "";
            ris2 = "";
            ris3 = "";
            ris4 = ""; 
        }
        public CDoamnde(string linea) // riceve una linea dal file CSV e la trasforma nei vari dati  
        {
            int at = 0;
            //string copia = linea;

            /*
            at = linea.IndexOf(';', start); // ottiene la prima posizione del ';'
            int l = linea.Length - at;   // ottiene la lunghezza da start a ';'
            domanda = linea.Substring(l);
            copia = linea.Substring(start, l);
            //start = at + 1;
            at = copia.IndexOf(';', start); // ottiene la prima posizione del ';'
            //l = linea.Length - at;   // ottiene la lunghezza da start a ';'
            ris1 = copia.Substring(start, at-1);
            */

            // i potrebbe anche funzionare come contatore che dice in che sezione ci troviamo 
            for (int i = 0; i < 6; i++)
            {             
                at = linea.IndexOf(';'); // ottiene la prima posizione del ';'

                switch (i) 
                {
                    case 0: // domanda 
                        domanda = linea.Substring(0, at);
                        linea = linea.Substring(at+1); 
                        break;
                    case 1: // risposta 1
                        ris1 = linea.Substring(0, at);
                        linea = linea.Substring(at + 1);
                        break;  
                    case 2: // risposta 2
                        ris2 = linea.Substring(0, at);
                        linea = linea.Substring(at + 1);
                        break;
                    case 3: // risposta 3 
                        ris3 = linea.Substring(0, at);
                        linea = linea.Substring(at + 1);
                        break;
                    case 4: // risposta 4
                        ris4 = linea.Substring(0, at);
                        linea = linea.Substring(at + 1);
                        break;
                    case 5:
                        giusta = Int32.Parse(linea.Substring(0, at));
                        break;
                }
            }          
        }
    }
}

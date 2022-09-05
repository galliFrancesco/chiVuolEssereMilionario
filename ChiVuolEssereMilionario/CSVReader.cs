using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiVuolEssereMilionario
{
    public class CSVReader
    {
        public List<CDoamnde> toList()
        {
            List<CDoamnde> lista = new List<CDoamnde>();
            StreamReader FIN = new StreamReader(@"Test.txt");  // filename = @"Test.txt"

            while (!FIN.EndOfStream)
            {
                string riga = FIN.ReadLine();
                CDoamnde dom = new CDoamnde(riga);
                lista.Add(dom);
            }

            FIN.Close();
            return lista;
        }
        public void append(string nome, int punt)
        {
            StreamWriter FOUT = new StreamWriter(@"Saves.csv", true); //append

            FOUT.WriteLine(nome+";"+punt+";");
            FOUT.Close();
        }
    }
}

/*
int MAXEL = 100;
// array di cose ?
int numEl = 0;
string [MAXEL] domanda { get; set; }
string [MAXEL] ris1;
string [MAXEL] ris2;
string [MAXEL] ris3;
string [MAXEL] ris4;
int [MAXEL] right;


public CSVReader() 
{

} 

public void read() 
{
    string[] lines = System.IO.File.ReadAllLines(@"Test.txt");

    foreach (string line in lines)
    {
        // line è il contenuto 
        divide(line);
        numEl++;
    }
}


private void divide(string line)    // divide la line in base ai ';' 
{
    int start = 0;
    int at = 0;
    int count = 0; 
    do
    {
        //at = 0; // position of ';'

        at = line.IndexOf(';', start); // first position of ';'

        switch (count)
        {
            case 0:
                domanda[numEl] = line.Substring(0, at);
                break;
            case 1:
                ris1[numEl] = line.Substring(start, at);
                break;
            case 2:
                ris2[numEl] = line.Substring(start, at);
                break;
            case 3:
                ris3[numEl] = line.Substring(start, at);
                break;
            case 4:
                ris4[numEl] = line.Substring(start, at);
                break;
            case 5:
                right[numEl] = Int32.Parse(line.Substring(start, at));
                break; 
        }            
        start = at + 1;
        count++;
    } while (at > line.Length || count >5 );



}
// Read each line of the file into a string array. Each element
// of the array is one line of the file.
//string[] lines = System.IO.File.ReadAllLines(@"Test.txt");  

// Display the file contents by using a foreach loop.
//System.Console.WriteLine("Contents of WriteLines2.txt = ");
// foreach (string line in lines)
//{
// Use a tab to indent each line of the file.
//  testo.Text += line;
//}

public string toString() 
{
    return domanda[0];
}*/
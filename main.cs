using System;
using System.Collections.Generic;
using System.Linq;


class MainClass 
{
  public static List<studentas> studentai = new List<studentas>();

  public static void Main (string[] args) 
  {
    Console.WriteLine("Įveskite studento vardą, pavardę, n.d. pažymius ir egzamino rezultatą");
    string nuskaitymas = Console.ReadLine();
    var whitesp = nuskaitymas.Split((char[])null, StringSplitOptions.RemoveEmptyEntries); //nuima whitespace

    string vardas = whitesp[0];
    string pavarde = whitesp[1]; 
    double rezEgz = double.Parse(whitesp.Last());
    List<double> balai = new List<double>();
    for (int i = 2; i < whitesp.Length - 1; i++)
    {
      balai.Add(double.Parse(whitesp[i]));
    } 

    studentai.Add(new studentas(vardas, pavarde, rezEgz, balai));
    Console.WriteLine("{0} {1, 10} {2, 10} {3, 10}", "Pavarde", "Vardas", "Galutinis (vid.)", "Galutinis (med.)");
    Console.WriteLine("-----------------------------------------------------");
    foreach (var value in studentai)
    {
      Console.WriteLine("{0} {1, 10} {2, 10} {3, 10}", value.pavarde, value.vardas, value.galutinis.ToString("#.##"), value.galutinisMed);
    }
    
    
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; 


class MainClass 
{
  public static List<studentas> studentai = new List<studentas>();

  public static void Main (string[] args) 
  { 
    meniu();
  }

  public static void meniu ()
  {
    bool tikrinimas = true;
    Console.WriteLine("Įveskite '1' jei norite prideti studentą iš klaviatūros;");
    Console.WriteLine("Įveskite '2' jei norite prideti studentus iš failo;");
    Console.WriteLine("Įveskite '3' jei norite atspausdinti studentų sąrašą;");
    Console.WriteLine("Įveskite '4' jei norite išeiti.");
    while (tikrinimas)
    {
      string c = Console.ReadLine();
      if (c == "1")
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
        studentai = studentai.OrderBy(o=>o.vardas).ToList();

      }
      if (c == "2")
      {
        string[] lines = File.ReadAllLines("studentai.txt");  
        Console.WriteLine("Dokumentas kraunamas");
        foreach (string nuskaitymas in lines) 
        {
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
        } 
        Console.WriteLine("Dokumentas užkrautas");
        studentai = studentai.OrderBy(o=>o.vardas).ToList();

      }
      if (c == "3")
      {
        Console.WriteLine("{0} {1, 10} {2, 10} {3, 10}", "Pavarde", "Vardas", "Galutinis (vid.)", "Galutinis (med.)");
        Console.WriteLine("-----------------------------------------------------");
        foreach (var value in studentai)
        {
          Console.WriteLine("{0} {1, 10} {2, 10} {3, 10}", value.pavarde, value.vardas, value.galutinis.ToString("0.00"), value.galutinisMed.ToString("0.00"));
        }
      }
      if (c == "4")
      {
        tikrinimas = false;
        return;
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; 
using System.Diagnostics;



class MainClass 
{
  public static List<studentas> studentai = new List<studentas>();
  public static List<studentas> vargsiukai = new List<studentas>();
  public static List<studentas> galvociai = new List<studentas>();
  public static void Main (string[] args) 
  { 
    meniu();
  }
  public static Stopwatch stopwatch = new Stopwatch();

  public static void meniu ()
  {
    bool tikrinimas = true;
    Console.WriteLine("Įveskite '1' jei norite prideti studentą iš klaviatūros;");
    Console.WriteLine("Įveskite '2' jei norite prideti studentus iš failo;");
    Console.WriteLine("Įveskite '3' jei norite atspausdinti studentų sąrašą;");
    Console.WriteLine("Įveskite '4' jei norite išeiti.");
    Console.WriteLine("Įveskite '5' jei sugeneruoti failus.");
    Console.WriteLine("Įveskite '6' jei norite atspausdinti geriukus.");
    Console.WriteLine("Įveskite '7' jei atspausdinti blogiukus.");
    while (tikrinimas)
    {
      string c = Console.ReadLine();
      if (c == "1")
      {
        try
        {
          Console.WriteLine("Įveskite studento vardą, pavardę, n.d. pažymius ir egzamino rezultatą");
          string nuskaitymas = Console.ReadLine();
          var whitesp = nuskaitymas.Split((char[])null, StringSplitOptions.RemoveEmptyEntries); //nuima whitespace
          stopwatch.Start();

          string vardas = whitesp[0];
          string pavarde = whitesp[1]; 
          double rezEgz = double.Parse(whitesp.Last());
          List<double> balai = new List<double>();
          for (int i = 2; i < whitesp.Length - 1; i++)
          {
            balai.Add(double.Parse(whitesp[i]));
          } 

          studentas laik = new studentas(vardas, pavarde, rezEgz, balai);
          studentai.Add(laik);
          if (laik.galutinis < 5)
          {
            vargsiukai.Add(laik);
          }
          if (laik.galutinis >= 5)
          {
            galvociai.Add(laik);
          }
          studentai = studentai.OrderBy(o=>o.vardas).ToList();
          galvociai = galvociai.OrderBy(o=>o.vardas).ToList();
          vargsiukai = vargsiukai.OrderBy(o=>o.vardas).ToList();
          stopwatch.Stop();
          Console.WriteLine("Praejo tiek laiko: {0}", stopwatch.Elapsed);
          stopwatch = new Stopwatch();
        }
        catch (Exception ex)
        {
          Console.WriteLine("Rasta klaida bandant įvesti failą iš klaviatūros: " + ex.Message);
        }
      }
      if (c == "2")
      {
        try
        {
          string[] array2 = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
          foreach (string pav in array2)
          {
            Console.WriteLine(pav + " ");
          }
          Console.WriteLine("Įveskite norimą failą");
          string fail = Console.ReadLine();
          string[] lines = File.ReadAllLines(fail);  
          stopwatch.Start();

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
            studentas laik = new studentas(vardas, pavarde, rezEgz, balai);
            studentai.Add(laik);
            if (laik.galutinis < 5)
            {
              vargsiukai.Add(laik);
            }
            if (laik.galutinis >= 5)
            {
              galvociai.Add(laik);
            }
            studentai = studentai.OrderBy(o=>o.vardas).ToList();
            galvociai = galvociai.OrderBy(o=>o.vardas).ToList();
            vargsiukai = vargsiukai.OrderBy(o=>o.vardas).ToList();
          } 
          Console.WriteLine("Dokumentas užkrautas");
          studentai = studentai.OrderBy(o=>o.vardas).ToList();
          stopwatch.Stop();
          Console.WriteLine("Praejo tiek laiko: {0}", stopwatch.Elapsed);
          stopwatch = new Stopwatch();
          }
        catch (Exception ex)
        {
          Console.WriteLine("Rasta klaida bandant nuskaityti failą: " + ex.Message);
        }
      }
      if (c == "3")
      {
        try 
        {
          stopwatch.Start();          
          Console.WriteLine("{0} {1, 10} {2, 10} {3, 10}", "Pavarde", "Vardas", "Galutinis (vid.)", "Galutinis (med.)");
          Console.WriteLine("-----------------------------------------------------");
          foreach (var value in studentai)
          {
          Console.WriteLine("{0} {1, 10} {2, 10} {3, 10}", value.pavarde, value.vardas, value.galutinis.ToString("0.00"), value.galutinisMed.ToString("0.00"));
          }
          stopwatch.Stop();
          Console.WriteLine("Praejo tiek laiko: {0}", stopwatch.Elapsed);
          stopwatch = new Stopwatch();
        }
        catch (Exception ex)
        {
          Console.WriteLine("Rasta klaida bandant išvesti failą į ekraną: " + ex.Message);
        }
      }
      if (c == "4")
      {
        tikrinimas = false;
        return;
      }
      if (c == "5")
      {
        try
        {
          Console.WriteLine("Įveskite norimą sugeneruoti studentų kiekį");
          int studkiek = int.Parse(Console.ReadLine());
         string tt1 = "";
         
         stopwatch.Start();
         Console.WriteLine("Failo generavimas pradėtas");
          for (int i = 1; i <= studkiek; i++)
          {
            string vardas1, pavarde1, rezEgz1 = "", balai1 = "";
            Random random = new Random(); 
            vardas1 = "vardas" + i + " ";
            pavarde1 = "pavarde" + i + " ";
            double tt = random.Next(1, 11);
            balai1 = balai1 + tt + " ";
            tt = random.Next(1, 11);
            balai1 = balai1 + tt + " ";
            tt = random.Next(1, 11);
            balai1 = balai1 + tt + " ";
            tt = random.Next(1, 11);
            balai1 = balai1 + tt + " ";
            tt = random.Next(1, 11);
            balai1 = balai1 + tt + " ";
            tt = random.Next(1, 11);
            balai1 = balai1 + tt + " ";
            tt = random.Next(1, 11);
            rezEgz1 = rezEgz1 + tt + "\n";
            tt1 = tt1 + vardas1 + pavarde1 + balai1 + rezEgz1;
          }
          File.WriteAllText(studkiek + ".txt", tt1);
          Console.WriteLine("Failo generavimo pabaiga");
          stopwatch.Stop();
          Console.WriteLine("Praejo tiek laiko: {0}", stopwatch.Elapsed);
          stopwatch = new Stopwatch();
          }
        catch (Exception ex)
        {
          Console.WriteLine("Rasta klaida bandant generuoti failus: " + ex.Message);
        }
      }
      if (c == "6")
      {
        try 
        {
          stopwatch.Start();
          Console.WriteLine("{0} {1, 10} {2, 10} {3, 10}", "Pavarde", "Vardas", "Galutinis (vid.)", "Galutinis (med.)");
          Console.WriteLine("-----------------------------------------------------");
          foreach (var value in galvociai)
          {
          Console.WriteLine("{0} {1, 10} {2, 10} {3, 10}", value.pavarde, value.vardas, value.galutinis.ToString("0.00"), value.galutinisMed.ToString("0.00"));
          }
          stopwatch.Stop();
          Console.WriteLine("Praejo tiek laiko: {0}", stopwatch.Elapsed);
          stopwatch = new Stopwatch();
        }
        catch (Exception ex)
        {
          Console.WriteLine("Rasta klaida bandant išvesti failą į ekraną: " + ex.Message);
        }
      }
      if (c == "7")
      {
        try 
        {
          stopwatch.Start();
          Console.WriteLine("{0} {1, 10} {2, 10} {3, 10}", "Pavarde", "Vardas", "Galutinis (vid.)", "Galutinis (med.)");
          Console.WriteLine("-----------------------------------------------------");
          foreach (var value in vargsiukai)
          {
          Console.WriteLine("{0} {1, 10} {2, 10} {3, 10}", value.pavarde, value.vardas, value.galutinis.ToString("0.00"), value.galutinisMed.ToString("0.00"));
          }
          stopwatch.Stop();
          Console.WriteLine("Praejo tiek laiko: {0}", stopwatch.Elapsed);
          stopwatch = new Stopwatch();
        }
        catch (Exception ex)
        {
          Console.WriteLine("Rasta klaida bandant išvesti failą į ekraną: " + ex.Message);
        }
      }
    }
  }
}

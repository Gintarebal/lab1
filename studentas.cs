using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; 
using System.Diagnostics;


class studentas 
{
  public string vardas {get; set;}
  public string pavarde {get; set;}
  public double rezEgz {get; set;}
  public double galutinis {get; set;}
  public double galutinisMed {get; set;}

  public LinkedList<double> balai = new LinkedList<double>();
  public double vid {get; set;} = 0;

  public studentas (string vardas, string pavarde, double rezEgz, LinkedList<double> balai)
  {
    this.vardas = vardas;
    this.pavarde = pavarde;
    this.rezEgz = rezEgz;
    this.balai = balai;
    foreach (var value in this.balai)
    {
      this.vid = this.vid + value;
    }
    this.vid = this.vid / this.balai.Count;
    this.galutinis = this.vid * 0.3 + this.rezEgz * 0.7;
    
    this.galutinisMed = this.balai.ToList()[this.balai.ToList().Count / 2] * 0.3 + this.rezEgz * 0.7;
  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StrategiaEwolucyjna_SSI
{
    public class Osobnik
    {
        public double x1;
        public double x2;
        public double ocena;
        public Osobnik(double x1 = 0, double x2 = 0) 
        { 
            this.x1 = x1;
            this.x2 = x2;
        }
        public Osobnik Clone()
        {
            return (Osobnik)this.MemberwiseClone();
        }
    }
}

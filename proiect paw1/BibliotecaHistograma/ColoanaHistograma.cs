using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaHistograma
{
    public class ColoanaHistograma
    {

        public int Value { get; set; }
        public string Label { get; set; }
        public string Color { get; set; }
         

        public ColoanaHistograma(string label,int value,string color)
        { 
            this.Label = label;
            this.Color = color;
           
            this.Value = value;
        }
        
    }
}

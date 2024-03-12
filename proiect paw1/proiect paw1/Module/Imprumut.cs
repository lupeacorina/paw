using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_paw1.Module
{
   public class Imprumut
    {
        public int CodImprumut { get; set; }
        public Cititor cititor { get; set; }
        public List<Carte> carti { get; set; }
        private DateTime _dataImprumutului;
        public DateTime DataImprumutului {
            get { return _dataImprumutului; }
            set
            {
                if (value > DateTime.Today.AddDays(30))
                    throw new InvalidDateException(value);
                _dataImprumutului = value;
            }
        }

        public Imprumut()
        {
            CodImprumut = 0;
            cititor = null;
            carti = new List<Carte>();
            DataImprumutului = DateTime.Now;
        }

        public static Imprumut operator +(Imprumut t, Carte c)
        {

            t.carti.Add(c);

            return t;
        }
    }
}

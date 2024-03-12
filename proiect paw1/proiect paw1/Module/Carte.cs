using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_paw1.Module
{
    [Serializable]
    public class Carte:IComparable<Carte>
    {
        public int CodCarte { get; set; }
        public String Titlul { get; set; }
        public String Autor { get; set; }
        public String Editura { get; set; }
        public int AnAparitie { get; set; }
        public Carte()
        {
            
            Titlul = "Necunoscut";
            Autor = "Necunoscut";
            Editura = "Necunoscuta";
            AnAparitie = 2000;
        }
        public Carte(int CodCarte, String Titlul, String Autor, String Editura, int AnAparitie)
        {
            this.CodCarte = CodCarte;
            this.Titlul = Titlul;
            this.Autor = Autor;
            this.AnAparitie = AnAparitie;
            this.Editura = Editura;
        }
        public Carte( String Titlul, String Autor, String Editura, int AnAparitie)
        {
          
            this.Titlul = Titlul;
            this.Autor = Autor;
            this.AnAparitie = AnAparitie;
            this.Editura = Editura;
        }

        public int CompareTo(Carte other)
        {
            return this.AnAparitie.CompareTo(other.AnAparitie);
        }
        public override string ToString()
        {
            return "Cartea " + Titlul + " scrisa de autorul " + Autor + " publicata la editura " + Editura + " in anul " + AnAparitie;
        }
    }
}

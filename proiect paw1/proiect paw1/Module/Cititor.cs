using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_paw1.Module
{
    public class Cititor:ICloneable
    {
        public int CodCititor { get; set; }
        public String Nume { get; set; }
        public String Prenume { get; set; }
        public String Adresa { get; set; }
        public DateTime DataNasterii { get; set; }
        public String NrTelefon { get; set; }
        public String Email { get; set; }

        public Cititor()
        {
            Nume = "Anonim";
            Prenume = "Anonim";
            Adresa = "Necunoscuta";
            DataNasterii = DateTime.Now;
            NrTelefon = "necunoscut";
            Email = "nescunoscut";
        }
        public Cititor(String nume, String prenume,String adresa, DateTime data,String telefon, String email)
        {
            Nume = nume;
            Prenume = prenume;
            Adresa = adresa;
            DataNasterii = data;
            NrTelefon = telefon;
            Email = email;
        }

        public Cititor(int cod,String nume, String prenume, String adresa, DateTime data, String telefon, String email)
        {
            CodCititor = cod;
            Nume = nume;
            Prenume = prenume;
            Adresa = adresa;
            DataNasterii = data;
            NrTelefon = telefon;
            Email = email;
        }

        public object Clone()
        {
            Cititor clona = new Cititor();
            clona.CodCititor = this.CodCititor;
            clona.Nume = this.Nume;
            clona.Prenume = this.Prenume;
            clona.Adresa = this.Adresa;
            clona.DataNasterii = this.DataNasterii;
            clona.NrTelefon = this.NrTelefon;
            clona.Email = this.Email;
            return clona;
        }
    }
}

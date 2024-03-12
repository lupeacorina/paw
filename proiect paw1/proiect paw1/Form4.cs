using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proiect_paw1.Module;

namespace proiect_paw1
{
    public partial class Form4 : Form
    {
        private const string ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =\"baza_de_date.mdb\";Persist Security Info=True";
        Cititor cititor = new Cititor();
        public Form4(Cititor c)
        {
            InitializeComponent();
            cititor = c;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textNume.Text = cititor.Nume;
            textPrenume.Text = cititor.Prenume;
            textAdresa.Text = cititor.Adresa;
            textEmail.Text = cititor.Email;
            textTelefon.Text = cititor.NrTelefon;
            dateTimePicker1.Value = cititor.DataNasterii;
        }
        //editare
        private void btnAdaugaCartea_Click(object sender, EventArgs e)
        {
            bool valid = true;
            String nume = textNume.Text;

            if (String.IsNullOrEmpty(nume) ||
                String.IsNullOrWhiteSpace(nume) ||
                nume.Length < 2)
                valid = false;
            else cititor.Nume = textNume.Text;
            String prenume = textPrenume.Text;
            if (String.IsNullOrEmpty(prenume) ||
              String.IsNullOrWhiteSpace(prenume) ||
              prenume.Length < 2)
                valid = false;
            else
            {
                cititor.Prenume = prenume;

            }
            String adresa = textAdresa.Text;

            if (String.IsNullOrEmpty(adresa) ||
                String.IsNullOrWhiteSpace(adresa) ||
                adresa.Length < 2)
                valid = false;
            else
                cititor.Adresa = textAdresa.Text;


            String telefon = textTelefon.Text;

            if (String.IsNullOrEmpty(telefon) ||
                String.IsNullOrWhiteSpace(telefon) ||
                telefon.Length != 10 || telefon.Contains("07") != true)
                valid = false;
            else
                cititor.NrTelefon = textTelefon.Text;
            String email = textEmail.Text;

            if (String.IsNullOrEmpty(email) ||
                String.IsNullOrWhiteSpace(email) ||
                email.Length < 2 || email.Contains("@") != true || email.Contains(".") != true)
                valid = false;
            else cititor.Email = textEmail.Text;

            DateTime dataNasterii = dateTimePicker1.Value;
            DateTime data = dataNasterii.AddYears(12);
            if (DateTime.Compare(data, DateTime.Now) > 0)
                valid = false;
            else cititor.DataNasterii = dataNasterii;

            if (valid == true)
            {
                MessageBox.Show("Modificarile dorite au fost salvate");
                const string queryString = "UPDATE cititor SET nume=?,prenume=?,adresa=?,email=?,nr_telefon=?,data_nasterii=? WHERE cod=?";

                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();

                    OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                    sqlCommand.Parameters.Add("nume", cititor.Nume);
                    sqlCommand.Parameters.Add("prenume", cititor.Prenume);
                    sqlCommand.Parameters.Add("adresa", cititor.Adresa);
                    sqlCommand.Parameters.Add("email", cititor.Email);
                    sqlCommand.Parameters.Add("nr_telefon", cititor.NrTelefon);
                    sqlCommand.Parameters.Add("data_nasterii", cititor.DataNasterii);
                    sqlCommand.Parameters.AddWithValue("cod", cititor.CodCititor);


                    sqlCommand.ExecuteNonQuery();

                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Formularul contine erori!", "Modificarile nu au fost salvate!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
        //curatare
        private void btnCurata_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nu s-a realizat nicio modificare asupra cititorului selectat!");
            this.Close();
        }
        #region validare
        private void textNume_Validated(object sender, EventArgs e)
        {
            epNume.Clear();
        }

        private void textNume_Validating(object sender, CancelEventArgs e)
        {
            String nume = textNume.Text;

            if (String.IsNullOrEmpty(nume) ||
                String.IsNullOrWhiteSpace(nume) ||
                nume.Length < 2)
            {

                epNume.SetError((Control)sender, "Numele trebuie sa aiba minim 2 caractere!");
                e.Cancel = true;
            }
        }

        private void textPrenume_Validated(object sender, EventArgs e)
        {
            epPrenume.Clear();
        }

        private void textPrenume_Validating(object sender, CancelEventArgs e)
        {
            String prenume = textPrenume.Text;

            if (String.IsNullOrEmpty(prenume) ||
                String.IsNullOrWhiteSpace(prenume) ||
                prenume.Length < 2)
            {

                epPrenume.SetError((Control)sender, "Prenumele trebuie sa aiba minim 2 caractere!");
                e.Cancel = true;
            }

        }

        private void textAdresa_Validated(object sender, EventArgs e)
        {
            epAdresa.Clear();
        }

        private void textAdresa_Validating(object sender, CancelEventArgs e)
        {
            String adresa = textAdresa.Text;

            if (String.IsNullOrEmpty(adresa) ||
                String.IsNullOrWhiteSpace(adresa) ||
                adresa.Length < 2)
            {

                epAdresa.SetError((Control)sender, "Adresa trebuie sa aiba minim 2 caractere!");
                e.Cancel = true;
            }
        }

        private void textEmail_Validated(object sender, EventArgs e)
        {
            epEmail.Clear();
        }

        private void textEmail_Validating(object sender, CancelEventArgs e)
        {
            String email = textEmail.Text;

            if (String.IsNullOrEmpty(email) ||
                String.IsNullOrWhiteSpace(email) ||
                email.Length < 2 || email.Contains("@") != true || email.Contains(".") != true)
            {

                epEmail.SetError((Control)sender, "Email-ul trebuie sa aiba minim 2 caractere si sa contina @ si .!");
                e.Cancel = true;
            }

        }

        private void textTelefon_Validated(object sender, EventArgs e)
        {
            epTelefon.Clear();
        }

        private void textTelefon_Validating(object sender, CancelEventArgs e)
        {
            String telefon = textTelefon.Text;

            if (String.IsNullOrEmpty(telefon) ||
                String.IsNullOrWhiteSpace(telefon) ||
                telefon.Length != 10 || telefon.Contains("07") != true)
            {

                epTelefon.SetError((Control)sender, "Numarul de telefon trebuie sa aiba 10 caractere si sa fie sub forma 07...!");
                e.Cancel = true;
            }
        }

        private void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            epDataNasterii.Clear();
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            DateTime dataNasterii = dateTimePicker1.Value;
            DateTime data = dataNasterii.AddYears(12);
            if (DateTime.Compare(data, DateTime.Now) > 0)
            {
                epDataNasterii.SetError((Control)sender, "Cititorul trebuie sa aiba minim 12 ani");
                e.Cancel = true;
            }

        }
        #endregion
        //se tasteaza doar cifre ptr nr de tel
        private void textTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

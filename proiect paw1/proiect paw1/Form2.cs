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
    public partial class Form2 : Form
    {
        private const string ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =\"baza_de_date.mdb\";Persist Security Info=True";
        Carte carte = new Carte();
        public Form2(Carte c)
        {
            InitializeComponent();
            carte = c;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textTitlul.Text = carte.Titlul;
            textAutor.Text = carte.Autor;
            textEditura.Text = carte.Editura;
            textAnAparitie.Text = carte.AnAparitie.ToString();
        }
        //curatare
        private void btnCurata_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nu s-a realizat nicio modificare asupra cartii selectate!");
            this.Close();
        }
        //editare + editare in bd
        private void modifica()
        {
            bool valid = true;
            
            String titlul = textTitlul.Text;

            if (String.IsNullOrEmpty(titlul) ||
                String.IsNullOrWhiteSpace(titlul) ||
                titlul.Length < 2)
                valid = false;
            else carte.Titlul = textTitlul.Text;
            String autor = textAutor.Text;
            if (String.IsNullOrEmpty(autor) ||
              String.IsNullOrWhiteSpace(autor) ||
              autor.Length < 2)
                valid = false;
            else
            {
                carte.Autor = autor;

            }
            String editura = textEditura.Text;

            if (String.IsNullOrEmpty(editura) ||
                String.IsNullOrWhiteSpace(editura) ||
                editura.Length < 2)
                valid = false;
            else
                carte.Editura = textEditura.Text;
            try
            {
                int an = int.Parse(textAnAparitie.Text);
                if (an < 1000 || an > DateTime.Now.Year)
                {
                    valid = false;

                }
                else
                    carte.AnAparitie = int.Parse(textAnAparitie.Text);
            }
            catch (Exception ex)
            {
                valid = false;
            }




            if (valid == true)
            {
                MessageBox.Show("Modificarile dorite au fost salvate");
                const string queryString = "UPDATE carti SET titlul=?,autor=?,editura=?,an_aparitie=? WHERE cod_carte=?";

                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();

                    OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                    sqlCommand.Parameters.Add("titlul", carte.Titlul);
                    sqlCommand.Parameters.Add("autor", carte.Autor);
                    sqlCommand.Parameters.Add("editura", carte.Editura);
                    sqlCommand.Parameters.Add("an_aparitie", carte.AnAparitie);
                    sqlCommand.Parameters.AddWithValue("id_produs", carte.CodCarte);


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
        //butonul de salvare
        private void btnAdaugaCartea_Click(object sender, EventArgs e)
        {
            modifica();
        }

        #region validari

        private void textTitlul_Validated(object sender, EventArgs e)
        {
            epTitlul.Clear();

        }

        private void textTitlul_Validating(object sender, CancelEventArgs e)
        {
            String titlul = textTitlul.Text;

            if (String.IsNullOrEmpty(titlul) ||
                String.IsNullOrWhiteSpace(titlul) ||
                titlul.Length < 2)
            {

                epTitlul.SetError((Control)sender, "Titlul trebuie sa aiba minim 2 caractere!");
                e.Cancel = true;
            }
        
    }

        private void textAutor_Validated(object sender, EventArgs e)
        {
            epAutor.Clear();
        }

        private void textAutor_Validating(object sender, CancelEventArgs e)
        {
            String autor = textAutor.Text;

            if (String.IsNullOrEmpty(autor) ||
                String.IsNullOrWhiteSpace(autor) ||
                autor.Length < 2)
            {

                epTitlul.SetError((Control)sender, "Denumirea autorului trebuie sa aiba minim 2 caractere!");
                e.Cancel = true;
            }
        }

        private void textEditura_Validated(object sender, EventArgs e)
        {
            epEditura.Clear();
        }

        private void textEditura_Validating(object sender, CancelEventArgs e)
        {
            String editura = textEditura.Text;

            if (String.IsNullOrEmpty(editura) ||
                String.IsNullOrWhiteSpace(editura) ||
                editura.Length < 2)
            {

                epTitlul.SetError((Control)sender, "Denumirea editurii trebuie sa aiba minim 2 caractere!");
                e.Cancel = true;
            }
        }

        private void textAnAparitie_Validated(object sender, EventArgs e)
        {
            epAn.Clear();
        }

        private void textAnAparitie_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int an = int.Parse(textAnAparitie.Text);
                if (an < 1000 || an > DateTime.Now.Year)
                {
                    epAn.SetError((Control)sender, "An invalid!");
                    e.Cancel = true;

                }
            }
            catch (Exception ex)
            {
                epAn.SetError((Control)sender, "Introduceti cifre!");
                e.Cancel = true;
            }
        }

        #endregion

        //ma asigur ca anul are doar cifre--se pot tasta doar cifre
        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

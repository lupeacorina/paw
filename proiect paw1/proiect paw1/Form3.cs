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
    public partial class Form3 : Form
    {
        private const string ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =\"baza_de_date.mdb\";Persist Security Info=True";
        List<Cititor> cititori = new List<Cititor>();
        Cititor cit_im= new Cititor();
        Cititor ci;
        public Form3(Cititor cititor_imprumut)
        {
           cit_im = cititor_imprumut;
            InitializeComponent();
             
        }
       
      //curatare
        private void CurataFormular()
        {
            textNume.Clear();
            textPrenume.Clear();
            textEmail.Clear();
            textTelefon.Clear();
            textAdresa.Clear();
            dateTimePicker1.Value = DateTime.Now;

        }
        //stergera cititorlui din baza de date
        public void DeleteCititor(Cititor cititor)
        {
            const string queryString = "DELETE FROM cititor WHERE cod=@id";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                var idParameter = new OleDbParameter("@id", cititor.CodCititor);
                sqlCommand.Parameters.Add(idParameter);

                sqlCommand.ExecuteNonQuery();

            }
        }
        //populare listView cu lista tuturor cititorilor
        private void populeazaListView()
        {
            listView1.Items.Clear();
            foreach (Cititor c in cititori)
            {
                ListViewItem lvi = new ListViewItem(new String[] { c.Nume,
                        c.Prenume, c.Email,c.Adresa,c.NrTelefon,c.DataNasterii.Date.ToString("dd/MM/yyyy") });

                lvi.Tag = c;

                listView1.Items.Add(lvi);

            }
        }




        #region adaugare
        private void btnAdaugaCartea_Click_1(object sender, EventArgs e)
        {
            bool valid = true;
            Cititor c = new Cititor();
            String nume = textNume.Text;

            if (String.IsNullOrEmpty(nume) ||
                String.IsNullOrWhiteSpace(nume) ||
                nume.Length < 2)
                valid = false;
            else c.Nume = textNume.Text;
            String prenume = textPrenume.Text;
            if (String.IsNullOrEmpty(prenume) ||
              String.IsNullOrWhiteSpace(prenume) ||
              prenume.Length < 2)
                valid = false;
            else
            {
                c.Prenume = prenume;

            }
            String adresa = textAdresa.Text;

            if (String.IsNullOrEmpty(adresa) ||
                String.IsNullOrWhiteSpace(adresa) ||
                adresa.Length < 2)
                valid = false;
            else
                c.Adresa = textAdresa.Text;


            String telefon = textTelefon.Text;

            if (String.IsNullOrEmpty(telefon) ||
                String.IsNullOrWhiteSpace(telefon) ||
                telefon.Length != 10 || telefon.Contains("07") != true)
                valid = false;
            else
            c.NrTelefon= textTelefon.Text;
            String email = textEmail.Text;

            if (String.IsNullOrEmpty(email) ||
                String.IsNullOrWhiteSpace(email) ||
                email.Length < 2 || email.Contains("@") != true || email.Contains(".") != true)
                valid = false;
            else c.Email= textEmail.Text;

            DateTime dataNasterii = dateTimePicker1.Value;
            DateTime data = dataNasterii.AddYears(12);
            if (DateTime.Compare(data, DateTime.Now) > 0)
                valid = false;
            else c.DataNasterii = dataNasterii;

                if (valid == true)
            {
                try
                {
                    //cititori.Add(c);
                    AddCititor(c);
                    populeazaListView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                CurataFormular();

                MessageBox.Show("Instanta creata!", "Succes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Formularul contine erori!", "Eroare",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
        public void AddCititor(Cititor cititor)
        {
            var queryString = "insert into cititor(nume, prenume,adresa,nr_telefon,email,data_nasterii)" +
                                  " values(@nume,@prenume,@adresa,@nr_telefon,@email,@data_nasterii);";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                var insertCommand = new OleDbCommand(queryString, connection);

                var numeParameter = new OleDbParameter("@nume", cititor.Nume);
                var prenumeParameter = new OleDbParameter("@prenume", cititor.Prenume);
                var adresaParameter = new OleDbParameter("@adresa", cititor.Adresa);
                var telefonParameter = new OleDbParameter("@nr_telefon", cititor.NrTelefon);
                var emailParameter = new OleDbParameter("@email", cititor.Email);
                var dataParameter = new OleDbParameter("@data_nasterii", cititor.DataNasterii);
                insertCommand.Parameters.Add(numeParameter);
                insertCommand.Parameters.Add(prenumeParameter);
                insertCommand.Parameters.Add(adresaParameter);
                insertCommand.Parameters.Add(telefonParameter);
                insertCommand.Parameters.Add(emailParameter);
                insertCommand.Parameters.Add(dataParameter);
                insertCommand.ExecuteNonQuery();

                var getIdCommand = new OleDbCommand("SELECT @@Identity;", connection);
                cititor.CodCititor = (int)getIdCommand.ExecuteScalar();


                cititori.Add(cititor);
            }
        }
        #endregion
        //citirea cititorilor din bd
        public void LoadCititori()
        {
            cititori.Clear();
            const string queryString = "SELECT * FROM cititor";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                OleDbDataReader sqlReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        var cititor = new Cititor(
                            (int)sqlReader["cod"],
                            (string)sqlReader["nume"],
                            (string)sqlReader["prenume"],
                            (string)sqlReader["adresa"],
                            (DateTime)sqlReader["data_nasterii"],
                            
                             (string)sqlReader["nr_telefon"],
                             (string)sqlReader["email"]
                            );
                        if(cit_im.CodCititor!=cititor.CodCititor)
                        cititori.Add(cititor);
                    }
                }
                finally
                {
                    sqlReader.Close();
                }
            }
        }

        private void btnCurata_Click_1(object sender, EventArgs e)
        {
            CurataFormular();

        }
        //editare cititor
        private void editeazaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                Cititor c = cititori.ElementAt(listView1.SelectedIndices[0]);

                Form4 editare = new Form4(c);
                DialogResult dialogResult = editare.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {

                   populeazaListView();
                }
            }

        }
        //stergere cititor
        private void stergeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Doresti sa stergi aceasta instanta?",
                     "Stergere cartea", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question))
                {


                    Cititor c = listView1.SelectedItems[0].Tag as Cititor;
                    try
                    {
                        DeleteCititor((Cititor)listView1.SelectedItems[0].Tag);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    cititori.Remove(c);


                    populeazaListView();
                }
            }
        }
        //salvare
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(cit_im.Prenume);
            cit_im.DataNasterii = ci.DataNasterii;
            cit_im.CodCititor = ci.CodCititor;
            cit_im.Adresa = ci.Adresa;
            cit_im.Email = ci.Email;
            cit_im.NrTelefon = ci.NrTelefon;
            cit_im.Nume = ci.Nume;
            cit_im.Prenume = ci.Prenume;

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
                email.Length < 2||email.Contains("@")!=true||email.Contains(".")!=true)
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
                telefon.Length !=10||telefon.Contains("07")!=true)
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

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadCititori();
            richTextBox1.Text = cit_im.Nume+" "+cit_im.Prenume;
            populeazaListView();

        }
        // folosesc clipboard ptr a alege cititorul imrumutului

        private void copiereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ci = (Cititor)listView1.SelectedItems[0].Tag;
          
            Clipboard.SetText(listView1.SelectedItems[0].SubItems[0].Text+" "+ listView1.SelectedItems[0].SubItems[1].Text);
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void lipesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Clipboard.GetText();
           
        }
        //pot tasta doar cifre ptr nr de tel
        private void textTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //buton de renuntare
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
           

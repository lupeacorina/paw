using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using proiect_paw1.Module;

namespace proiect_paw1
{
    public partial class FormAdaugaCarte : Form
    {
        private const string ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =\"baza_de_date.mdb\";Persist Security Info=True";
        public List<Carte> carti = new List<Carte>();
        bool move_item;
        public List<Carte> carti_comanda = new List<Carte>();
        public List<Carte> carti_imprumut = null;


        public FormAdaugaCarte(List<Carte> cc)
        {
            carti_imprumut = cc;
            foreach (Carte c in carti_imprumut)
                carti_comanda.Add(c);
            InitializeComponent();
        }
        #region adauga
        private void btnAdaugaCartea_Click(object sender, EventArgs e)
        {
            bool valid = true;
            Carte c = new Carte();
            String titlul = textTitlul.Text;

            if (String.IsNullOrEmpty(titlul) ||
                String.IsNullOrWhiteSpace(titlul) ||
                titlul.Length < 2)
                valid = false;
               else  c.Titlul = textTitlul.Text;
            String autor = textAutor.Text;
            if (String.IsNullOrEmpty(autor) ||
              String.IsNullOrWhiteSpace(autor) ||
              autor.Length < 2)
                valid = false;
            else
            {
                c.Autor = autor;
           
            }
            String editura = textEditura.Text;

            if (String.IsNullOrEmpty(editura) ||
                String.IsNullOrWhiteSpace(editura) ||
                editura.Length < 2)
                valid = false;
            else
                c.Editura = textEditura.Text;
            try
            {
                int an = int.Parse(textAnAparitie.Text);
                if (an < 1000 || an > DateTime.Now.Year)
                {
                    valid = false;

                }
                else
                    c.AnAparitie = int.Parse(textAnAparitie.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }




            if (valid == true)
            {
                try
                {
                    AddCarte(c);
                    //DisplayCarti();
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

        public void AddCarte(Carte carte)
        {
            var queryString = "insert into carti(titlul, autor,editura,an_aparitie)" +
                                  " values(@titlul,@autor,@editura,@an_aparitie);";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                var insertCommand = new OleDbCommand(queryString, connection);

                var titlulParameter = new OleDbParameter("@titlul", carte.Titlul);
                var autorParameter = new OleDbParameter("@autor", carte.Autor);
                var edituraParameter = new OleDbParameter("@editura", carte.Editura);
                var anParameter = new OleDbParameter("@an_aparitie", carte.AnAparitie);
                insertCommand.Parameters.Add(titlulParameter);
                insertCommand.Parameters.Add(autorParameter);
                insertCommand.Parameters.Add(edituraParameter);
                insertCommand.Parameters.Add(anParameter);
                insertCommand.ExecuteNonQuery();

                var getIdCommand = new OleDbCommand("SELECT @@Identity;", connection);
                carte.CodCarte = (int)getIdCommand.ExecuteScalar();

                //4. Add the new participant to the local collection
                carti.Add(carte);
            }
        }
        #endregion

        #region curatare
        private void btnCurata_Click(object sender, EventArgs e)
        {
            CurataFormular();
        }
        private void CurataFormular()
        {
            textAnAparitie.Clear();
            textAutor.Clear();
            textEditura.Clear();
            textTitlul.Clear();

        }

        #endregion
        //populare listView1 cu lista tuturor cartilor
        private void populeazaListView()
        {
            listView1.Items.Clear();
            foreach(Carte c in carti)
            {
                ListViewItem lvi = new ListViewItem(new String[] { c.Titlul,
                        c.Autor, c.Editura,c.AnAparitie.ToString() });

                lvi.Tag = c;

                listView1.Items.Add(lvi);

            }
        }
        //citire carti din bd
        public void LoadCarti()
        {
            carti.Clear();
            const string queryString = "SELECT * FROM carti";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                OleDbDataReader sqlReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        var carte = new Carte(
                            (int)sqlReader["cod_carte"],
                            (string)sqlReader["titlul"],
                            (string)sqlReader["autor"],
                            (string)sqlReader["editura"],
                            (int)sqlReader["an_aparitie"]);
                        int ok=1;
                        foreach (Carte c in carti_comanda)
                            if (c.CodCarte == carte.CodCarte) ok = 0;
                        if(ok==1)
                        carti.Add(carte);
                    }
                }
                finally
                {
                    sqlReader.Close();
                }
            }
        }
        //editeaza carte
        private void editeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                Carte c = carti.ElementAt(listView1.SelectedIndices[0]);
                Form2 editare = new Form2(c);
                DialogResult dialogResult = editare.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    populeazaListView();
                }
            }

        }
        //stegere carte din bd
        public void DeleteCarte(Carte carte)
        {
            const string queryString = "DELETE FROM carti WHERE cod_carte=@id";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                var idParameter = new OleDbParameter("@id", carte.CodCarte);
                sqlCommand.Parameters.Add(idParameter);

                sqlCommand.ExecuteNonQuery();

            }
        }
        //stergere carte din lista tuturor cartilor
        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Doresti sa stergi aceasta instanta?",
                     "Stergere cartea", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question))
                {
                    

                    Carte c = listView1.SelectedItems[0].Tag as Carte;
                    try
                    {
                        DeleteCarte((Carte)listView1.SelectedItems[0].Tag);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    carti.Remove(c);
                    populeazaListView();
                }
            }
            else
            {
                MessageBox.Show("Alege o carte");
            }

        }
        //populare listView2 cu cartile continute deja de imprumut
        private void populeaza_lv2()
        {
            listView2.Items.Clear();
            foreach (Carte c in carti_comanda)
            {
                ListViewItem lvi = new ListViewItem(new String[] { c.Titlul,
                        c.Autor, c.Editura,c.AnAparitie.ToString() });

                lvi.Tag = c;

                listView2.Items.Add(lvi);

            }
        }
        //butonul de salvare
        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(carti_comanda.Count);

            foreach(Carte c in carti_comanda)
            {
                int ok = 0;
                foreach (Carte c2 in carti_imprumut)
                
                    if (c.CodCarte == c2.CodCarte)
                        ok = 1;
                    if (ok == 0)
                        carti_imprumut.Add(c);
                

                
            }
            List<Carte> carte_nou = new List<Carte>();
            foreach (Carte cn in carti_imprumut)
                carte_nou.Add(cn);

            foreach (Carte c in carte_nou)
            {
                int ok = 0;
                foreach (Carte c2 in carti_comanda)
                
                    if (c.CodCarte == c2.CodCarte)
                        ok = 1;
                    if (ok == 0)
                        carti_imprumut.Remove(c);
                


            }
            //carti_imprumut = carti_comanda;
            Console.WriteLine(carti_imprumut.Count);
            this.Close();
        }

        private void FormAdaugaCarte_Load(object sender, EventArgs e)
        {
            populeazaListView();
            populeaza_lv2();
            listView2.DragDrop += new DragEventHandler(listView2_DragDrop);
            listView1.DragEnter += new DragEventHandler(listView1_DragEnter);
        }
        #region validari
        private void textAnAparitie_Validated(object sender, EventArgs e)
        {
            epAn.Clear();
        }

        private void textAnAparitie_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int an = int.Parse(textAnAparitie.Text);
                if(an<1000||an>DateTime.Now.Year)
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

        #endregion

        #region serializare/deserializare_binara
        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            FileStream stream = new FileStream("binary.dat", FileMode.Create);
            binaryFormatter.Serialize(stream, carti);
            MessageBox.Show("Fisierul binary. dat salvat cu succes");
            stream.Close();

        }

        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecteaza fisierul binar pentru deserializare";
            ofd.Filter = "Text files (*.txt)|*.txt|Binary files (*.dat)|*.dat|All files (*.*)|*.*";
            ofd.FilterIndex = 2;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = File.OpenRead(ofd.FileName);

                carti = binaryFormatter.Deserialize(fileStream) as List<Carte>;

                fileStream.Close();
                populeazaListView();

            }

        }

        #endregion
        #region export_fisier_text
        private void scriereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.Title = "Selecteaza fisierul ";
            sfg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            sfg.FilterIndex = 1;
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(sfg.FileName);
                writer.Write("Titlul Autorul Editura Anul aparitiei" +"\n");
                foreach (Carte c in carti)
                {
                    writer.WriteLine(c.Titlul + "\t" + c.Autor + "\t" + c.Editura+ "\t" + c.AnAparitie);

                }
                writer.Close();

            }

        }
        #endregion
        //citire din baza de date si populare listView
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadCarti();
            populeazaListView();
        }
        //adaug carti in lista imprumutului cu drag/drop din lista tuturor cartilor 
        #region drag-drop
        void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void listView2_DragDrop(object sender, DragEventArgs e)
        {
            var items = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));
            
            // move to dest LV
            foreach (ListViewItem lvi in items)
            {
                // LVI obj can only belong to one LVI, remove
                lvi.ListView.Items.Remove(lvi);
                listView2.Items.Add(lvi);
                //Console.WriteLine(lvi.Text);
            }
           // Carte ca = new Carte(items[0].Text, items[1].Text, items[2].Text, int.Parse(items[3].Text));
           // carti_comanda.Add(ca);
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {

            move_item = true;
        }

     

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
     
            var items = new List<ListViewItem>();
     
            items.Add((ListViewItem)e.Item);
            carti_comanda.Add(listView1.SelectedItems[0].Tag as Carte);
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                if (!items.Contains(lvi))
                {
                    items.Add(lvi);
                }
            }
            // pass the items to move...
            listView1.DoDragDrop(items, DragDropEffects.Move);
        }

        private void listView2_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                e.Effect = DragDropEffects.Move;
                
            }
        }
        #endregion
        //elimina cartea din lista de carti ale imprumutului pe care vreau sa il adaug/editez
        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Doresti sa stergi aceasta instanta?",
                     "Stergere cartea", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question))
                {


                    Carte c = listView2.SelectedItems[0].Tag as Carte;
                    carti_comanda.Remove((Carte)listView2.SelectedItems[0].Tag);
                    listView2.SelectedItems[0].Remove();
                  
                    try
                    {
                        //DeleteCarte1((Carte)listView2.SelectedItems[0].Tag);
                        //carti_comanda.Remove((Carte)listView2.SelectedItems[0].Tag);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Alege o carte");
            }
        }
        //serializare dezerializare XML
        #region serializare/deserializare_XML
        private void serializareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Carte>));

            FileStream stream = File.Create("lista.xml");
            serializer.Serialize(stream, carti);

            stream.Close();
            MessageBox.Show("Fisierul lista.xml salvat cu succes");
        }

        private void deserializareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Carte>));

            try
            {
                FileStream stream = File.OpenRead("lista.xml");
                carti = serializer.Deserialize(stream) as List<Carte>;

                stream.Close();
                populeazaListView();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        //asigura introducera doar a cifrelor ptr an
        private void textAnAparitie_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //butonul de renunta
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proiect_paw1.Module;

namespace proiect_paw1
{ 
    public partial class Form6 : Form
    {
        private const string ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =\"baza_de_date.mdb\";Persist Security Info=True";
        List<Imprumut> imprumuturi = new List<Imprumut>();
        Imprumut i = new Imprumut();
        List<Carte> carti = new List<Carte>();
        Cititor cititor = new Cititor();
    

        public Form6()
        {
            InitializeComponent();
        }
        //Load-populeaza ListView-ul cu imprumuturile citite din baza de date si afiseaza nr de imprumuturi prin statusStrip
        private void Form6_Load(object sender, EventArgs e)
        {
            i.DataImprumutului = DateTime.Today;
            LoadImprumuturi();
            populeaza();
            toolStripStatusLabel1.Text = "Numar imprumuturi: "+imprumuturi.Count().ToString();


        }



        //butonul de adugare/editare care actulaizeaza si statusStrip
        private void button3_Click(object sender, EventArgs e)
        {
            if (i.CodImprumut == 0)
                insereazaImprumut();
            else
                updateImprumut();


            toolStripStatusLabel1.Text = "Numar imprumuturi: " + imprumuturi.Count().ToString();


        }
        #region inserare_imprumut_nou
        //inserare imprumut nou cu standard exception- inserez data, cititorul si id-ul se insereaza automat
        
        public int AddImprumut(Imprumut c)
        {
            var queryString = "insert into imprumuturi(cod_cititor,data)" +
                                  " values(@id_cititor,@data);";


            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                //1. Open the connection
                connection.Open();

                //2. Add the new participant to the database
                var insertCommand = new OleDbCommand(queryString, connection);

    
                 var id_cit = new OleDbParameter("@id_cititor", cititor.CodCititor);
                var data_plasarii = new OleDbParameter("@data", c.DataImprumutului.Date);
                try
                {
                    insertCommand.Parameters.Add(id_cit);
                    insertCommand.Parameters.Add(data_plasarii);
                    insertCommand.ExecuteNonQuery();
                    //3. Get the Id
                var getIdCommand = new OleDbCommand("SELECT @@Identity;", connection);
                c.CodImprumut=((int)getIdCommand.ExecuteScalar());
                    return 1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }



                

                
               

            }

        }
        //inserarea cartii in rand_imprumuturi ptr un imprumut nou
        private void AddRand(Imprumut c, Carte p)
        {
            var queryString1 = "insert into rand_imprumuturi(cod_imprumut, cod_carte)" +
                                     " values(@id_imprumut,@id_carte);";
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();
                var insertCommand1 = new OleDbCommand(queryString1, connection);

                var id_imp = new OleDbParameter("@id_imprumut", c.CodImprumut);

                {
                    var id_car = new OleDbParameter("@id_carte", p.CodCarte);
       

                    insertCommand1.Parameters.Add(id_imp);
                    insertCommand1.Parameters.Add(id_car);

                }


                insertCommand1.ExecuteNonQuery();

            }
        }
       
        //inserare imprumut nou
        private void insereazaImprumut()
        {
            try
            {
                i.DataImprumutului = dateTimePicker1.Value;
                
            }
            catch (InvalidDateException ex)
            {
                //Expected exception
                MessageBox.Show(string.Format("Data imprumutului {0} este invalida!", ex.Data));
            }
             int ok=AddImprumut(i);
            foreach (Carte p in carti)
               AddRand(i, p);
            i.cititor = cititor;
            i.carti = carti;
            if(ok==1)
            imprumuturi.Add(i);
            populeaza();

            i = new Imprumut();
            carti = new List<Carte>();
            cititor = new Cititor();
            curata();
        }
        #endregion
        //curatare
        private void curata()
        {
            richTextBox1.Clear();

            populeazaListBox();
            dateTimePicker1.Value = DateTime.Now;
        }
        //stergere carte din rand_imprumuturi
        #region update_imprumut
        public void DeleteCarte(int id_imprumut, int id_carte)
        {

            const string queryString = "DELETE FROM rand_imprumuturi WHERE cod_imprumut=? AND cod_carte=?";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                //Remove from the database
                connection.Open();

                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                sqlCommand.Parameters.Add("cod_imprumut", id_imprumut);
                sqlCommand.Parameters.Add("cod_carte", id_carte);
                sqlCommand.ExecuteNonQuery();

                //Remove from the local copy


            }

        }
        //inserare carte in rand_imprumuturi pentru un imprumut existent
        private void InsertCarte(int id_imprumut, int id_carte)
        {
            var queryString1 = "insert into rand_imprumuturi(cod_imprumut, cod_carte)" +
                                     " values(@id_comanda,@id_produs);";
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();
                var insertCommand1 = new OleDbCommand(queryString1, connection);

                var id_imp = new OleDbParameter("@id_comanda", id_imprumut);

                {
                    var id_car = new OleDbParameter("@id_produs", id_carte);


                    insertCommand1.Parameters.Add(id_imp);
                    insertCommand1.Parameters.Add(id_car);

                }


                insertCommand1.ExecuteNonQuery();

            }
        }
        //actualizarea datei si a cititolui
        private void UpdateDC(int id_imprumut)
        {
            DateTime data = dateTimePicker1.Value;
            const string queryString = "UPDATE imprumuturi SET cod_cititor=? WHERE cod_imprumut=?";
            const string queryString1 = "UPDATE imprumuturi SET data=? WHERE cod_imprumut=?";
            if (id_imprumut != 0)
            {
                Console.WriteLine(cititor.CodCititor);
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();

                    OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);

                    sqlCommand.Parameters.Add("cod_cititor", cititor.CodCititor);
                    sqlCommand.Parameters.AddWithValue("cod_imprumut", id_imprumut);


                    sqlCommand.ExecuteNonQuery();

                }
            }
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                OleDbCommand sqlCommand1 = new OleDbCommand(queryString1, connection);

                sqlCommand1.Parameters.Add("data", data);
                sqlCommand1.Parameters.AddWithValue("cod_imprumut", id_imprumut);


                sqlCommand1.ExecuteNonQuery();

            }
            MessageBox.Show("Modificările au fost salvate!");

            
        }
        //update cu custom exception ptr data imprumutului
        private void updateImprumut()
        {
            List<Carte> carte_nou = new List<Carte>();
            foreach (Carte cn in i.carti)
                carte_nou.Add(cn);
            foreach (Carte c1 in carte_nou)
            {
                int ok = 0;
                foreach(Carte c2 in carti)
                {
                    if (c1.CodCarte == c2.CodCarte)
                        ok = 1;
                }
                if (ok == 0)
                {
                    DeleteCarte(i.CodImprumut, c1.CodCarte);
                    i.carti.Remove(c1);
                    
                }
               
            }
           // populeaza();
            foreach (Carte c1 in carti)
            {
                int ok = 0;
                foreach (Carte c2 in i.carti)
                {
                    if (c1.CodCarte == c2.CodCarte)
                        ok = 1;
                }
                if (ok == 0)
                {
                    InsertCarte(i.CodImprumut, c1.CodCarte);
                    i.carti.Add(c1);
                   
                }

            }
            // populeaza();
            try
            { i.DataImprumutului = dateTimePicker1.Value;UpdateDC(i.CodImprumut); }
            catch (InvalidDateException ex)
            {
                //Expected exception
                MessageBox.Show(string.Format("Data imprumutului {0} este invalida!", ex.Data));
            }
            i.cititor = cititor;
            populeaza();

            i = new Imprumut();
            carti = new List<Carte>();
            cititor = new Cititor();
            curata();


        }
        #endregion
        //populare listBox cu titlurile cartilor dintr-un imprumut
        private void populeazaListBox()
        {
            //listBox1.Items.Clear;
            String[] denumiri = new String[carti.Count];
            int index = 0;
            foreach (Carte c in carti)
            {
                // Items.Add nu e un exemplu de data binding
                // listBoxProgramatori.Items.Add(p.Denumire);

                denumiri[index] = c.Titlul;
                index++;
            }

            listBox1.DataSource = denumiri;
        }
        //adauga sau editeaza un cititor
        private void button1_Click(object sender, EventArgs e)
        {
            FormAdaugaCarte cartii = new FormAdaugaCarte(carti);
            if (cartii.ShowDialog() == DialogResult.OK)
            {
                populeazaListBox();
               
            }
        }
        //adauga sau sterge niste carti dintr-un imprumut
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 cititorul = new Form3(cititor);
            if (cititorul.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(cititor.Nume);
                richTextBox1.Text = cititor.Nume + " " + cititor.Prenume;
            }

        }
        //poupuleaza cu valorile imprumutului ales
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            curata();
            i = (Imprumut)listView1.SelectedItems[0].Tag;
            carti = new List<Carte>();
            foreach (Carte c in i.carti)
                carti.Add(c);
            populeazaListBox();
            dateTimePicker1.Value = i.DataImprumutului;
            Console.WriteLine(i.cititor.CodCititor);
            cititor= new Cititor (i.cititor.CodCititor,i.cititor.Nume,i.cititor.Prenume,i.cititor.Adresa,i.cititor.DataNasterii,i.cititor.NrTelefon,i.cititor.Email);

            richTextBox1.Text = i.cititor.Nume + " " + i.cititor.Prenume;
           
        }
        
        //citirea imprumuturilor din baza de date
		public void LoadImprumuturi()
		{

            const string queryString = "SELECT * FROM imprumuturi";
            const string queryString1 = "SELECT * FROM cititor";
            const string queryString4 = "SELECT * FROM carti";
            const string queryString3 = "SELECT * FROM rand_imprumuturi";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);

                OleDbDataReader sqlReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        var impr = new Imprumut();
                        impr.CodImprumut=((int)sqlReader["cod_imprumut"]);
                        impr.DataImprumutului=((DateTime)sqlReader["data"]);
                        int cod = ((int)sqlReader["cod_cititor"]);
     
                        OleDbCommand sqlCommand1 = new OleDbCommand(queryString1, connection);
                        OleDbDataReader sqlReader1 = sqlCommand1.ExecuteReader();
                        try
                        {
                            while (sqlReader1.Read())
                            {
                                Cititor m = new Cititor();
                                if ((int)sqlReader1["cod"] == cod)
                                {
                                    m.Adresa = (String)sqlReader1["adresa"];
                                    m.Nume = (String)sqlReader1["nume"];
                                    m.Prenume = (String)(sqlReader1["prenume"]);
                                    m.Email = (String)sqlReader1["email"];
                                    m.NrTelefon = (String)sqlReader1["nr_telefon"];
                                    m.DataNasterii = (DateTime)sqlReader1["data_nasterii"];
                                    m.CodCititor = cod;
                                    impr.cititor = m;
                                }

                                   
                                

                            }


                        }
                        finally
                        {
                            sqlReader1.Close();
                        }
                        OleDbCommand sqlCommand3 = new OleDbCommand(queryString3, connection);
                        OleDbDataReader sqlReader3 = sqlCommand3.ExecuteReader();
                        try
                        {
                            while (sqlReader3.Read())
                            {
                                if (impr.CodImprumut == (int)sqlReader3["cod_imprumut"])
                                {
                                    int cod_carte = (int)sqlReader3["cod_carte"];
                                    OleDbCommand sqlCommand4 = new OleDbCommand(queryString4, connection);
                                    OleDbDataReader sqlReader4 = sqlCommand4.ExecuteReader();
                                    try
                                    {
                                        while (sqlReader4.Read())
                                        {
                                            Carte p = new Carte();
                                            if (cod_carte == (int)sqlReader4["cod_carte"])
                                            {
                                                p.CodCarte=((int)sqlReader4["cod_carte"]);
                                                p.Titlul=((String)sqlReader4["titlul"]);
                                                p.Autor = ((String)sqlReader4["autor"]);
                                                p.Editura = ((String)sqlReader4["editura"]);
                                                p.AnAparitie = ((int)sqlReader4["an_aparitie"]);impr.carti.Add(p);
                                            }

                                            
                                        }


                                    }
                                    finally
                                    {
                                        sqlReader4.Close();
                                    }

                                }

                            }


                        }
                        finally
                        {
                            sqlReader3.Close();
                        }

                        imprumuturi.Add(impr);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    sqlReader.Close();
                }
            }
        }
        //stergerea unui imprumut
        public void DeleteImprumut(Imprumut comanda)
        {
            const string queryString = "DELETE FROM imprumuturi WHERE cod_imprumut=@id";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                //Remove from the database
                connection.Open();

                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                var idParameter = new OleDbParameter("@id", comanda.CodImprumut);
                sqlCommand.Parameters.Add(idParameter);

                sqlCommand.ExecuteNonQuery();

                //Remove from the local copy
                imprumuturi.Remove(comanda);
            }
        }
        //populare listView
        private void populeaza()
        {
            listView1.Items.Clear();
            float s = 0;
            foreach (Imprumut comanda in imprumuturi)
            {

                var listViewItem = new ListViewItem(comanda.DataImprumutului.ToString("dd/MM/yyyy"));
                DateTime data = comanda.DataImprumutului;
                data = data.AddDays(30);
                listViewItem.SubItems.Add(data.ToString("dd/MM/yyyy"));
                String citi = comanda.cititor.Nume + " " + comanda.cititor.Prenume;
                listViewItem.SubItems.Add(citi);
                int nr = comanda.carti.Count();
                listViewItem.SubItems.Add(nr.ToString());

                listViewItem.Tag = comanda;

                listView1.Items.Add(listViewItem);

            }

        }

        //bunonul de renuntare--curata tot si seteaza i cu null si lista de carti ca fiind goala
        private void button4_Click(object sender, EventArgs e)
        {
            i = new Imprumut();
            carti = new List<Carte>();
            cititor = new Cititor();
            curata();
        }
        //printare
        #region printare
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.PageSettings = printDocument1.DefaultPageSettings;

            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Consolas", 20);
            Brush brush = Brushes.RoyalBlue;
            Pen pen = new Pen(brush);

            PageSettings settings = printDocument1.DefaultPageSettings;

            var totalDrawableW = settings.PaperSize.Width - settings.Margins.Left - settings.Margins.Right;
            var totalDrawableH = settings.PaperSize.Height - settings.Margins.Top - settings.Margins.Bottom;

            if (settings.Landscape)
            {
                var temp = totalDrawableW;
                totalDrawableW = totalDrawableH;
                totalDrawableH = temp;
            }

            int cellWidth = totalDrawableW / 3;
            int cellHeight = 40;

            int x = settings.Margins.Left;
            int y = 100;

            graphics.DrawString("Lista imprumuturi", font, brush, totalDrawableW / 3, y);

            y += 100;

            // desenare format cap de tabel
            graphics.DrawRectangle(pen, x, y, cellWidth, cellHeight);
            graphics.DrawRectangle(pen, x + cellWidth, y, cellWidth, cellHeight);
            graphics.DrawRectangle(pen, x + cellWidth*2, y, cellWidth, cellHeight);

            // desenare continut cap de tabel
            graphics.DrawString("Cititor", font, brush, x, y);
            graphics.DrawString("Nr. carti", font, brush, x + cellWidth, y);
            graphics.DrawString("Data", font, brush, x + cellWidth*2, y);

            y += cellHeight;

            foreach (Imprumut d in imprumuturi)
            {
                // desenare celule
                graphics.DrawRectangle(pen, x, y, cellWidth, cellHeight);
                graphics.DrawRectangle(pen, x + cellWidth, y, cellWidth, cellHeight);
                graphics.DrawRectangle(pen, x + cellWidth*2, y, cellWidth, cellHeight);

                // desenare continut celule
                graphics.DrawString(d.cititor.Nume+" "+d.cititor.Prenume, font, brush, x, y);
                graphics.DrawString(d.carti.Count().ToString(), font, brush, x + cellWidth, y);
                graphics.DrawString(d.DataImprumutului.ToString("dd/MM/yyyy"), font, brush, x + cellWidth*2, y);

                y += cellHeight;
            }
        }
        #endregion
        //realizare histograma
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int[] vector = new int[12];
            for (int k = 0; k < 12; k++)
                vector[k] = 0;
            foreach(Imprumut ii in imprumuturi)
            {if (ii.DataImprumutului.Year == DateTime.Now.Year-1)
                {
                    int m = ii.DataImprumutului.Month;
                    if (m == 1)
                        vector[0] += ii.carti.Count;
                    if (m == 2)
                        vector[1] += ii.carti.Count;
                    if (m == 3)
                        vector[2] += ii.carti.Count;
                    if (m == 4)
                        vector[3] += ii.carti.Count;
                    if (m == 5)
                        vector[4] += ii.carti.Count;
                    if (m == 5)
                        vector[5] += ii.carti.Count;
                    if (m == 7)
                        vector[6] += ii.carti.Count;
                    if (m == 8)
                        vector[7] += ii.carti.Count;
                    if (m == 9)
                        vector[8] += ii.carti.Count;
                    if (m == 10)
                        vector[9] += ii.carti.Count;
                    if (m == 11)
                        vector[10] += ii.carti.Count;
                    if (m == 12)
                        vector[11] += ii.carti.Count;
                }

            }
            Form5 desen = new Form5(vector);
            desen.ShowDialog();
        }
        //G+ctrl pentru histograma, P+ctrl pentru printare, D+ctrl pentru stregrea unui imprumut 
        #region accesori

        private void Form6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G && e.Control)
            {

                toolStripButton2_Click(sender, e);

            }
            else if (e.KeyCode == Keys.P && e.Control)
            {
                toolStripButton1_Click(sender, e);
            }
        }
        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Control)
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Alege un imprumut.");
                    return;
                }

                if (MessageBox.Show("Ești sigur că vrei să ștergi aceast imprumut?", "Șterge imprumut", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        DeleteImprumut((Imprumut)listView1.SelectedItems[0].Tag);
                        populeaza();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                toolStripStatusLabel1.Text = "Numar imprumuturi: " + imprumuturi.Count().ToString();
            }
        }
        #endregion

       
    }
}

namespace proiect_paw1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCurata = new System.Windows.Forms.Button();
            this.btnAdaugaCartea = new System.Windows.Forms.Button();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textAdresa = new System.Windows.Forms.TextBox();
            this.textPrenume = new System.Windows.Forms.TextBox();
            this.textNume = new System.Windows.Forms.TextBox();
            this.labelAnAparie = new System.Windows.Forms.Label();
            this.labelEditura = new System.Windows.Forms.Label();
            this.labelAutor = new System.Windows.Forms.Label();
            this.labelTitlul = new System.Windows.Forms.Label();
            this.textTelefon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editeazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.epNume = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPrenume = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAdresa = new System.Windows.Forms.ErrorProvider(this.components);
            this.epEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTelefon = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDataNasterii = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lipesteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epNume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrenume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAdresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDataNasterii)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCurata
            // 
            this.btnCurata.Location = new System.Drawing.Point(200, 316);
            this.btnCurata.Name = "btnCurata";
            this.btnCurata.Size = new System.Drawing.Size(140, 23);
            this.btnCurata.TabIndex = 23;
            this.btnCurata.Text = "Curata";
            this.btnCurata.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCurata.UseVisualStyleBackColor = true;
            this.btnCurata.Click += new System.EventHandler(this.btnCurata_Click_1);
            // 
            // btnAdaugaCartea
            // 
            this.btnAdaugaCartea.Location = new System.Drawing.Point(19, 316);
            this.btnAdaugaCartea.Name = "btnAdaugaCartea";
            this.btnAdaugaCartea.Size = new System.Drawing.Size(131, 23);
            this.btnAdaugaCartea.TabIndex = 22;
            this.btnAdaugaCartea.Text = "Adauga";
            this.btnAdaugaCartea.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdaugaCartea.UseVisualStyleBackColor = true;
            this.btnAdaugaCartea.Click += new System.EventHandler(this.btnAdaugaCartea_Click_1);
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(133, 181);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(221, 22);
            this.textEmail.TabIndex = 21;
            this.textEmail.Validating += new System.ComponentModel.CancelEventHandler(this.textEmail_Validating);
            this.textEmail.Validated += new System.EventHandler(this.textEmail_Validated);
            // 
            // textAdresa
            // 
            this.textAdresa.Location = new System.Drawing.Point(133, 135);
            this.textAdresa.Name = "textAdresa";
            this.textAdresa.Size = new System.Drawing.Size(221, 22);
            this.textAdresa.TabIndex = 20;
            this.textAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.textAdresa_Validating);
            this.textAdresa.Validated += new System.EventHandler(this.textAdresa_Validated);
            // 
            // textPrenume
            // 
            this.textPrenume.Location = new System.Drawing.Point(133, 88);
            this.textPrenume.Name = "textPrenume";
            this.textPrenume.Size = new System.Drawing.Size(221, 22);
            this.textPrenume.TabIndex = 19;
            this.textPrenume.Validating += new System.ComponentModel.CancelEventHandler(this.textPrenume_Validating);
            this.textPrenume.Validated += new System.EventHandler(this.textPrenume_Validated);
            // 
            // textNume
            // 
            this.textNume.Location = new System.Drawing.Point(133, 37);
            this.textNume.Name = "textNume";
            this.textNume.Size = new System.Drawing.Size(221, 22);
            this.textNume.TabIndex = 18;
            this.textNume.Validating += new System.ComponentModel.CancelEventHandler(this.textNume_Validating);
            this.textNume.Validated += new System.EventHandler(this.textNume_Validated);
            // 
            // labelAnAparie
            // 
            this.labelAnAparie.AutoSize = true;
            this.labelAnAparie.Location = new System.Drawing.Point(7, 181);
            this.labelAnAparie.Name = "labelAnAparie";
            this.labelAnAparie.Size = new System.Drawing.Size(51, 17);
            this.labelAnAparie.TabIndex = 17;
            this.labelAnAparie.Text = "E-mail:";
            // 
            // labelEditura
            // 
            this.labelEditura.AutoSize = true;
            this.labelEditura.Location = new System.Drawing.Point(7, 135);
            this.labelEditura.Name = "labelEditura";
            this.labelEditura.Size = new System.Drawing.Size(57, 17);
            this.labelEditura.TabIndex = 16;
            this.labelEditura.Text = "Adresa:";
            // 
            // labelAutor
            // 
            this.labelAutor.AutoSize = true;
            this.labelAutor.Location = new System.Drawing.Point(6, 88);
            this.labelAutor.Name = "labelAutor";
            this.labelAutor.Size = new System.Drawing.Size(69, 17);
            this.labelAutor.TabIndex = 15;
            this.labelAutor.Text = "Prenume:";
            // 
            // labelTitlul
            // 
            this.labelTitlul.AutoSize = true;
            this.labelTitlul.Location = new System.Drawing.Point(7, 37);
            this.labelTitlul.Name = "labelTitlul";
            this.labelTitlul.Size = new System.Drawing.Size(49, 17);
            this.labelTitlul.TabIndex = 14;
            this.labelTitlul.Text = "Nume:";
            // 
            // textTelefon
            // 
            this.textTelefon.Location = new System.Drawing.Point(133, 227);
            this.textTelefon.Name = "textTelefon";
            this.textTelefon.Size = new System.Drawing.Size(221, 22);
            this.textTelefon.TabIndex = 26;
            this.textTelefon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTelefon_KeyPress);
            this.textTelefon.Validating += new System.ComponentModel.CancelEventHandler(this.textTelefon_Validating);
            this.textTelefon.Validated += new System.EventHandler(this.textTelefon_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Data nasterii:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Numar de telefon:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(133, 277);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(221, 22);
            this.dateTimePicker1.TabIndex = 27;
            this.dateTimePicker1.Value = new System.DateTime(2021, 4, 27, 0, 0, 0, 0);
            this.dateTimePicker1.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePicker1_Validating);
            this.dateTimePicker1.Validated += new System.EventHandler(this.dateTimePicker1_Validated);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(402, 37);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(759, 297);
            this.listView1.TabIndex = 28;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nume";
            this.columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Prenume";
            this.columnHeader2.Width = 119;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "E-mail";
            this.columnHeader3.Width = 99;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Adresa";
            this.columnHeader4.Width = 215;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Numar de telefon";
            this.columnHeader5.Width = 119;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Data nasterii";
            this.columnHeader6.Width = 116;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editeazaToolStripMenuItem,
            this.stergeToolStripMenuItem,
            this.copiereToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(136, 76);
            // 
            // editeazaToolStripMenuItem
            // 
            this.editeazaToolStripMenuItem.Name = "editeazaToolStripMenuItem";
            this.editeazaToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.editeazaToolStripMenuItem.Text = "Editeaza";
            this.editeazaToolStripMenuItem.Click += new System.EventHandler(this.editeazaToolStripMenuItem_Click_1);
            // 
            // stergeToolStripMenuItem
            // 
            this.stergeToolStripMenuItem.Name = "stergeToolStripMenuItem";
            this.stergeToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.stergeToolStripMenuItem.Text = "Sterge";
            this.stergeToolStripMenuItem.Click += new System.EventHandler(this.stergeToolStripMenuItem_Click_1);
            // 
            // copiereToolStripMenuItem
            // 
            this.copiereToolStripMenuItem.Name = "copiereToolStripMenuItem";
            this.copiereToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.copiereToolStripMenuItem.Text = "Copiere";
            this.copiereToolStripMenuItem.Click += new System.EventHandler(this.copiereToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(638, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Salveaza";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // epNume
            // 
            this.epNume.ContainerControl = this;
            // 
            // epPrenume
            // 
            this.epPrenume.ContainerControl = this;
            // 
            // epAdresa
            // 
            this.epAdresa.ContainerControl = this;
            // 
            // epEmail
            // 
            this.epEmail.ContainerControl = this;
            // 
            // epTelefon
            // 
            this.epTelefon.ContainerControl = this;
            // 
            // epDataNasterii
            // 
            this.epDataNasterii.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTitlul);
            this.groupBox1.Controls.Add(this.labelAutor);
            this.groupBox1.Controls.Add(this.labelEditura);
            this.groupBox1.Controls.Add(this.labelAnAparie);
            this.groupBox1.Controls.Add(this.btnCurata);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.btnAdaugaCartea);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textTelefon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textNume);
            this.groupBox1.Controls.Add(this.textPrenume);
            this.groupBox1.Controls.Add(this.textEmail);
            this.groupBox1.Controls.Add(this.textAdresa);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 356);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adauga cititor nou";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Lista cititorilor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Numele cititorul:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip2;
            this.richTextBox1.Location = new System.Drawing.Point(556, 350);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(366, 25);
            this.richTextBox1.TabIndex = 34;
            this.richTextBox1.Text = "";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lipesteToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(126, 28);
            // 
            // lipesteToolStripMenuItem
            // 
            this.lipesteToolStripMenuItem.Name = "lipesteToolStripMenuItem";
            this.lipesteToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.lipesteToolStripMenuItem.Text = "Lipeste";
            this.lipesteToolStripMenuItem.Click += new System.EventHandler(this.lipesteToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(829, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "Renunta";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 450);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "Form3";
            this.Text = "Cititor";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epNume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrenume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAdresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDataNasterii)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCurata;
        private System.Windows.Forms.Button btnAdaugaCartea;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textAdresa;
        private System.Windows.Forms.TextBox textPrenume;
        private System.Windows.Forms.TextBox textNume;
        private System.Windows.Forms.Label labelAnAparie;
        private System.Windows.Forms.Label labelEditura;
        private System.Windows.Forms.Label labelAutor;
        private System.Windows.Forms.Label labelTitlul;
        private System.Windows.Forms.TextBox textTelefon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editeazaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergeToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider epNume;
        private System.Windows.Forms.ErrorProvider epPrenume;
        private System.Windows.Forms.ErrorProvider epAdresa;
        private System.Windows.Forms.ErrorProvider epEmail;
        private System.Windows.Forms.ErrorProvider epTelefon;
        private System.Windows.Forms.ErrorProvider epDataNasterii;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem copiereToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem lipesteToolStripMenuItem;
        private System.Windows.Forms.Button button2;
    }
}
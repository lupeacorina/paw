namespace proiect_paw1
{
    partial class Form4
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textTelefon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.epNume = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPrenume = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAdresa = new System.Windows.Forms.ErrorProvider(this.components);
            this.epEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTelefon = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDataNasterii = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epNume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrenume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAdresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDataNasterii)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(152, 271);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(221, 22);
            this.dateTimePicker1.TabIndex = 41;
            this.dateTimePicker1.Value = new System.DateTime(2021, 4, 27, 0, 0, 0, 0);
            this.dateTimePicker1.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePicker1_Validating);
            this.dateTimePicker1.Validated += new System.EventHandler(this.dateTimePicker1_Validated);
            // 
            // textTelefon
            // 
            this.textTelefon.Location = new System.Drawing.Point(152, 230);
            this.textTelefon.Name = "textTelefon";
            this.textTelefon.Size = new System.Drawing.Size(221, 22);
            this.textTelefon.TabIndex = 40;
            this.textTelefon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTelefon_KeyPress);
            this.textTelefon.Validating += new System.ComponentModel.CancelEventHandler(this.textTelefon_Validating);
            this.textTelefon.Validated += new System.EventHandler(this.textTelefon_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "Data nasterii:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Numar de telefon:";
            // 
            // btnCurata
            // 
            this.btnCurata.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCurata.Location = new System.Drawing.Point(233, 336);
            this.btnCurata.Name = "btnCurata";
            this.btnCurata.Size = new System.Drawing.Size(140, 23);
            this.btnCurata.TabIndex = 37;
            this.btnCurata.Text = "Renunta";
            this.btnCurata.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCurata.UseVisualStyleBackColor = true;
            this.btnCurata.Click += new System.EventHandler(this.btnCurata_Click);
            // 
            // btnAdaugaCartea
            // 
            this.btnAdaugaCartea.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdaugaCartea.Location = new System.Drawing.Point(28, 336);
            this.btnAdaugaCartea.Name = "btnAdaugaCartea";
            this.btnAdaugaCartea.Size = new System.Drawing.Size(131, 23);
            this.btnAdaugaCartea.TabIndex = 36;
            this.btnAdaugaCartea.Text = "Salveaza";
            this.btnAdaugaCartea.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdaugaCartea.UseVisualStyleBackColor = true;
            this.btnAdaugaCartea.Click += new System.EventHandler(this.btnAdaugaCartea_Click);
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(152, 190);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(221, 22);
            this.textEmail.TabIndex = 35;
            this.textEmail.Validating += new System.ComponentModel.CancelEventHandler(this.textEmail_Validating);
            this.textEmail.Validated += new System.EventHandler(this.textEmail_Validated);
            // 
            // textAdresa
            // 
            this.textAdresa.Location = new System.Drawing.Point(152, 147);
            this.textAdresa.Name = "textAdresa";
            this.textAdresa.Size = new System.Drawing.Size(221, 22);
            this.textAdresa.TabIndex = 34;
            this.textAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.textAdresa_Validating);
            this.textAdresa.Validated += new System.EventHandler(this.textAdresa_Validated);
            // 
            // textPrenume
            // 
            this.textPrenume.Location = new System.Drawing.Point(152, 106);
            this.textPrenume.Name = "textPrenume";
            this.textPrenume.Size = new System.Drawing.Size(221, 22);
            this.textPrenume.TabIndex = 33;
            this.textPrenume.Validating += new System.ComponentModel.CancelEventHandler(this.textPrenume_Validating);
            this.textPrenume.Validated += new System.EventHandler(this.textPrenume_Validated);
            // 
            // textNume
            // 
            this.textNume.Location = new System.Drawing.Point(152, 62);
            this.textNume.Name = "textNume";
            this.textNume.Size = new System.Drawing.Size(221, 22);
            this.textNume.TabIndex = 32;
            this.textNume.Validating += new System.ComponentModel.CancelEventHandler(this.textNume_Validating);
            this.textNume.Validated += new System.EventHandler(this.textNume_Validated);
            // 
            // labelAnAparie
            // 
            this.labelAnAparie.AutoSize = true;
            this.labelAnAparie.Location = new System.Drawing.Point(25, 190);
            this.labelAnAparie.Name = "labelAnAparie";
            this.labelAnAparie.Size = new System.Drawing.Size(51, 17);
            this.labelAnAparie.TabIndex = 31;
            this.labelAnAparie.Text = "E-mail:";
            // 
            // labelEditura
            // 
            this.labelEditura.AutoSize = true;
            this.labelEditura.Location = new System.Drawing.Point(25, 147);
            this.labelEditura.Name = "labelEditura";
            this.labelEditura.Size = new System.Drawing.Size(57, 17);
            this.labelEditura.TabIndex = 30;
            this.labelEditura.Text = "Adresa:";
            // 
            // labelAutor
            // 
            this.labelAutor.AutoSize = true;
            this.labelAutor.Location = new System.Drawing.Point(25, 106);
            this.labelAutor.Name = "labelAutor";
            this.labelAutor.Size = new System.Drawing.Size(69, 17);
            this.labelAutor.TabIndex = 29;
            this.labelAutor.Text = "Prenume:";
            // 
            // labelTitlul
            // 
            this.labelTitlul.AutoSize = true;
            this.labelTitlul.Location = new System.Drawing.Point(25, 62);
            this.labelTitlul.Name = "labelTitlul";
            this.labelTitlul.Size = new System.Drawing.Size(49, 17);
            this.labelTitlul.TabIndex = 28;
            this.labelTitlul.Text = "Nume:";
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
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textTelefon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCurata);
            this.Controls.Add(this.btnAdaugaCartea);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textAdresa);
            this.Controls.Add(this.textPrenume);
            this.Controls.Add(this.textNume);
            this.Controls.Add(this.labelAnAparie);
            this.Controls.Add(this.labelEditura);
            this.Controls.Add(this.labelAutor);
            this.Controls.Add(this.labelTitlul);
            this.Name = "Form4";
            this.Text = "Editeaza cititorul";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epNume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrenume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAdresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDataNasterii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textTelefon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.ErrorProvider epNume;
        private System.Windows.Forms.ErrorProvider epPrenume;
        private System.Windows.Forms.ErrorProvider epAdresa;
        private System.Windows.Forms.ErrorProvider epEmail;
        private System.Windows.Forms.ErrorProvider epTelefon;
        private System.Windows.Forms.ErrorProvider epDataNasterii;
    }
}
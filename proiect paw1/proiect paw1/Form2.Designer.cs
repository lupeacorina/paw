namespace proiect_paw1
{
    partial class Form2
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
            this.textAnAparitie = new System.Windows.Forms.TextBox();
            this.textEditura = new System.Windows.Forms.TextBox();
            this.textAutor = new System.Windows.Forms.TextBox();
            this.textTitlul = new System.Windows.Forms.TextBox();
            this.labelAnAparie = new System.Windows.Forms.Label();
            this.labelEditura = new System.Windows.Forms.Label();
            this.labelAutor = new System.Windows.Forms.Label();
            this.labelTitlul = new System.Windows.Forms.Label();
            this.epTitlul = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAutor = new System.Windows.Forms.ErrorProvider(this.components);
            this.epEditura = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAn = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epTitlul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEditura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCurata
            // 
            this.btnCurata.Location = new System.Drawing.Point(211, 296);
            this.btnCurata.Name = "btnCurata";
            this.btnCurata.Size = new System.Drawing.Size(131, 23);
            this.btnCurata.TabIndex = 23;
            this.btnCurata.Text = "Renunta";
            this.btnCurata.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCurata.UseVisualStyleBackColor = true;
            this.btnCurata.Click += new System.EventHandler(this.btnCurata_Click);
            // 
            // btnAdaugaCartea
            // 
            this.btnAdaugaCartea.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdaugaCartea.Location = new System.Drawing.Point(10, 296);
            this.btnAdaugaCartea.Name = "btnAdaugaCartea";
            this.btnAdaugaCartea.Size = new System.Drawing.Size(131, 23);
            this.btnAdaugaCartea.TabIndex = 22;
            this.btnAdaugaCartea.Text = "Salveaza";
            this.btnAdaugaCartea.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdaugaCartea.UseVisualStyleBackColor = true;
            this.btnAdaugaCartea.Click += new System.EventHandler(this.btnAdaugaCartea_Click);
            // 
            // textAnAparitie
            // 
            this.textAnAparitie.Location = new System.Drawing.Point(121, 216);
            this.textAnAparitie.Name = "textAnAparitie";
            this.textAnAparitie.Size = new System.Drawing.Size(221, 22);
            this.textAnAparitie.TabIndex = 21;
            this.textAnAparitie.Validating += new System.ComponentModel.CancelEventHandler(this.textAnAparitie_Validating);
            this.textAnAparitie.Validated += new System.EventHandler(this.textAnAparitie_Validated);
            // 
            // textEditura
            // 
            this.textEditura.Location = new System.Drawing.Point(121, 173);
            this.textEditura.Name = "textEditura";
            this.textEditura.Size = new System.Drawing.Size(221, 22);
            this.textEditura.TabIndex = 20;
            this.textEditura.Validating += new System.ComponentModel.CancelEventHandler(this.textEditura_Validating);
            this.textEditura.Validated += new System.EventHandler(this.textEditura_Validated);
            // 
            // textAutor
            // 
            this.textAutor.Location = new System.Drawing.Point(121, 132);
            this.textAutor.Name = "textAutor";
            this.textAutor.Size = new System.Drawing.Size(221, 22);
            this.textAutor.TabIndex = 19;
            this.textAutor.Validating += new System.ComponentModel.CancelEventHandler(this.textAutor_Validating);
            this.textAutor.Validated += new System.EventHandler(this.textAutor_Validated);
            // 
            // textTitlul
            // 
            this.textTitlul.Location = new System.Drawing.Point(121, 88);
            this.textTitlul.Name = "textTitlul";
            this.textTitlul.Size = new System.Drawing.Size(221, 22);
            this.textTitlul.TabIndex = 18;
            this.textTitlul.Validating += new System.ComponentModel.CancelEventHandler(this.textTitlul_Validating);
            this.textTitlul.Validated += new System.EventHandler(this.textTitlul_Validated);
            // 
            // labelAnAparie
            // 
            this.labelAnAparie.AutoSize = true;
            this.labelAnAparie.Location = new System.Drawing.Point(21, 216);
            this.labelAnAparie.Name = "labelAnAparie";
            this.labelAnAparie.Size = new System.Drawing.Size(80, 17);
            this.labelAnAparie.TabIndex = 17;
            this.labelAnAparie.Text = "An aparitie:";
            // 
            // labelEditura
            // 
            this.labelEditura.AutoSize = true;
            this.labelEditura.Location = new System.Drawing.Point(21, 173);
            this.labelEditura.Name = "labelEditura";
            this.labelEditura.Size = new System.Drawing.Size(57, 17);
            this.labelEditura.TabIndex = 16;
            this.labelEditura.Text = "Editura:";
            // 
            // labelAutor
            // 
            this.labelAutor.AutoSize = true;
            this.labelAutor.Location = new System.Drawing.Point(21, 132);
            this.labelAutor.Name = "labelAutor";
            this.labelAutor.Size = new System.Drawing.Size(46, 17);
            this.labelAutor.TabIndex = 15;
            this.labelAutor.Text = "Autor:";
            // 
            // labelTitlul
            // 
            this.labelTitlul.AutoSize = true;
            this.labelTitlul.Location = new System.Drawing.Point(21, 88);
            this.labelTitlul.Name = "labelTitlul";
            this.labelTitlul.Size = new System.Drawing.Size(42, 17);
            this.labelTitlul.TabIndex = 14;
            this.labelTitlul.Text = "Titlul:";
            // 
            // epTitlul
            // 
            this.epTitlul.ContainerControl = this;
            // 
            // epAutor
            // 
            this.epAutor.ContainerControl = this;
            // 
            // epEditura
            // 
            this.epEditura.ContainerControl = this;
            // 
            // epAn
            // 
            this.epAn.ContainerControl = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 388);
            this.Controls.Add(this.btnCurata);
            this.Controls.Add(this.btnAdaugaCartea);
            this.Controls.Add(this.textAnAparitie);
            this.Controls.Add(this.textEditura);
            this.Controls.Add(this.textAutor);
            this.Controls.Add(this.textTitlul);
            this.Controls.Add(this.labelAnAparie);
            this.Controls.Add(this.labelEditura);
            this.Controls.Add(this.labelAutor);
            this.Controls.Add(this.labelTitlul);
            this.Name = "Form2";
            this.Text = "Editeaza carte";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form2_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.epTitlul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEditura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCurata;
        private System.Windows.Forms.Button btnAdaugaCartea;
        private System.Windows.Forms.TextBox textAnAparitie;
        private System.Windows.Forms.TextBox textEditura;
        private System.Windows.Forms.TextBox textAutor;
        private System.Windows.Forms.TextBox textTitlul;
        private System.Windows.Forms.Label labelAnAparie;
        private System.Windows.Forms.Label labelEditura;
        private System.Windows.Forms.Label labelAutor;
        private System.Windows.Forms.Label labelTitlul;
        private System.Windows.Forms.ErrorProvider epTitlul;
        private System.Windows.Forms.ErrorProvider epAutor;
        private System.Windows.Forms.ErrorProvider epEditura;
        private System.Windows.Forms.ErrorProvider epAn;
    }
}
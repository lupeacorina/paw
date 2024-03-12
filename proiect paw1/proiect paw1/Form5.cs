using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaHistograma;

namespace proiect_paw1
{
    public partial class Form5 : Form
    {
        int[] vector = new int[12];
        public Form5(int [] v)
        {
            InitializeComponent();
            for (int i = 0; i < 12; i++)
                vector[i] = v[i];
            ColoanaHistograma[] param = new ColoanaHistograma[12];
            param[0] = new ColoanaHistograma("ianuarie", vector[0], "DarkBlue");
            param[1] = new ColoanaHistograma("februarie", vector[1], "Cyan");
            param[2] = new ColoanaHistograma("martie", vector[2], "Plum");
            param[3] = new ColoanaHistograma("aprilie", vector[3], "PaleGreen");
            param[4] = new ColoanaHistograma("mai", vector[4], "MediumVioletRed");
            param[5] = new ColoanaHistograma("iunie", vector[5], "SpringGreen");
            param[6] = new ColoanaHistograma("iulie", vector[6], "HotPink");
            param[7] = new ColoanaHistograma("august", vector[7], "Gold");
            param[8] = new ColoanaHistograma("septembrie", vector[8], "SaddleBrown");
            param[9] = new ColoanaHistograma("octombrie", vector[9], "RoyalBlue");
            param[10] = new ColoanaHistograma("noiembrie", vector[10], "DarkGoldenrod");
            param[11] = new ColoanaHistograma("decembrie", vector[11], "red");
            BibliotecaHistograma.Histograma hist = new BibliotecaHistograma.Histograma(param);
            hist.Location = new System.Drawing.Point(13, 13);
            hist.Name = "histograma1";
            hist.Size = new System.Drawing.Size(647, 459);
            hist.TabIndex = 0;

            this.Controls.Add(hist);

        }
    }
}

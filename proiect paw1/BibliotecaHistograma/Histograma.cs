using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaHistograma
{
    public partial class Histograma : UserControl
    {

        public ColoanaHistograma[] Data;
        //    = new []
        //{ new  ColoanaHistograma("ianuarie",1,"red"),
        //    new ColoanaHistograma("februarie",2,"red"),
        //    new ColoanaHistograma("martie",3,"red"),
        //    new ColoanaHistograma("aprilie",4,"red"),
        //    new ColoanaHistograma("mai",5,"red"),
        //    new ColoanaHistograma("iunie",6,"red"),
        //    new ColoanaHistograma("iulie",7,"red"),
        //   new  ColoanaHistograma("august",8,"red"),
        //     new ColoanaHistograma("septembrie",9,"red"),
        //    new ColoanaHistograma("octombrie",10,"red"),
        //    new ColoanaHistograma("noiembrie",11,"red"),
        //    new ColoanaHistograma("decembrie",12,"red")

        //    };
        public Histograma(ColoanaHistograma[] param)
        {
            InitializeComponent();
            ResizeRedraw = true;
            Data = param;
        }

        private void Histograma_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rectangle = e.ClipRectangle;
            int max = 0;
            foreach(ColoanaHistograma c in Data)
            {
                if(c.Value>max)
                {
                    max = c.Value;
                }
            }

            float scaleFactor =(float) rectangle.Height / max;
            float latimeColoana = (rectangle.Width - 300) / Data.Length;
            float inaltimeMaxColoana = rectangle.Height * 0.9f;


            for (int i= 0;i< Data.Length;i++)
            { ColoanaHistograma c = Data[i];
                float inaltime = c.Value * scaleFactor;
                graphics.FillRectangle(new SolidBrush
                    (Color.FromName(c.Color)), i * latimeColoana
                    , rectangle.Height - inaltime,
                    latimeColoana * 0.9f,
                    inaltime);
            }

            var xCoord = rectangle.Width - 300;
            var yCoord = 0;


            for(int i=0;i<Data.Length;i++)
            {
                ColoanaHistograma c = Data[i];
               
                graphics.FillRectangle(new SolidBrush
                    (Color.FromName(c.Color)),
                    xCoord
                    , yCoord,
                    35,
                    35);
                graphics.DrawString(c.Label+" "+c.Value,
                    new Font("Consolas", 8),
                    new SolidBrush
                    (Color.FromName(c.Color)),
                    xCoord + 35,
                    yCoord + 20
                    );
                yCoord += 35;
            }

        }
    }
}

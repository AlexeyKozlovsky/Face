using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewFaceWithEyes
{
    public partial class Form1 : Form
    {
        Field field;
        public Form1()
        {
            InitializeComponent();


            InitField(50, 50, 200, 200, 3, 3);
        }

        private void InitField(float x, float y, float width, float height, int rows = 3, int columns = 2)
        {
            field = new Field(panel1);
            List<Face> faces = new List<Face>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Face face = new Face(x + i * height, y + j * width, width, height);
                    field.Add(face);
                }
            }
            field.SetK();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e) => field.Update(e.X, e.Y);

    }
}

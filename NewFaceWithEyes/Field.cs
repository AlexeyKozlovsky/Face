using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NewFaceWithEyes
{
    class Field
    {
        private List<Face> _faces;
        private Control _control;


        public Field(Control control)
        {
            this._control = control;
            this._faces = new List<Face>();

        }
        public Field(Control control, List<Face> faces)
        {
            this._control = control;
            this._faces = faces;

            SetK();
        }

        public void SetK()
        {
            foreach(var face in this._faces)
            {
                face.Eye1.InitK(_control.Width, _control.Height);
                face.Eye2.InitK(_control.Width, _control.Height);
            }
        }

        public void Add(Face face)
        {
            if (this._faces == null) _faces = new List<Face>();
            this._faces.Add(face);
        }

        private void UpdateEye(Eye eye, float x, float y)
        {
            eye.Pupil.X = eye.CenterX + (x - eye.CenterX) * eye.K;
            eye.Pupil.Y = eye.CenterY + (y - eye.CenterY) * eye.K;
        }

        private void UpdateFace(Face face, float x, float y)
        {
            UpdateEye(face.Eye1, x, y);
            UpdateEye(face.Eye2, x, y);
        }

        public void Update(float x, float y)
        {
            if (this._faces == null) return;

            foreach(var face in this._faces)
                UpdateFace(face, x, y);

            Draw();
        }

        private void Draw()
        {
            Pen pen = new Pen(Color.Black, 3);

            Image buffer = new Bitmap(_control.Width, _control.Height);
            Graphics grb = Graphics.FromImage(buffer);
            Graphics gr = _control.CreateGraphics();

            grb.Clear(_control.BackColor);

            foreach(var face in this._faces)
            {
                grb.DrawEllipse(pen, face.Border.X, face.Border.Y, face.Border.Width, face.Border.Height);
                grb.DrawEllipse(pen, face.Eye1.Border.X, face.Eye1.Border.Y, face.Eye1.Border.Width,
                    face.Eye1.Border.Height);
                grb.DrawEllipse(pen, face.Eye2.Border.X, face.Eye2.Border.Y, face.Eye2.Border.Width,
                    face.Eye2.Border.Height);

                grb.DrawEllipse(pen, face.Eye1.Pupil.X, face.Eye1.Pupil.Y, face.Eye1.Pupil.Width,
                    face.Eye1.Pupil.Height);
                grb.DrawEllipse(pen, face.Eye2.Pupil.X, face.Eye2.Pupil.Y, face.Eye2.Pupil.Width,
                    face.Eye2.Pupil.Height);
            }
            
            gr.DrawImage(buffer, 0, 0);
            
            gr.Dispose();
            grb.Dispose();
            buffer.Dispose();

        }
    }
}

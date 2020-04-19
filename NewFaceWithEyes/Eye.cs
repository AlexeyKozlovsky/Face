using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFaceWithEyes
{
    class Eye
    {

        private Ellipse _border;
        private Ellipse _pupil;
        private float k;

        public float K { get { return k; } }

        public float CenterX { get { return _border.X + _border.Width / 2; } }
        public float CenterY { get { return _border.Y + _border.Height / 2; } }

        public Ellipse Pupil { get { return _pupil; } set { _pupil = value; } }

        public Ellipse Border { get { return _border; } }
        public float Radius { get { return _border.Width / 2; } }

        public Eye(float x, float y, float width, float height)
        {
            _border = new Ellipse(x, y, width, height);

            float pupilWidth = width / 10;
            float pupilHeight = height / 10;

            _pupil = new Ellipse(x + width / 2, y + height / 2, pupilWidth, pupilHeight);
        }

        public void InitK(float width, float height)
        {
            float dist;
            float distX;
            float distY;

            float centerX = this.CenterX;
            float centerY = this.CenterY;

            float radius = this.Radius - this.Pupil.Width;

            if (centerX > width - centerX)
                distX = centerX;
            else distX = width - centerX;

            if (centerY > height - centerY)
                distY = centerY;
            else distY = height - centerY;

            dist = (float)Math.Sqrt(Math.Pow(distX, 2) + Math.Pow(distY, 2));

            this.k = radius / dist;
        }

    }
}

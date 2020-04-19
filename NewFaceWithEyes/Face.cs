using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFaceWithEyes
{
    class Face
    {
        private Ellipse _border;
        private Eye _eye1;
        private Eye _eye2;


        public Eye Eye1 { get { return _eye1; } set { _eye1 = value; } }
        public Eye Eye2 { get { return _eye2; } set { _eye2 = value; } }

        public Ellipse Border { get { return _border; } }

        public Face(float x, float y, float width, float height)
        {
            this._border = new Ellipse(x, y, width, height);

            float eyeWidth = width / 3;
            float eyeHeight = height / 3;

            this._eye1 = new Eye(x + width / 2 - eyeWidth, y + eyeHeight, eyeWidth, eyeHeight);
            this._eye2 = new Eye(x + width / 2, y + eyeHeight, eyeWidth, eyeHeight);
        }

    }
}

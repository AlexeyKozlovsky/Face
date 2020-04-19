using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFaceWithEyes
{
    class Ellipse
    {
        private float _x;
        private float _y;
        private float _width;
        private float _height;

        public float X { get { return _x; } set { _x = value; } }
        public float Y { get { return _y; } set { _y = value; } }

        public float Width { get { return _width; } }
        public float Height { get { return _height; } }

        public Ellipse(float x, float y, float width, float height)
        {
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
        }
    }
}

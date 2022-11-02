using System;

namespace radiation_pattern
{
    public struct Emitter
    {
        public PointD Pos;

        private double _a;
        private double _l;
        private double _k;
        private double _y;

        public Emitter(PointD pos, double a, double l, double k, double y)
        {
            _a = a;
            _l = l;
            _k = k;
            _y = y;

            Pos = pos;
        }

        public double Intensity(Vector point)
        {
            var delta = point - new Vector(Pos.X, Pos.Y, 0);
            var norm = delta.Normalized();
            var r = delta.Magnitude();
            var a = _a / r * Math.Cos(_l * r);
            var b = Math.Sin(_l * r);
            
            return a * a + b * b;
        }
    }
}
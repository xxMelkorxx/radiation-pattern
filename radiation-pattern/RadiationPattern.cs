using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace radiation_pattern
{
    public class RadiationPattern
    {
        private double _a;
        private double _l;
        private double _k;
        private double _y;

        public double D => _k * _l;

        public double R { get; set; }
        public int Size { get; set; }
        public int M { get; set; }
        public int N { get; set; }

        public Vector[,] Intensity;
        public List<Emitter> Emitters;
        public DrawingPlant DrawingPlant;

        public RadiationPattern(int size, int m, int n, double r, double a, double l, double k, double y = 1)
        {
            _a = a;
            _l = l;
            _k = k;
            _y = y;

            Size = size;
            M = m;
            N = n;
            R = r;

            Intensity = new Vector[Size, Size];
            Emitters = new List<Emitter>();
        }

        public void CalculateIntensity()
        {
            var deltaX = M * D / 2.0;
            var deltaY = N * D / 2.0;

            for (var i = 0; i < Size; i++)
            for (var j = 0; j < Size; j++)
            {
                // Тета меняется от 0 до PI/2.
                var teta = 0.5 * Math.PI * i / (Size - 1);
                // Фи меняется от 0 до 2PI.
                var phi = 2 * Math.PI * j / (Size - 1);

                // Координаты точки на полусфере.
                var x = deltaX + R * Math.Sin(teta) * Math.Cos(phi);
                var y = deltaY + R * Math.Sin(teta) * Math.Sin(phi);
                var z = R * Math.Cos(teta);
                var point = new Vector(x, y, z);

                var vecIntensity = Vector.Zero;
                Emitters.ForEach(emitter => vecIntensity += emitter.Intensity(point));

                Intensity[i, j] = new Vector(point.X, point.Y, vecIntensity.Magnitude());
            }
        }

        public void InitialDrawingPlant(PictureBox pictureBox)
        {
            DrawingPlant = new DrawingPlant(pictureBox, 0, 0, M, N)
            {
                EnabledEmitters = new bool[M, N]
            };
            DrawingPlant.Clear();
        }
        
        public void AddEmitter(PointD pointScreen)
        {
            var posEmitter = GetPosEmitter(pointScreen, true);
            Emitters.Add(new Emitter(posEmitter, _a, _l, _k, _y));
        }

        public void DeleteEmitter(PointD pointScreen)
        {
            var posEmitter = GetPosEmitter(pointScreen, false);
            var idx = -1;
            for (var i = 0; i < Emitters.Count; i++)
                if (Emitters[i].Pos == posEmitter)
                {
                    idx = i;
                    break;
                }

            if (idx >= 0) Emitters.RemoveAt(idx);
        }

        private PointD GetPosEmitter(PointD pointScreen, bool isEnabled)
        {
            pointScreen.X *= D * M;
            pointScreen.Y *= D * M;

            var posEmitter = PointD.Empty;
            for (var x = 0; x < M; x++)
            for (var y = 0; y < N; y++)
            {
                if (pointScreen.X >= x * D && pointScreen.X < (x + 1) * D &&
                    pointScreen.Y >= y * D && pointScreen.Y < (y + 1) * D &&
                    isEnabled
                        ? !DrawingPlant.EnabledEmitters[x, y]
                        : DrawingPlant.EnabledEmitters[x, y])
                {
                    DrawingPlant.EnabledEmitters[x, y] = isEnabled;
                    posEmitter = new PointD(x * D + D / 2, y * D + D / 2);
                }
            }

            return posEmitter;
        }
    }
}
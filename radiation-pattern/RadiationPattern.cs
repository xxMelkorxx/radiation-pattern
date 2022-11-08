using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace radiation_pattern
{
    public class RadiationPattern
    {
        /// <summary>
        /// Амплитуда волны.
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// Длина волны.
        /// </summary>
        public double L { get; set; }

        /// <summary>
        /// Волновое число.
        /// </summary>
        public double K { get; set; }

        /// <summary>
        /// Радиус полусферы.
        /// </summary>
        public double R { get; set; }

        /// <summary>
        /// Размер поверхности в кол-ве точек.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Размер по ширине площадки излучателей.
        /// </summary>
        public int M { get; }

        /// <summary>
        /// Размер по высоте площадки излучателей.
        /// </summary>
        public int N { get; }

        /// <summary>
        /// Значения интенсивности на поверхности размером <see cref="Size"/>x<see cref="Size"/>.
        /// </summary>
        public double[,] IntensityValues;

        private bool[,] _enabledEmitters;
        private List<PointD> _emitters;
        private DrawingPlant _drawingPlant;

        private double D => K * L;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="size">Размер диаграммы направленности в точках.</param>
        /// <param name="m">Размер сетки площадки по оси X.</param>
        /// <param name="n">Размер секки площадки по оси Y.</param>
        public RadiationPattern(int size, int m, int n)
        {
            Size = size;
            M = m;
            N = n;
            A = 10;
            R = 100;
            L = 1;
            K = 0.5;

            _enabledEmitters = new bool[M, N];
            IntensityValues = new double[Size, Size];
            _emitters = new List<PointD>();
        }

        /// <summary>
        /// Расчёт интенсивности.
        /// </summary>
        public void CalculateIntensity(out double max)
        {
            max = double.MinValue;
            IntensityValues = new double[Size, Size];
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

                var value = Complex.Zero;
                _emitters.ForEach(emitter =>
                {
                    var dx = x - emitter.X;
                    var dy = y - emitter.Y;
                    var r = Math.Sqrt(dx * dx + dy * dy + z * z);

                    value += A / r * (Math.Cos(2 * Math.PI * r / L) - Complex.ImaginaryOne * Math.Sin(2 * Math.PI * r / L));
                });

                var intensity = R * value.Magnitude / (_emitters.Count == 0 ? 1 : _emitters.Count);
                max = Math.Max(max, intensity);

                IntensityValues[i, j] = intensity;
            }
        }

        /// <summary>
        /// Отрисовка площадки с излучателями.
        /// </summary>
        /// <param name="pictureBox">Элемент pictureBox, в котором будет отрисовываться элемент.</param>
        public void DrawPlant(PictureBox pictureBox)
        {
            _drawingPlant = new DrawingPlant(pictureBox, M, N);
            _drawingPlant.DrawGrid(Color.White, _enabledEmitters);
        }

        /// <summary>
        /// Добавление излучателя.
        /// </summary>
        /// <param name="pointScreen">Координата излучения.</param>
        public void AddEmitter(PointD pointScreen)
        {
            var newEmitter = GetPosEmitter(pointScreen, true);
            if (!_emitters.Contains(newEmitter) && !newEmitter.Equals(PointD.Empty))
                _emitters.Add(newEmitter);
        }

        /// <summary>
        /// Удаление излучателя.
        /// </summary>
        /// <param name="pointScreen">Координата размещения.</param>
        public void DeleteEmitter(PointD pointScreen)
        {
            var posEmitter = GetPosEmitter(pointScreen, false);
            var idx = -1;
            for (var i = 0; i < _emitters.Count; i++)
                if (_emitters[i] == posEmitter)
                {
                    idx = i;
                    break;
                }

            if (idx >= 0)
                _emitters.RemoveAt(idx);
        }

        /// <summary>
        /// Получение истинной координаты излучателя, а также переключение его состояния.
        /// </summary>
        /// <param name="pointScreen">Координата размещения.</param>
        /// <param name="isEnabled">Состояние излучателя.</param>
        /// <returns></returns>
        private PointD GetPosEmitter(PointD pointScreen, bool isEnabled)
        {
            pointScreen.X *= D * M;
            pointScreen.Y *= D * N;

            var posEmitter = PointD.Empty;
            for (var i = 0; i < M; i++)
            for (var j = 0; j < N; j++)
            {
                if (pointScreen.X >= i * D && pointScreen.X < (i + 1) * D &&
                    pointScreen.Y >= j * D && pointScreen.Y < (j + 1) * D &&
                    (isEnabled
                        ? !_enabledEmitters[i, j]
                        : _enabledEmitters[i, j]))
                {
                    _enabledEmitters[i, j] = isEnabled;
                    posEmitter = new PointD(i * D + D / 2, j * D + D / 2);
                }
            }

            return posEmitter;
        }
    }
}
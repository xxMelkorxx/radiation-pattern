using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace radiation_pattern
{
    public class RadiationPattern
    {
        private double _a;
        private double _l;
        private double _k;
        private double _y;
        private double _r;
        private bool[,] _enabledEmitters;
        private List<Emitter> _emittersList;
        private Vector[,] _intensityValues;
        private DrawingPlant _drawingPlant;

        private double D => _k * _l;
        public int Size { get; }
        public int M { get; }
        public int N { get; }


        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="size">Размер диаграммы направленности в точках.</param>
        /// <param name="m">Размер сетки площадки по оси X.</param>
        /// <param name="n">Размер секки площадки по оси Y.</param>
        /// <param name="r">Радиус полусферы.</param>
        /// <param name="a">Амплитуда волны.</param>
        /// <param name="l">Длина волны.</param>
        /// <param name="k">Волновое число.</param>
        /// <param name="y">Коэффициент затухания волны.</param>
        public RadiationPattern(int size, int m, int n, double r, double a, double l, double k, double y = 1)
        {
            _a = a;
            _l = l;
            _k = k;
            _y = y;
            _r = r;

            Size = size;
            M = m;
            N = n;

            _enabledEmitters = new bool[M, N];
            _intensityValues = new Vector[Size, Size];
            _emittersList = new List<Emitter>();
        }

        /// <summary>
        /// Расчёт интенсивности.
        /// </summary>
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
                var x = deltaX + _r * Math.Sin(teta) * Math.Cos(phi);
                var y = deltaY + _r * Math.Sin(teta) * Math.Sin(phi);
                var z = _r * Math.Cos(teta);
                var point = new Vector(x, y, z);

                var vecIntensity = Vector.Zero;
                _emittersList.ForEach(emitter => vecIntensity += emitter.Intensity(point));

                _intensityValues[i, j] = new Vector(point.X, point.Y, vecIntensity.Magnitude());
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
            var posEmitter = GetPosEmitter(pointScreen, true);
            _emittersList.Add(new Emitter(posEmitter, _a, _l, _k, _y));
        }

        /// <summary>
        /// Удаление излучателя.
        /// </summary>
        /// <param name="pointScreen">Координата размещения.</param>
        public void DeleteEmitter(PointD pointScreen)
        {
            var posEmitter = GetPosEmitter(pointScreen, false);
            var idx = -1;
            for (var i = 0; i < _emittersList.Count; i++)
                if (_emittersList[i].Pos == posEmitter)
                {
                    idx = i;
                    break;
                }

            if (idx >= 0)
                _emittersList.RemoveAt(idx);
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace radiation_pattern
{
    public class DrawingPlant
    {
        private Graphics _graphics;
        private readonly double _alpha, _beta;
        private int _m;
        private int _n;

        public DrawingPlant(PictureBox pB, int m, int n)
        {
            _m = m;
            _n = n;
            
            var bitmap = new Bitmap(pB.Width, pB.Height);
            _graphics = Graphics.FromImage(bitmap);
            _graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _graphics.Clear(Color.Black);

            // Вычисление коэффициентов преобразование.
            _alpha = (double)pB.Width / _m;
            _beta = (double)pB.Height / _n;

            pB.Image = bitmap;
        }

        /// <summary>
        /// Преобразует мировые координаты в координаты окна (пиксели).
        /// </summary>
        /// <param name="x">X в мировых координатах.</param>
        /// <returns>Координата, преобразованная в координаты окна (пиксели).</returns>
        private float OutX(double x)
        {
            return (float)(x * _alpha);
        }

        /// <summary>
        /// Преобразует мировые координаты в координаты окна (пиксели).
        /// </summary>
        /// <param name="y">Y мировых координатах.s</param>
        /// <returns>Координата, преобразованная в координаты окна (пиксели).</returns>
        private float OutY(double y)
        {
            return (float)(y * _beta);
        }

        /// <summary>
        ///	Рисует линию. 
        /// </summary>
        /// <param name="color">Цвет линий.</param>
        /// <param name="x1">Координата X первой точки.</param>
        /// <param name="y1">Координата Y первой точки.</param>
        /// <param name="x2">Координата X второй точки.</param>
        /// <param name="y2">Координата Y второй точки.</param>
        private void DrawLine(Color color, double x1, double y1, double x2, double y2)
        {
            var pen = new Pen(color);
            pen.DashStyle = DashStyle.Dash;
            _graphics.DrawLine(pen, OutX(x1), OutY(y1), OutX(x2), OutY(y2));
        }

        /// <summary>
        /// Рисует заполненный эллипс.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DrawFillEllipse(Color color, double x, double y, double width, double height)
        {
            var brush = new SolidBrush(color);
            _graphics.FillEllipse(brush, OutX(x) - OutX(width) / 2, OutY(y) - OutY(height) / 2, OutX(width), OutY(height));
        }
        
        /// <summary>
        /// Отрисовка площадки с излучателями.
        /// </summary>
        /// <param name="color">Цвет сетки</param>
        /// <param name="emittersEnabled">Массив состойний излучателей</param>
        public void DrawGrid(Color color, bool[,] emittersEnabled)
        {
            for (var i = 1; i < _m; i++)
                DrawLine(color, i, 0, i, _n);
            for (var i = 1; i < _n; i++)
                DrawLine(color, 0, i, _m, i);
            
            for (var i = 0; i < _m; i++)
            for (var j = 0; j < _n; j++)
                if (emittersEnabled[i, j])
                {
                    double width = 0.33, height = 0.33;
                    if (_m > _n) width *= (double)_m / _n;
                    else height *= (double)_n / _m;
                    DrawFillEllipse(Color.Gold, i + 0.5, j + 0.5, width, height);
                }
        }
    }
}
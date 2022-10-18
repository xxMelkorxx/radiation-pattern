using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace radiation_pattern
{
	public class DrawingPlant
	{
		public bool[,] EnabledEmitters;
		
		private Graphics _graphics;
		private readonly double _alpha, _beta;
		private double _width;
		private double _height;

		public DrawingPlant(PictureBox pB, double x1, double y1, double x2, double y2)
		{
			_width = pB.Width;
			_height = pB.Height;
			var bitmap = new Bitmap(pB.Width, pB.Height);
			_graphics = Graphics.FromImage(bitmap);
			_graphics.SmoothingMode = SmoothingMode.AntiAlias;
			_graphics.TranslateTransform(0, pB.Height);
			
			// Вычисление коэффициентов преобразование.
			_alpha = pB.Width / (x2 - x1);
			_beta = -pB.Height / (y2 - y1);
			
			pB.Image = bitmap;
		}

		/// <summary>
		/// Очищает область.
		/// </summary>
		public void Clear()
		{
			_graphics.Clear(Color.Black);
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
			// var pen = new Pen(Color.Black);
			_graphics.FillEllipse(brush, OutX(x) - OutX(width) / 2, OutY(y) - OutY(height) / 2, OutX(width), OutY(height));
			// _graphics.DrawEllipse(pen, OutX(x) - OutX(width) / 2, OutY(y) - OutY(height) / 2, OutX(width), OutY(height));
		}

		public void DrawGrid(Color color, int n, int m)
		{
			var deltaX = _width / n;
			var deltaY = _height / m;
			
			for (var i = 1; i < n; i++)
				for (var j = 1; j < m; j++)
					DrawLine(color, deltaX * i, deltaY * j, _width + deltaX * i, _height + deltaY * j);
		}
	}
}

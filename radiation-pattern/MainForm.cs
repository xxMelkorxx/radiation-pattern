using System;
using System.Windows.Forms;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace radiation_pattern
{
    public partial class MainForm : Form
    {
        private RadiationPattern _radiationPattern;
        private double _max;
        private bool _isGlLoaded;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnInitial(object sender, EventArgs e)
        {
            _radiationPattern = new RadiationPattern((int)nud_size.Value, (int)nud_m.Value, (int)nud_n.Value)
            {
                A = (double)nud_ampl.Value,
                R = (double)nud_radius.Value,
                L = (double)nud_wavelength.Value,
                K = (double)nud_k.Value
            };
            _radiationPattern.DrawPlant(pictureBox_plant);
        }

        private void OnMouseDownPictureBox(object sender, MouseEventArgs e)
        {
            var pointScreen = new PointD((double)e.X / pictureBox_plant.Width, (double)e.Y / pictureBox_plant.Height);

            if (e.Button == MouseButtons.Left)
            {
                _radiationPattern.AddEmitter(pointScreen);
                _radiationPattern.DrawPlant(pictureBox_plant);
                OnCalculate(null, null);
            }
            else if (e.Button == MouseButtons.Right)
            {
                _radiationPattern.DeleteEmitter(pointScreen);
                _radiationPattern.DrawPlant(pictureBox_plant);
                OnCalculate(null, null);
            }
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            _radiationPattern.A = (double)nud_ampl.Value;
            _radiationPattern.R = (double)nud_radius.Value;
            _radiationPattern.L = (double)nud_wavelength.Value;
            _radiationPattern.K = (double)nud_k.Value;
            
            _radiationPattern.CalculateIntensity(out _max);
            OnPaintGLControl(null, null);
            glControl_radiationPattern.Select();
        }

        private void OnLoadGLControl(object sender, EventArgs e)
        {
            _isGlLoaded = true;

            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(Color.Black);

            var p = Matrix4.CreatePerspectiveFieldOfView((float)(90 * Math.PI / 180), 1, 20, 500);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);

            var shift = (float)nud_size.Value;
            var modelview = Matrix4.LookAt(shift, shift / 2, 0, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
        }

        private void OnPaintGLControl(object sender, PaintEventArgs e)
        {
            if (!_isGlLoaded) return;
            
            var shift = _radiationPattern.Size >> 1;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Отрисовка осей.
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(shift, 0, 0);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, shift, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, shift);
            GL.End();

            GL.Begin(PrimitiveType.Points);
            Color color;
            for (var i = 0; i < _radiationPattern.Size; i++)
            for (var j = 0; j < _radiationPattern.Size; j++)
            {
                var value = _radiationPattern.IntensityValues[i, j];
                if (_max == 0)
                    color = Color.FromArgb(50, 50, 50);
                else
                {
                    var rgb = 50 + (int)(value / _max * 150);
                    color = Color.FromArgb(rgb, rgb, rgb);
                }

                GL.Color3(color);
                GL.Vertex3(-shift + i, value, -shift + j);
            }

            GL.End();
            glControl_radiationPattern.SwapBuffers();
        }

        private void OnKeyDownGLControl(object sender, KeyEventArgs e)
        {
            if (!_isGlLoaded) return;

            switch (e.KeyCode)
            {
                case Keys.W:
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.Rotate(5, 0, 0, 1);
                    break;
                }
                case Keys.S:
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.Rotate(-5, 0, 0, 1);
                    break;
                }
                case Keys.A:
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.Rotate(5, 1, 0, 0);
                    break;
                }
                case Keys.D:
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.Rotate(-5, 1, 0, 0);
                    break;
                }
                case Keys.Q:
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.Rotate(5, 0, 1, 0);
                    break;
                }
                case Keys.E:
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.Rotate(-5, 0, 1, 0);
                    break;
                }
                default: return;
            }

            glControl_radiationPattern.Invalidate();
        }
    }
}
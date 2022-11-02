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
        private bool _isGlLoaded;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnInitial(object sender, EventArgs e)
        {
            var m = (int)nud_m.Value;
            var n = (int)nud_n.Value;
            var size = (int)nud_size.Value;
            var r = (double)nud_radius.Value;
            var l = (double)nud_wavelength.Value;
            var k = (double)nud_k.Value;
            
            _radiationPattern = new RadiationPattern(size, m, n, r, 50, l, k, 1);
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
            _radiationPattern.CalculateIntensity();
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

            var shift = -(_radiationPattern.Size >> 1);
            
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
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
            
            GL.Color3(Color.Coral);
            GL.Begin(PrimitiveType.Quads);
            for (var i = 1; i < _radiationPattern.Size; i++)
            {
                for (var j = 0; j < _radiationPattern.Size; j++)
                {
                    GL.Vertex3(shift + i - 1, _radiationPattern.IntensityValues[i - 1, j],shift + j);
                    GL.Vertex3(shift + i, _radiationPattern.IntensityValues[i, j], shift + j);
                    GL.Vertex3(shift + j, _radiationPattern.IntensityValues[j, i - 1], shift + i - 1);
                    GL.Vertex3(shift + j, _radiationPattern.IntensityValues[j, i], shift + i);
                }
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
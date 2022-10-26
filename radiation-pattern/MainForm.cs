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
        private int _xPos, _yPos;

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
            
            _radiationPattern = new RadiationPattern(size, m, n, r, 1, l, k, 1);
            _radiationPattern.DrawPlant(pictureBox_plant);
        }

        private void OnMouseDownPictureBox(object sender, MouseEventArgs e)
        {
            var pointScreen = new PointD((double)e.X / pictureBox_plant.Width, (double)e.Y / pictureBox_plant.Height);

            if (e.Button == MouseButtons.Left)
            {
                _radiationPattern.AddEmitter(pointScreen);
                _radiationPattern.DrawPlant(pictureBox_plant);
            }
            else if (e.Button == MouseButtons.Right)
            {
                _radiationPattern.DeleteEmitter(pointScreen);
                _radiationPattern.DrawPlant(pictureBox_plant);
            }
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            _radiationPattern.CalculateIntensity();
        }

        private void OnLoadGLControl(object sender, EventArgs e)
        {
            _isGlLoaded = true;
            
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);
            
            var p = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 20, 500);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);

            var modelview = Matrix4.LookAt(70, 70, 70, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
        }

        private void OnPaintGLControl(object sender, PaintEventArgs e)
        {
            if (!_isGlLoaded) return;
            
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            GL.Color3(Color.White);
            GL.Begin(BeginMode.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(50, 0, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 50, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 50);
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
                    GL.Rotate(10, 1, 0, 0);
                    break;
                }
                case Keys.S:
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.Rotate(-10, 1, 0, 0);
                    break;
                }
                case Keys.A:
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.Rotate(10, 0, 1, 0);
                    break;
                }
                case Keys.D:
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.Rotate(-10, 0, 1, 0);
                    break;
                }
                default: return;
            }
            
            glControl_radiationPattern.Invalidate();
        }
    }
}
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
		private Matrix4 _modelview;
        
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
            OnCalculate(null, null);
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

            _modelview = Matrix4.LookAt(0, 0, 200, 0, 0, 0, 0, 1, 0);
            
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref _modelview);
        }

        private void OnPaintGLControl(object sender, PaintEventArgs e)
        {
            if (!_isGlLoaded) return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            GL.Begin(PrimitiveType.Points);
            var color = Color.FromArgb(50, 50, 50);
            for (var i = 0; i < _radiationPattern.Size; i++)
            for (var j = 0; j < _radiationPattern.Size; j++)
            {
                var value = _radiationPattern.IntensityValues[i, j];
                if (_max != 0)
                {
                    var rgb = 50 + (int)(value.Z / _max * 150);
                    color = Color.FromArgb(rgb, rgb, rgb);
                }

                GL.Color3(color);
                GL.Vertex3(value.X, value.Y, value.Z);
            }

            GL.End();
            glControl_radiationPattern.SwapBuffers();
        }

        private void OnKeyDownGLControl(object sender, KeyEventArgs e)
        {
            if (!_isGlLoaded) return;

            if (e.KeyCode == Keys.W)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(5, 1, 0, 0);
            }
            if (e.KeyCode == Keys.S)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(-5, 1, 0, 0);
            }
            if (e.KeyCode == Keys.A)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(5, 0, 1, 0);
            }
            if (e.KeyCode == Keys.D)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(-5, 0, 1, 0);
            }
            if (e.KeyCode == Keys.Q)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(5, 0, 0, 1);
            }
            if (e.KeyCode == Keys.E)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(-5, 0, 0, 1);
            }
            if (e.KeyCode == Keys.Oemplus)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Scale(1.1, 1.1, 1.1);
            }
            if (e.KeyCode == Keys.OemMinus)
            {
				GL.MatrixMode(MatrixMode.Modelview);
				GL.Scale(0.9, 0.9, 0.9);
			}

            glControl_radiationPattern.Invalidate();
        }
    }
}
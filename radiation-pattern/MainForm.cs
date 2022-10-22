using System;
using System.Windows.Forms;

namespace radiation_pattern
{
    public partial class MainForm : Form
    {
        private RadiationPattern _radiationPattern;

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
            _radiationPattern.DrawingPlant(pictureBox_plant);
        }

        private void OnMouseDownPictureBox(object sender, MouseEventArgs e)
        {
            var pointScreen = new PointD((double)e.X / pictureBox_plant.Width, (double)e.Y / pictureBox_plant.Height);

            if (e.Button == MouseButtons.Left)
            {
                _radiationPattern.AddEmitter(pointScreen);
                _radiationPattern.DrawingPlant(pictureBox_plant);
            }
            else if (e.Button == MouseButtons.Right)
            {
                _radiationPattern.DeleteEmitter(pointScreen);
                _radiationPattern.DrawingPlant(pictureBox_plant);
            }
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            _radiationPattern.CalculateIntensity();
        }
    }
}
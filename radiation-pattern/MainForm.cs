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

        private void OnLoadMainForm(object sender, EventArgs e)
        {
            _radiationPattern = new RadiationPattern(400, 10, 10, 100, 1, 1, 0.5, 1);
            _radiationPattern.InitialDrawingPlant(pictureBox1);
        }

        private void OnMouseDownPictureBox(object sender, MouseEventArgs e)
        {
            var pointScreen = new PointD((double)e.X / pictureBox1.Width, (double)e.Y / pictureBox1.Height);
            
            if (e.Button == MouseButtons.Left)
            {
                _radiationPattern.AddEmitter(pointScreen);
            }
            else if (e.Button == MouseButtons.Right)
            {
                _radiationPattern.DeleteEmitter(pointScreen);
            }
        }
    }
}
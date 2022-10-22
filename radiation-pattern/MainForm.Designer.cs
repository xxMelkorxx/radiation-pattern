namespace radiation_pattern
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
	        System.Windows.Forms.GroupBox groupBox_plant;
	        System.Windows.Forms.GroupBox groupBox_radiationPattern;
	        System.Windows.Forms.GroupBox groupBox_params;
	        System.Windows.Forms.Label label_k;
	        System.Windows.Forms.Label label_wavelength;
	        System.Windows.Forms.Label label3;
	        System.Windows.Forms.Label label_size;
	        System.Windows.Forms.Label label_sizeGrid;
	        this.pictureBox_plant = new System.Windows.Forms.PictureBox();
	        this.pictureBox_radiationPattern = new System.Windows.Forms.PictureBox();
	        this.nud_m = new System.Windows.Forms.NumericUpDown();
	        this.nud_k = new System.Windows.Forms.NumericUpDown();
	        this.nud_wavelength = new System.Windows.Forms.NumericUpDown();
	        this.nud_radius = new System.Windows.Forms.NumericUpDown();
	        this.nud_size = new System.Windows.Forms.NumericUpDown();
	        this.nud_n = new System.Windows.Forms.NumericUpDown();
	        this.button_calculate = new System.Windows.Forms.Button();
	        groupBox_plant = new System.Windows.Forms.GroupBox();
	        groupBox_radiationPattern = new System.Windows.Forms.GroupBox();
	        groupBox_params = new System.Windows.Forms.GroupBox();
	        label_k = new System.Windows.Forms.Label();
	        label_wavelength = new System.Windows.Forms.Label();
	        label3 = new System.Windows.Forms.Label();
	        label_size = new System.Windows.Forms.Label();
	        label_sizeGrid = new System.Windows.Forms.Label();
	        groupBox_plant.SuspendLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_plant)).BeginInit();
	        groupBox_radiationPattern.SuspendLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_radiationPattern)).BeginInit();
	        groupBox_params.SuspendLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_m)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_k)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_wavelength)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_radius)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_size)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_n)).BeginInit();
	        this.SuspendLayout();
	        // 
	        // groupBox_plant
	        // 
	        groupBox_plant.Controls.Add(this.pictureBox_plant);
	        groupBox_plant.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        groupBox_plant.Location = new System.Drawing.Point(12, 12);
	        groupBox_plant.Name = "groupBox_plant";
	        groupBox_plant.Size = new System.Drawing.Size(515, 535);
	        groupBox_plant.TabIndex = 1;
	        groupBox_plant.TabStop = false;
	        groupBox_plant.Text = "Площадка с излучателями";
	        // 
	        // pictureBox_plant
	        // 
	        this.pictureBox_plant.BackColor = System.Drawing.SystemColors.ControlLightLight;
	        this.pictureBox_plant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	        this.pictureBox_plant.Location = new System.Drawing.Point(7, 23);
	        this.pictureBox_plant.Margin = new System.Windows.Forms.Padding(4);
	        this.pictureBox_plant.Name = "pictureBox_plant";
	        this.pictureBox_plant.Size = new System.Drawing.Size(500, 500);
	        this.pictureBox_plant.TabIndex = 1;
	        this.pictureBox_plant.TabStop = false;
	        this.pictureBox_plant.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownPictureBox);
	        // 
	        // groupBox_radiationPattern
	        // 
	        groupBox_radiationPattern.Controls.Add(this.pictureBox_radiationPattern);
	        groupBox_radiationPattern.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        groupBox_radiationPattern.Location = new System.Drawing.Point(533, 12);
	        groupBox_radiationPattern.Name = "groupBox_radiationPattern";
	        groupBox_radiationPattern.Size = new System.Drawing.Size(515, 535);
	        groupBox_radiationPattern.TabIndex = 2;
	        groupBox_radiationPattern.TabStop = false;
	        groupBox_radiationPattern.Text = "Диаграмма направленности";
	        // 
	        // pictureBox_radiationPattern
	        // 
	        this.pictureBox_radiationPattern.BackColor = System.Drawing.SystemColors.ControlLightLight;
	        this.pictureBox_radiationPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	        this.pictureBox_radiationPattern.Location = new System.Drawing.Point(7, 23);
	        this.pictureBox_radiationPattern.Margin = new System.Windows.Forms.Padding(4);
	        this.pictureBox_radiationPattern.Name = "pictureBox_radiationPattern";
	        this.pictureBox_radiationPattern.Size = new System.Drawing.Size(500, 500);
	        this.pictureBox_radiationPattern.TabIndex = 1;
	        this.pictureBox_radiationPattern.TabStop = false;
	        // 
	        // groupBox_params
	        // 
	        groupBox_params.BackColor = System.Drawing.SystemColors.Control;
	        groupBox_params.Controls.Add(this.nud_m);
	        groupBox_params.Controls.Add(this.nud_k);
	        groupBox_params.Controls.Add(label_k);
	        groupBox_params.Controls.Add(this.nud_wavelength);
	        groupBox_params.Controls.Add(label_wavelength);
	        groupBox_params.Controls.Add(this.nud_radius);
	        groupBox_params.Controls.Add(label3);
	        groupBox_params.Controls.Add(this.nud_size);
	        groupBox_params.Controls.Add(label_size);
	        groupBox_params.Controls.Add(this.nud_n);
	        groupBox_params.Controls.Add(label_sizeGrid);
	        groupBox_params.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        groupBox_params.Location = new System.Drawing.Point(1056, 12);
	        groupBox_params.Name = "groupBox_params";
	        groupBox_params.Size = new System.Drawing.Size(295, 499);
	        groupBox_params.TabIndex = 3;
	        groupBox_params.TabStop = false;
	        groupBox_params.Text = "Параметры";
	        // 
	        // nud_m
	        // 
	        this.nud_m.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        this.nud_m.BorderStyle = System.Windows.Forms.BorderStyle.None;
	        this.nud_m.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.nud_m.Location = new System.Drawing.Point(189, 22);
	        this.nud_m.Minimum = new decimal(new int[]
	        {
		        2, 0, 0, 0
	        });
	        this.nud_m.Name = "nud_m";
	        this.nud_m.Size = new System.Drawing.Size(50, 25);
	        this.nud_m.TabIndex = 10;
	        this.nud_m.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	        this.nud_m.Value = new decimal(new int[]
	        {
		        10, 0, 0, 0
	        });
	        this.nud_m.ValueChanged += new System.EventHandler(this.OnInitial);
	        // 
	        // nud_k
	        // 
	        this.nud_k.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        this.nud_k.BorderStyle = System.Windows.Forms.BorderStyle.None;
	        this.nud_k.DecimalPlaces = 2;
	        this.nud_k.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.nud_k.Increment = new decimal(new int[]
	        {
		        1, 0, 0, 65536
	        });
	        this.nud_k.Location = new System.Drawing.Point(189, 130);
	        this.nud_k.Minimum = new decimal(new int[]
	        {
		        1, 0, 0, 131072
	        });
	        this.nud_k.Name = "nud_k";
	        this.nud_k.Size = new System.Drawing.Size(100, 25);
	        this.nud_k.TabIndex = 9;
	        this.nud_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	        this.nud_k.Value = new decimal(new int[]
	        {
		        5, 0, 0, 65536
	        });
	        this.nud_k.ValueChanged += new System.EventHandler(this.OnInitial);
	        // 
	        // label_k
	        // 
	        label_k.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        label_k.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        label_k.Location = new System.Drawing.Point(8, 130);
	        label_k.Name = "label_k";
	        label_k.Size = new System.Drawing.Size(175, 21);
	        label_k.TabIndex = 8;
	        label_k.Text = "Волновое число, k:";
	        label_k.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
	        // 
	        // nud_wavelength
	        // 
	        this.nud_wavelength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        this.nud_wavelength.BorderStyle = System.Windows.Forms.BorderStyle.None;
	        this.nud_wavelength.DecimalPlaces = 1;
	        this.nud_wavelength.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.nud_wavelength.Location = new System.Drawing.Point(189, 103);
	        this.nud_wavelength.Minimum = new decimal(new int[]
	        {
		        1, 0, 0, 65536
	        });
	        this.nud_wavelength.Name = "nud_wavelength";
	        this.nud_wavelength.Size = new System.Drawing.Size(100, 25);
	        this.nud_wavelength.TabIndex = 7;
	        this.nud_wavelength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	        this.nud_wavelength.Value = new decimal(new int[]
	        {
		        1, 0, 0, 0
	        });
	        this.nud_wavelength.ValueChanged += new System.EventHandler(this.OnInitial);
	        // 
	        // label_wavelength
	        // 
	        label_wavelength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        label_wavelength.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        label_wavelength.Location = new System.Drawing.Point(8, 103);
	        label_wavelength.Name = "label_wavelength";
	        label_wavelength.Size = new System.Drawing.Size(175, 21);
	        label_wavelength.TabIndex = 6;
	        label_wavelength.Text = "Длина волны, λ:";
	        label_wavelength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
	        // 
	        // nud_radius
	        // 
	        this.nud_radius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        this.nud_radius.BorderStyle = System.Windows.Forms.BorderStyle.None;
	        this.nud_radius.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.nud_radius.Increment = new decimal(new int[]
	        {
		        10, 0, 0, 0
	        });
	        this.nud_radius.Location = new System.Drawing.Point(189, 76);
	        this.nud_radius.Maximum = new decimal(new int[]
	        {
		        1000, 0, 0, 0
	        });
	        this.nud_radius.Minimum = new decimal(new int[]
	        {
		        10, 0, 0, 0
	        });
	        this.nud_radius.Name = "nud_radius";
	        this.nud_radius.Size = new System.Drawing.Size(100, 25);
	        this.nud_radius.TabIndex = 5;
	        this.nud_radius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	        this.nud_radius.Value = new decimal(new int[]
	        {
		        100, 0, 0, 0
	        });
	        this.nud_radius.ValueChanged += new System.EventHandler(this.OnInitial);
	        // 
	        // label3
	        // 
	        label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        label3.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        label3.Location = new System.Drawing.Point(8, 76);
	        label3.Name = "label3";
	        label3.Size = new System.Drawing.Size(175, 21);
	        label3.TabIndex = 4;
	        label3.Text = "Радиус полусферы, R:";
	        label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
	        // 
	        // nud_size
	        // 
	        this.nud_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        this.nud_size.BorderStyle = System.Windows.Forms.BorderStyle.None;
	        this.nud_size.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.nud_size.Increment = new decimal(new int[]
	        {
		        10, 0, 0, 0
	        });
	        this.nud_size.Location = new System.Drawing.Point(189, 49);
	        this.nud_size.Maximum = new decimal(new int[]
	        {
		        1000, 0, 0, 0
	        });
	        this.nud_size.Minimum = new decimal(new int[]
	        {
		        50, 0, 0, 0
	        });
	        this.nud_size.Name = "nud_size";
	        this.nud_size.Size = new System.Drawing.Size(100, 25);
	        this.nud_size.TabIndex = 3;
	        this.nud_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	        this.nud_size.Value = new decimal(new int[]
	        {
		        200, 0, 0, 0
	        });
	        this.nud_size.ValueChanged += new System.EventHandler(this.OnInitial);
	        // 
	        // label_size
	        // 
	        label_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        label_size.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        label_size.Location = new System.Drawing.Point(8, 49);
	        label_size.Name = "label_size";
	        label_size.Size = new System.Drawing.Size(175, 21);
	        label_size.TabIndex = 2;
	        label_size.Text = "Размер диаграммы:";
	        label_size.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
	        // 
	        // nud_n
	        // 
	        this.nud_n.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        this.nud_n.BorderStyle = System.Windows.Forms.BorderStyle.None;
	        this.nud_n.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.nud_n.Location = new System.Drawing.Point(239, 22);
	        this.nud_n.Minimum = new decimal(new int[]
	        {
		        2, 0, 0, 0
	        });
	        this.nud_n.Name = "nud_n";
	        this.nud_n.Size = new System.Drawing.Size(50, 25);
	        this.nud_n.TabIndex = 1;
	        this.nud_n.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	        this.nud_n.Value = new decimal(new int[]
	        {
		        10, 0, 0, 0
	        });
	        this.nud_n.ValueChanged += new System.EventHandler(this.OnInitial);
	        // 
	        // label_sizeGrid
	        // 
	        label_sizeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	        label_sizeGrid.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        label_sizeGrid.Location = new System.Drawing.Point(8, 22);
	        label_sizeGrid.Name = "label_sizeGrid";
	        label_sizeGrid.Size = new System.Drawing.Size(175, 21);
	        label_sizeGrid.TabIndex = 0;
	        label_sizeGrid.Text = "Размер сетки, MxN:";
	        label_sizeGrid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
	        // 
	        // button_calculate
	        // 
	        this.button_calculate.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.button_calculate.Location = new System.Drawing.Point(1056, 517);
	        this.button_calculate.Name = "button_calculate";
	        this.button_calculate.Size = new System.Drawing.Size(295, 30);
	        this.button_calculate.TabIndex = 12;
	        this.button_calculate.Text = "Построить";
	        this.button_calculate.UseVisualStyleBackColor = true;
	        this.button_calculate.Click += new System.EventHandler(this.OnCalculate);
	        // 
	        // MainForm
	        // 
	        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
	        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	        this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
	        this.ClientSize = new System.Drawing.Size(1360, 558);
	        this.Controls.Add(this.button_calculate);
	        this.Controls.Add(groupBox_params);
	        this.Controls.Add(groupBox_radiationPattern);
	        this.Controls.Add(groupBox_plant);
	        this.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.Margin = new System.Windows.Forms.Padding(4);
	        this.MaximizeBox = false;
	        this.Name = "MainForm";
	        this.Text = "ИСИТ ННГУ | Radiation Pattern";
	        this.Load += new System.EventHandler(this.OnInitial);
	        groupBox_plant.ResumeLayout(false);
	        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_plant)).EndInit();
	        groupBox_radiationPattern.ResumeLayout(false);
	        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_radiationPattern)).EndInit();
	        groupBox_params.ResumeLayout(false);
	        ((System.ComponentModel.ISupportInitialize)(this.nud_m)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_k)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_wavelength)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_radius)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_size)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.nud_n)).EndInit();
	        this.ResumeLayout(false);
        }

		#endregion
		private System.Windows.Forms.PictureBox pictureBox_plant;
		private System.Windows.Forms.PictureBox pictureBox_radiationPattern;
		private System.Windows.Forms.NumericUpDown nud_k;
		private System.Windows.Forms.NumericUpDown nud_wavelength;
		private System.Windows.Forms.NumericUpDown nud_radius;
		private System.Windows.Forms.NumericUpDown nud_size;
		private System.Windows.Forms.NumericUpDown nud_n;
		private System.Windows.Forms.NumericUpDown nud_m;
		private System.Windows.Forms.Button button_calculate;
	}
}
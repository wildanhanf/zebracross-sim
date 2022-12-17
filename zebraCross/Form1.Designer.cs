using System.Drawing;

namespace zebraCross
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.carRedLight = new System.Windows.Forms.Button();
            this.carYellowLight = new System.Windows.Forms.Button();
            this.carGreenLight = new System.Windows.Forms.Button();
            this.zebracrossTimer = new System.Windows.Forms.Timer(this.components);
            this.titlePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.pedestrianRedLight = new System.Windows.Forms.Button();
            this.pedestrianGreenLight = new System.Windows.Forms.Button();
            this.bgPanel = new System.Windows.Forms.Panel();
            this.car2 = new System.Windows.Forms.PictureBox();
            this.pedestrian = new System.Windows.Forms.PictureBox();
            this.car1 = new System.Windows.Forms.PictureBox();
            this.titlePanel.SuspendLayout();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.car2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedestrian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car1)).BeginInit();
            this.SuspendLayout();
            // 
            // carRedLight
            // 
            this.carRedLight.BackColor = System.Drawing.Color.Red;
            this.carRedLight.Location = new System.Drawing.Point(45, 119);
            this.carRedLight.Margin = new System.Windows.Forms.Padding(2);
            this.carRedLight.Name = "carRedLight";
            this.carRedLight.Size = new System.Drawing.Size(34, 37);
            this.carRedLight.TabIndex = 0;
            this.carRedLight.UseVisualStyleBackColor = false;
            // 
            // carYellowLight
            // 
            this.carYellowLight.BackColor = System.Drawing.Color.Yellow;
            this.carYellowLight.Location = new System.Drawing.Point(45, 161);
            this.carYellowLight.Margin = new System.Windows.Forms.Padding(2);
            this.carYellowLight.Name = "carYellowLight";
            this.carYellowLight.Size = new System.Drawing.Size(34, 37);
            this.carYellowLight.TabIndex = 1;
            this.carYellowLight.UseVisualStyleBackColor = false;
            // 
            // carGreenLight
            // 
            this.carGreenLight.BackColor = System.Drawing.Color.Lime;
            this.carGreenLight.Location = new System.Drawing.Point(45, 202);
            this.carGreenLight.Margin = new System.Windows.Forms.Padding(2);
            this.carGreenLight.Name = "carGreenLight";
            this.carGreenLight.Size = new System.Drawing.Size(34, 37);
            this.carGreenLight.TabIndex = 2;
            this.carGreenLight.UseVisualStyleBackColor = false;
            // 
            // zebracrossTimer
            // 
            this.zebracrossTimer.Tick += new System.EventHandler(this.timerTick);
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.LightYellow;
            this.titlePanel.Controls.Add(this.label1);
            this.titlePanel.Controls.Add(this.title);
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(1064, 90);
            this.titlePanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(473, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Klik lampu traffic di kanan untuk memulai simulasi";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(35, 18);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(432, 55);
            this.title.TabIndex = 8;
            this.title.Text = "Simulasi Zebra Cross";
            // 
            // pedestrianRedLight
            // 
            this.pedestrianRedLight.BackColor = System.Drawing.Color.Red;
            this.pedestrianRedLight.Location = new System.Drawing.Point(959, 192);
            this.pedestrianRedLight.Margin = new System.Windows.Forms.Padding(2);
            this.pedestrianRedLight.Name = "pedestrianRedLight";
            this.pedestrianRedLight.Size = new System.Drawing.Size(26, 28);
            this.pedestrianRedLight.TabIndex = 4;
            this.pedestrianRedLight.UseVisualStyleBackColor = false;
            // 
            // pedestrianGreenLight
            // 
            this.pedestrianGreenLight.BackColor = System.Drawing.Color.Lime;
            this.pedestrianGreenLight.Location = new System.Drawing.Point(959, 232);
            this.pedestrianGreenLight.Margin = new System.Windows.Forms.Padding(2);
            this.pedestrianGreenLight.Name = "pedestrianGreenLight";
            this.pedestrianGreenLight.Size = new System.Drawing.Size(26, 28);
            this.pedestrianGreenLight.TabIndex = 5;
            this.pedestrianGreenLight.UseVisualStyleBackColor = false;
            this.pedestrianGreenLight.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.Color.LightGray;
            this.bgPanel.Controls.Add(this.car2);
            this.bgPanel.Controls.Add(this.pedestrian);
            this.bgPanel.Controls.Add(this.car1);
            this.bgPanel.Location = new System.Drawing.Point(0, 0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(1064, 683);
            this.bgPanel.TabIndex = 7;
            this.bgPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bgPanel_Paint);
            // 
            // car2
            // 
            this.car2.BackColor = System.Drawing.Color.Transparent;
            this.car2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.car2.Image = ((System.Drawing.Image)(resources.GetObject("car2.Image")));
            this.car2.Location = new System.Drawing.Point(600, 1400);
            this.car2.Margin = new System.Windows.Forms.Padding(2);
            this.car2.Name = "car2";
            this.car2.Size = new System.Drawing.Size(171, 375);
            this.car2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.car2.TabIndex = 7;
            this.car2.TabStop = false;
            this.car2.LocationChanged += new System.EventHandler(this.car2_LocationChanged);
            // 
            // pedestrian
            // 
            this.pedestrian.BackColor = System.Drawing.Color.Transparent;
            this.pedestrian.Image = global::zebraCross.Properties.Resources.walk_0;
            this.pedestrian.InitialImage = global::zebraCross.Properties.Resources.walk_0;
            this.pedestrian.Location = new System.Drawing.Point(20, 418);
            this.pedestrian.Name = "pedestrian";
            this.pedestrian.Size = new System.Drawing.Size(59, 138);
            this.pedestrian.TabIndex = 3;
            this.pedestrian.TabStop = false;
            this.pedestrian.LocationChanged += new System.EventHandler(this.pedestrian_LocationChanged);
            // 
            // car1
            // 
            this.car1.BackColor = System.Drawing.Color.Transparent;
            this.car1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.car1.Image = ((System.Drawing.Image)(resources.GetObject("car1.Image")));
            this.car1.Location = new System.Drawing.Point(300, 700);
            this.car1.Margin = new System.Windows.Forms.Padding(2);
            this.car1.Name = "car1";
            this.car1.Size = new System.Drawing.Size(171, 375);
            this.car1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.car1.TabIndex = 6;
            this.car1.TabStop = false;
            this.car1.LocationChanged += new System.EventHandler(this.car1_LocationChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.carGreenLight);
            this.Controls.Add(this.carYellowLight);
            this.Controls.Add(this.carRedLight);
            this.Controls.Add(this.pedestrianGreenLight);
            this.Controls.Add(this.pedestrianRedLight);
            this.Controls.Add(this.bgPanel);
            this.Location = new System.Drawing.Point(115, 370);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.bgPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.car2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedestrian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button carRedLight;
        private System.Windows.Forms.Button carYellowLight;
        private System.Windows.Forms.Button carGreenLight;
        private System.Windows.Forms.Timer zebracrossTimer;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Button pedestrianRedLight;
        private System.Windows.Forms.Button pedestrianGreenLight;
        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.PictureBox pedestrian;
        private System.Windows.Forms.PictureBox car1;
        private System.Windows.Forms.PictureBox car2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label title;
    }
}


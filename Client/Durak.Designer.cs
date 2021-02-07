namespace Project_GUI
{
    partial class Durak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Durak));
            this.lblClose = new System.Windows.Forms.Label();
            this.lblGuide = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblClose
            // 
            this.lblClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblClose.Location = new System.Drawing.Point(590, 614);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(208, 117);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "Exit";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblGuide
            // 
            this.lblGuide.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGuide.AutoSize = true;
            this.lblGuide.BackColor = System.Drawing.Color.Transparent;
            this.lblGuide.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuide.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblGuide.Location = new System.Drawing.Point(471, 492);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(447, 117);
            this.lblGuide.TabIndex = 1;
            this.lblGuide.Text = "User Guide";
            this.lblGuide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGuide.Click += new System.EventHandler(this.lblGuide_Click);
            // 
            // lblStart
            // 
            this.lblStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblStart.Location = new System.Drawing.Point(590, 371);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(207, 117);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Play";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStart.Click += new System.EventHandler(this.lblStart_Click);
            // 
            // Durak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Project_GUI.Properties.Resources.Durak;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1362, 792);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblGuide);
            this.Controls.Add(this.lblClose);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1375, 822);
            this.Name = "Durak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Game - Durak";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Durak_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblGuide;
        private System.Windows.Forms.Label lblStart;
    }
}


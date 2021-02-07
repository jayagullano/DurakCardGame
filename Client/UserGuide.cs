using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 *  OOP III Final Project 
 *  
 *  Completed by Deanna, Praveen, Gowshigan, Rolando
 *  Date Completed: April 17, 2020
 *  File: UserGuide.cs
 *  
 *  Purpose: This file controls outputting the userguide to the user.
 * 
 */
namespace Project_GUI
{
    public partial class UserGuide : Form
    {
        public UserGuide()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGuide));
            this.lblRules = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.lblGoBack = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRules
            // 
            this.lblRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblRules.AutoSize = true;
            this.lblRules.BackColor = System.Drawing.Color.Transparent;
            this.lblRules.Font = new System.Drawing.Font("Monotype Corsiva", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRules.Location = new System.Drawing.Point(337, 9);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(267, 68);
            this.lblRules.TabIndex = 0;
            this.lblRules.Text = "User Guide";
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblText.Location = new System.Drawing.Point(14, 99);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(1017, 407);
            this.lblText.TabIndex = 1;
            this.lblText.Text = resources.GetString("lblText.Text");
            // 
            // lblGoBack
            // 
            this.lblGoBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGoBack.AutoSize = true;
            this.lblGoBack.BackColor = System.Drawing.Color.Transparent;
            this.lblGoBack.Font = new System.Drawing.Font("Monotype Corsiva", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoBack.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblGoBack.Location = new System.Drawing.Point(353, 454);
            this.lblGoBack.Name = "lblGoBack";
            this.lblGoBack.Size = new System.Drawing.Size(209, 68);
            this.lblGoBack.TabIndex = 2;
            this.lblGoBack.Text = "Go Back";
            this.lblGoBack.Click += new System.EventHandler(this.lblGoBack_Click);
            // 
            // UserGuide
            // 
            this.BackgroundImage = global::Project_GUI.Properties.Resources.Durak_Game;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(862, 520);
            this.Controls.Add(this.lblGoBack);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblRules);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "UserGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lblGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

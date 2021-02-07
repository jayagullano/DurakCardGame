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
 *  File: Durak.cs
 *  
 *  Purpose: This file controls the title screen for Durak.
 *  
 *
 * 
 */
namespace Project_GUI
{
    public partial class Durak : Form
    {
        public Durak()
        {
            InitializeComponent();
        }

        private void Durak_Load(object sender, EventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblGuide_Click(object sender, EventArgs e)
        {
            UserGuide guide = new UserGuide();
            guide.Show();
        }

        private void lblStart_Click(object sender, EventArgs e)
        {
            DurakGame game = new DurakGame();
            game.Show();
        }

    }
}

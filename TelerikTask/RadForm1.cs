using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TelerikWinFormsApp9
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        bool player = true; //true = Blue X turn, false = Red O turn

        public RadForm1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            RadButton b = (RadButton)sender;
            if (player == true)
            {
                b.ButtonElement.ButtonFillElement.BackColor = Color.Aqua;
                b.Text = "X";
                b.ButtonElement.TextElement.ForeColor = Color.Black;
            }
            else
            {
                b.ButtonElement.ButtonFillElement.BackColor = Color.IndianRed;
                b.Text = "O";
                b.ButtonElement.TextElement.ForeColor = Color.Black;
            }
            player = !player;
            b.Enabled = false;
            checkForWinner();
        }
        private void checkForWinner()
        {
            //Horizontal
            bool isWinner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                isWinner = true;
            }

            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                isWinner = true;
            }

            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                isWinner = true;
            }

            //Vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                isWinner = true;
            }

            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                isWinner = true;
            }

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                isWinner = true;
            }

            //Diagonally
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                isWinner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {
                isWinner = true;
            }





            if (isWinner)
            {
                disableButtons();
                string winner = "";

                if (player == true)
                {
                    winner = "Red";
                }
                else
                {
                    winner = "Blue";
                }
                MessageBox.Show("Winner: " + winner);
            }


        }

        private void disableButtons()
        {
            try
            {

                foreach (Control c in Controls)
                {

                    RadButton b = (RadButton)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }



        private void btnNewGame_Click_1(object sender, EventArgs e)
        {
            player = true;

            try
            {

                foreach (Control c in Controls)
                {

                    RadButton b = (RadButton)c;
                    b.Enabled = true;
                    b.Text = "";
                    b.ButtonElement.ButtonFillElement.BackColor = Color.DarkGray;
                }
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

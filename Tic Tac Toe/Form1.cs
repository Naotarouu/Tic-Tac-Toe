using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        int count = 0;
        bool turn = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void click_newgame(object sender, EventArgs e)
        {
            count = 0;
            turn = true;

            try
            {
                foreach (Control control in Controls)
                {
                    Button button = (Button)control;
                    button.Enabled = true;
                    button.Text = "";
                }

            }
            catch { }
        }

        private void click_helpTool(object sender, EventArgs e)
        {
            MessageBox.Show("A two player game where the one who succeeds in placing three of their marks in a " +
                "diagonal, horizontal, or vertical row is the winner.");
        }

        private void clickButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Enabled = false;
            turn = !turn;

            if (turn)
                button.Text = "O";
            else
                button.Text = "X";

            count = count + 1;

            player_winner();
        }

        private void player_winner()
        { 
            bool game_over = false;

            if (!button1.Enabled && (button1.Text == button2.Text) && (button2.Text == button3.Text))
                game_over = true;
            else if (!button4.Enabled && (button4.Text == button5.Text) && (button5.Text == button6.Text))
                game_over = true;
            else if (!button7.Enabled && (button7.Text == button8.Text) && (button8.Text == button9.Text))
                game_over = true;
            else if (!button1.Enabled && (button1.Text == button5.Text) && (button5.Text == button9.Text))
                game_over = true;
            else if (!button3.Enabled && (button3.Text == button5.Text) && (button5.Text == button7.Text))
                game_over = true;
            else if (!button1.Enabled && (button1.Text == button4.Text) && (button4.Text == button7.Text))
                game_over = true;
            else if (!button2.Enabled && (button2.Text == button5.Text) && (button5.Text == button8.Text))
                game_over = true;
            else if (!button3.Enabled && (button3.Text == button6.Text) && (button6.Text == button9.Text))
                game_over = true;

            if (game_over)
            {
                buttons_disable();

                String win = "";
                if (turn)
                    win = "O";
                else
                    win = "X";

                MessageBox.Show("Game Over\n" + win + " wins");
            }
            else
            {
                if (count == 9)
                    MessageBox.Show("Game Over\n" + ("It's a Draw"));
            }
            
        }

        private void buttons_disable()
        {
            foreach (Control control in Controls)
            {
                Button button = (Button)control;
                    button.Enabled = false;
            }
        }
    }
}

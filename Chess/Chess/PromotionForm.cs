using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chess
{
    public enum PromotionChoices
    { Queen, Rook, Bishop, Knight }
    public partial class PromotionForm : Form
    {
        public PromotionChoices choice;
        public bool isClicked;
        public PromotionForm()
        {
            //reading the form
            Game1.pf = this;
            choice = PromotionChoices.Queen;
            isClicked = false;
            InitializeComponent();
        }

        private void queenbtn_Click(object sender, EventArgs e)
        {
            choice = PromotionChoices.Queen;
            isClicked = true;
            this.Visible=false;
        }

        private void rookbtn_Click(object sender, EventArgs e)
        {
            choice = PromotionChoices.Rook;
            isClicked = true;
            this.Visible=false;
        }

        private void bishopbtn_Click(object sender, EventArgs e)
        {
            choice = PromotionChoices.Bishop;
            isClicked = true;
            this.Visible = false;
        }

        private void knightbtn_Click(object sender, EventArgs e)
        {
            choice = PromotionChoices.Knight;
            isClicked = true;
            this.Visible = false;
        }


    }
}

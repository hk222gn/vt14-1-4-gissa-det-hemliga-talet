using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GissaDetHemligaTalet.Model;

namespace GissaDetHemligaTalet
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber SecretNumber
        {
            get { return Session["SecretObj"] as SecretNumber; }
            set
            {
                Session["SecretObj"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SecretNumber == null)
            {
                SecretNumber sn = new SecretNumber();
                SecretNumber = sn;
            }
        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string str;

                Outcome outcome = SecretNumber.MakeGuess(int.Parse(GuessTextBox.Text));

                if (outcome == Outcome.NoMoreGuesses)
                {
                    GuessTextBox.Enabled = false;
                    GuessButton.Enabled = false;

                    PlaceHolder1.Visible = true;
                    str = String.Format("Du har inga försök kvar. Det hemliga talet va {0}.", SecretNumber.Number);

                    ResetLabel.Text += str;
                    return;
                }

                if (outcome == Outcome.Low)
                {
                    StatusLabel.Text = "Du gissade för lågt!";
                }
                else if (outcome == Outcome.Correct)
                {
                    GuessTextBox.Enabled = false;
                    GuessButton.Enabled = false;

                    PlaceHolder1.Visible = true;
                    str = String.Format("Rätt gissat! Du klarade det på {0} försök!", SecretNumber.Count);
                    StatusLabel.Text += str;
                }
                else if (outcome == Outcome.High)
                {
                    StatusLabel.Text = "Du gissade för högt!";
                }
                else if (outcome == Outcome.PreviousGuess)
                {
                    StatusLabel.Text = "Du har redan gissat på detta talet!";
                }
                PreviousGuessLabel.Text = String.Join(", ", SecretNumber.PreviousGuesses);
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            SecretNumber.Initialize();
        }
    }
}
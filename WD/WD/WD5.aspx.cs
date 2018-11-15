/*======================================================================
* FILE : WD5.aspx.cs
* PROJECT : WebDesign - Assignment #5
* PROGRAMMER : Zhendong Tang
* FIRST VERSION : 2018-11-13
* DESCRIPTION : This program is to design a HI-LO game with ASP.NET technology
*               
=======================================================================*/
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WD
{
    public partial class WD5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*=================================================
                    "Submit"  button
       ================================================= */
        protected void Unnamed1_Click(object sender, EventArgs e)
        {

            string userName;  // to hold user's name
            int maxNum;       // to hold the maxmium value
            int targetNum;    // to hold the target generated
            int guess;        // to hold the user's guess
            
            string error;     // to hold error information 
            string tip;       // to hold tip information

            /*=================================================
                THE FIRST TIME FOR THE USER,ASK FOR NAME 
            ================================================= */

            if (ViewState["userName"] == null)
            {
                ViewState["userName"] = TextBox1.Text;
                userName = (string)ViewState["userName"];              
                Label3.Text = userName + ", " + "please input a Maxmium number";
                TextBox2.CssClass = "Show";    // show the next textbox
                TextBox2.Focus();              // the textbox for maxmium number get focus
                TextBox1.ReadOnly = true;      // set the textbox for name as read-only
            }
            /*=================================================
                  ASK USER FOR THE MAXIMUM NUMBER 
            ================================================= */
            else
            {
                TextBox3.Focus();
                if (string.IsNullOrEmpty(TextBox2.Text))
                {
                    Label7.Text = "This field cannot be empty";
                }

                else
                {
                    Label7.Text = "";
                   
                    if (ViewState["maxNum"] == null)// THE FIRST TIME get maxNum
                    {
                        ViewState["maxNum"] = Convert.ToInt32(TextBox2.Text);
                        maxNum = (int)ViewState["maxNum"];
                        Random rnd = new Random();
                        targetNum = rnd.Next(1, maxNum);
                        ViewState["targetNum"] = targetNum;
                        Label5.CssClass = "Show";
                        TextBox3.CssClass = "Show";

                        /*=================================================
                           MEMORIZE THE RANGE OF THE GAME
                        ================================================= */

                        ViewState["celling"] = maxNum;  // The maxmium value can be entered
                        ViewState["floor"] = 0;         // The minimium value can be entered
                        tip = "[ The value is between " + Convert.ToString(ViewState["floor"]) + " and " + Convert.ToString(ViewState["celling"]) + " ]";
                        Label6.Text = tip;
                        TextBox2.ReadOnly = true;        // Once the maxmium number entered, read only

                    }
                     /*=================================================
                        ASK USER FOR THE GUESS NUMBER 
                      ================================================= */
                    else
                    {
                     
                        if (string.IsNullOrEmpty(TextBox3.Text))
                        {
                            Label7.Text = "This field cannot be empty";
                        }
                        else
                        {
                            Label7.Text = "";
                            guess = Convert.ToInt32(TextBox3.Text);

                            /*=================================================
                                 GUESS NUMBER  >  TARGET
                             ================================================= */

                            if (guess > (int)ViewState["targetNum"])// the first time 
                            {
                                if (guess <= (int)ViewState["celling"])
                                {
                                    error = "you guess is " + guess + ", it's too big";
                                    ViewState["celling"] = guess - 1;
                                }
                                else
                                {
                                    error = "you guess is " + guess + ", it's out of range";
                                }
                                Label8.Text = error;
                                tip = "[ The value is between " + Convert.ToString(ViewState["floor"]) + " and " + Convert.ToString(ViewState["celling"]) + " ]";
                                Label6.Text = tip;
                                TextBox3.Text = "";
                            }
                            /*=================================================
                              GUESS NUMBER  <  TARGET
                            ================================================= */
                            else if (guess < (int)ViewState["targetNum"])

                            {
                                if (guess >= (int)ViewState["floor"])
                                {
                                    error = "you guess is " + guess + ", it's too small";
                                    ViewState["floor"] = guess + 1;
                                }
                                else
                                {
                                    error = "you guess is " + guess + ", it's out of range";
                                }
                                Label8.Text = error;
                                tip = "[ The value is between " + Convert.ToString(ViewState["floor"]) + " and " + Convert.ToString(ViewState["celling"]) + " ]";
                                Label6.Text = tip;
                                TextBox3.Text = "";
                             }
                            /*=================================================
                              GUESS NUMBER  =  TARGET
                            ================================================= */
                            else
                            {
                                Label6.Text = "";
                                Label8.Text = "You Win!! You guessed the number!!";
                                PageBody.Attributes.Add("bgcolor", "yellow");
                                playAgain.CssClass = "Show";       // Show the "play again" button
                                btnSubmit.CssClass = "Hide";       // Hide the submit button
                                TextBox3.ReadOnly = true;          // Set the textbox as read-only
                                playAgain.Focus();
                            }
                        }

                    }

                }


            }


        }
        /*=================================================
                     "Play Again"  button
        ================================================= */
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            PageBody.Attributes.Add("bgcolor", "");  // resume web page background

            /* reset variables as null except the "username" variable */

            ViewState["targetNum"] = null;
            ViewState["maxNum"] = null;
            ViewState["floor"] = null;
            ViewState["celling"] = null;
            TextBox2.Text = "";
            TextBox3.Text = "";
            Label8.Text = "";

            /* set visibility of the elements*/
            btnSubmit.CssClass = "Show";
            Label1.CssClass = "Hide";
            TextBox1.CssClass = "Hide";
            Label5.CssClass = "Hide";
            playAgain.CssClass = "Hide";
            TextBox3.CssClass = "Hide";
            TextBox2.ReadOnly = false;
            TextBox3.ReadOnly = false;
            /*text box for maxmium number get focus*/
            TextBox2.Focus();
   

        }







    }
}
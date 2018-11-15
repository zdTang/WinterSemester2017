using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class game : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Focus();
       
    }



    protected void Unnamed1_Click(object sender, EventArgs e)
    {
    
        string userName;
        int maxNum;
        int targetNum;
        int guess;
       // int celling;
        //int floor;
        //string lable;
        string error;
        string tip;
        if (ViewState["userName"] == null)// THE FIRST TIME
        {
            ViewState["userName"] = TextBox1.Text;
            userName = (string)ViewState["userName"];

            //lable = userName + ", " + "please input a number";
            Label3.Text = userName + ", " + "please input a Maxmium number";
            TextBox2.CssClass = "Show";
            TextBox2.Focus();
            TextBox1.ReadOnly = true;
        }
        else 
        {
            TextBox3.Focus();
            if(string.IsNullOrEmpty(TextBox2.Text))
            {
                Label7.Text = "This field cannot be empty";
            }

            else
            {
                Label7.Text = "";
                if (ViewState["maxNum"] == null)// THE FIRST TIME get maxNum
                {
                    //Label3.Text = (string)ViewState["userName"] + ", " + "please input a Maxmium number";
                    ViewState["maxNum"] = Convert.ToInt32(TextBox2.Text);
                    maxNum = (int)ViewState["maxNum"];
                    Random rnd = new Random();
                    targetNum = rnd.Next(1, maxNum);
                    ViewState["targetNum"] = targetNum;
                    Label5.CssClass = "Show";
                    //Label5.Text = "Please guess a Number:";
                    TextBox3.CssClass = "Show";
                    // setting the range
                    ViewState["celling"] = maxNum;
                    ViewState["floor"] = 0;
                    tip = "[ The value is between " + Convert.ToString(ViewState["floor"]) + " and " + Convert.ToString(ViewState["celling"]) + " ]";
                    Label6.Text = tip;
                    TextBox2.ReadOnly = true;

                }
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
                            // Label8.Text = error;
                            //+ "TARGET IS " + Convert.ToString(ViewState["targetNum"]);
                            TextBox3.Text = "";
                            //Label7.Text = "TARGET IS " + Convert.ToString(ViewState["targetNum"]);

                        }
                        else if (guess < (int)ViewState["targetNum"])// the first time 

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
                            // Label8.Text = "TARGET IS " + Convert.ToString(ViewState["targetNum"]);
                            TextBox3.Text = "";
                            //Label7.Text = "TARGET IS " + Convert.ToString(ViewState["targetNum"]);

                        }

                        else
                        {
                            Label6.Text = "";
                            //Label5.Text = "";
                            Label8.Text = "You Win!! You guessed the number!!";
                            PageBody.Attributes.Add("bgcolor", "yellow");
                            playAgain.CssClass = "Show";
                            btnSubmit.CssClass = "Hide";
                            TextBox3.ReadOnly = true;
                            playAgain.Focus();
                        }
                    }

                }

            }
 

        }
        
 
    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {

        ViewState["targetNum"] = null;
        ViewState["maxNum"] = null;
        ViewState["floor"] = null;
        ViewState["celling"] = null;
        Label8.Text = "";
        playAgain.CssClass = "Hide";
        TextBox3.CssClass = "Hide";
        PageBody.Attributes.Add("bgcolor", "");
        TextBox2.Text = "";
        TextBox2.Focus();
        TextBox3.Text = "";
        TextBox2.ReadOnly = false;
        TextBox3.ReadOnly = false;
        btnSubmit.CssClass = "Show";
        Label1.CssClass = "Hide";
        TextBox1.CssClass = "Hide";
        Label5.CssClass = "Hide";







    }
}
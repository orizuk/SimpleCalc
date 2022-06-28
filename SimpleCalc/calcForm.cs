using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalc
{
    public partial class calcForm : Form
    {
        bool errMsg = false;
        public calcForm()
        {
            InitializeComponent();
        }




        private void button_Click(object sender, EventArgs e)
        {
            var currButton = (Button)sender;
            if (errMsg)
            {
                inputBox.Text = currButton.Text;
                errMsg = false;
            }
            else
            {
                inputBox.Text += currButton.Text;
            }
            

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            inputBox.Text = "";
            errMsg = false;
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            string input = inputBox.Text;
            decimal output;
            try
            {
                output = Calculator.Calc(input);
                if (output.Equals((int)output))
                    inputBox.Text = ((int)output).ToString();
                else
                    inputBox.Text = output.ToString();
            }
            catch(Exception ex) 
            {
                if(!inputBox.Text.Equals(""))
                {
                    if (ex.Message.Equals("Input string was not in a correct format."))
                        inputBox.Text = "Invalid Format";
                    else
                        inputBox.Text = ex.Message;
                    errMsg = true;
                }
                
            }
            
        }
        
    }
}

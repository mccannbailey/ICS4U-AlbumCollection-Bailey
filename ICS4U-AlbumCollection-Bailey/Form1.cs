using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ICS4U_AlbumCollection_Bailey
{
    public partial class Form1 : Form
    {
        List<string> origList = new List<string>(); // original list and sorted list
        List<string> sortList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string info;
            statusLabel.Text = "";
            statusLabel.ForeColor = Color.Red;

            try
            {
                if (inputBox.Text != "")
                {
                    info = inputBox.Text;

                    origList.Add(info);
                    sortList.Add(info);
                    sortList.Sort();

                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = "Success!";
                }
                else if (inputBox.Text == "") { statusLabel.Text = "Please enter information."; }
            }   
            catch { statusLabel.Text = "An error occured"; }

            var origOrder = string.Join("\n", origList.ToArray());
            origBox.Text = origOrder;

            var sortOrder = string.Join("\n", sortList.ToArray());
            sortBox.Text = sortOrder;

            inputBox.Clear();
            inputBox.Focus();

            this.Refresh();
            Thread.Sleep(1000);
            statusLabel.Text = "";
        }

        private void removeButton_Click(object sender, EventArgs e)
        {           
            string info;
            info = inputBox.Text;

            if (origList.Contains(info) || sortList.Contains(info))
            {
                origList.Remove(info);
                sortList.Remove(info);

                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Successfully removed!";

                var origOrder = string.Join("\n", origList.ToArray());
                origBox.Text = origOrder;

                var sortOrder = string.Join("\n", sortList.ToArray());
                sortBox.Text = sortOrder;
                
                inputBox.Clear();
                inputBox.Focus();
            }
            else
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Entered information does not exist.";
            }

            this.Refresh();
            Thread.Sleep(1000);
            statusLabel.Text = "";
        }
    }
}

using ProtectClient.Core.Controllers;
using ProtectClient.Core.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtectClient.Core.Views
{
    public partial class LoginView : Form, IView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public Form Form
        {
            get
            {
                return this;
            }
        }

        public string Title
        {
            get
            {
                return Text;
            }

            set
            {
                Text = value;
            }
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            AppManager.Instance.Load<DefaultController>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServerApi api = new ServerApi();
            var result = api.Login(textBox1.Text, textBox2.Text);
            MessageBox.Show("Result\n"+result.ok+"\n"+result.token, "Title", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}

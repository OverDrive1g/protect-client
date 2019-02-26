using ProtectClient.Core.Controllers;
using ProtectClient.Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtectClient.Core.Views
{
    public partial class DefaultView : Form, IView
    {
        public DefaultView()
        {
            InitializeComponent();
        }

        public Form Form => this;

        public string Title
        {
            get => Text;
            set => Text = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppManager.Instance.Load<LoginController>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //AppManager.Instance.Load<AccountController>();
        }
    }
}

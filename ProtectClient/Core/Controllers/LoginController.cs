using ProtectClient.Core.MVC;
using ProtectClient.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectClient.Core.Controllers
{
    class LoginController: Controller
    {
        private IView _view;
        public override IView View => _view ?? new LoginView();

        public override bool Loadable()
        {
            return true;
        }
    }
}

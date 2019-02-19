using ProtectClient.Core.MVC;
using ProtectClient.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectClient.Core.Controllers
{
    class DefaultController: Controller
    {
        private IView _view;
        public override IView View
        {
            get
            {
                return _view ?? new DefaultView();
            }
        }

        public override bool Loadable()
        {
            return true;
        }
    }
}

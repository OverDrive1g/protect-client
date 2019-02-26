using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtectClient.Core.MVC
{
    public class AppManager
    {
        private static bool _started;

        private static AppManager _instance;

        public static AppManager Instance
        {
            get
            {
                if (!_started)
                    throw new Exception("Tried to call the singleton instance of the AppManager before the AppManager started.");

                return _instance;
            }
        }

        private IView _currentView;

        private AppManager() { }

        public static void Start<T>()
            where T : Controller
        {
            if (_started) return;

            _started = true;

            T controller = Activator.CreateInstance<T>();

            {
                _instance = new AppManager
                {
                    _currentView = controller.View
                };

                _instance.openForm();
            }
        }

        public void Load<T>()
            where T : Controller
        {
            T controller = Activator.CreateInstance<T>();

            if (controller.Loadable())
            {
                controller.OnLoadSuccess(EventArgs.Empty);
            }
            else
            {
                controller.OnLoadFailure(EventArgs.Empty);
            }
        }

        public void Show(Controller controller)
        {
            if (_currentView != null)
            {
                _currentView.Close();
                _currentView.Form.Dispose();
            }

            _currentView = controller.View;

            Thread th = new Thread(openForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openForm()
        {
            Application.Run(_currentView.Form);
        }
    }
}

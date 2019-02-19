﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtectClient.Core.MVC
{
    public interface IView
    {
        string Title { get; set; }

        Form Form { get; }

        void Close();
    }
}

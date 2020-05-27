using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    interface IDatabaseConnection
    {
        void Connect();
        void Disconnect();
    }
}

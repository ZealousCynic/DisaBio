using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    public interface IDatabaseConnection
    {
        void Connect();
        void Disconnect();
    }
}

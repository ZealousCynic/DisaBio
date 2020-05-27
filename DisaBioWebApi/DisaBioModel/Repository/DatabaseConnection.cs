using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DisaBioModel.Repository
{
    class DatabaseConnection : Interface.IDatabaseConnection, IDisposable
    {
        // Attributes
        private SqlConnection conn;

        //Constructor
        public DatabaseConnection()
        {
            // TODO: Make SQL Connection
            conn = new SqlConnection();
        }

        // Methods
        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

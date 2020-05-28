using System;
using System.Data.SqlClient;

namespace DisaBioModel.Repository
{
    class DatabaseConnection : Interface.IDatabaseConnection, IDisposable
    {
        // Attributes
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        //Bad, very bad. Injection stuff can come later.
        string constring = @"Server=0.tcp.eu.ngrok.io,15323\sqlserverfordias " +
            "User ID=sa " +
            "Password=Pa$$w0rd " +
            "Initial Catalog=Disa";

        // Properties
        public SqlCommand Cmd { get => cmd; set => cmd = value; }
        public SqlDataReader Reader { get => reader; set => reader = value; }

        //Constructor
        public DatabaseConnection()
        {
            // TODO: Make SQL Connection
            conn = new SqlConnection(constring);
            Cmd = new SqlCommand();
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Connection = conn;
            Reader = null;
        }

        public DatabaseConnection(string connection)
        {
            // TODO: Make SQL Connection
            conn = new SqlConnection(connection);
            Cmd = new SqlCommand();
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Connection = conn;
            Reader = null;
        }

        // Methods
        public void Connect()
        {
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
        }

        public void Disconnect()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }

        public void Dispose()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
            Cmd = null;
            conn = null;
        }
    }
}

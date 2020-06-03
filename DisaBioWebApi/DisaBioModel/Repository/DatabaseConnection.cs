using System;
using System.Data.SqlClient;

namespace DisaBioModel.Repository
{
    public class DatabaseConnection : Interface.IDatabaseConnection, IDisposable
    {
        // Attributes
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        //Bad, very bad. Injection stuff can come later.
        string constring = @"Server=0.tcp.eu.ngrok.io,15323\sqlserverfordias; " +
            "User ID=sa; " +
            "Password=Pa$$w0rd; " +
            "Initial Catalog=Disa";

        // Properties
        public SqlCommand Cmd { get => cmd; set => cmd = value; }
        public SqlDataReader Reader { get => reader; set => reader = value; }
        public SqlConnection Conn { get => conn; set => conn = value; }

        //Constructor
        /// <summary>
        /// Wrapper for ADO SQL database connection handler.
        /// It contains SqlConnection, SqlCommand and SqlDataReader objects
        /// </summary>
        public DatabaseConnection()
        {
            // TODO: Make SQL Connection
            Conn = new SqlConnection(constring);
            Cmd = new SqlCommand();
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Connection = Conn;
            Reader = null;
        }


        /// <summary>
        /// Wrapper for ADO SQL database connection handler.
        /// It contains SqlConnection, SqlCommand and SqlDataReader objects
        /// <paramref name="connection"/>
        /// </summary>
        public DatabaseConnection(string connection)
        {
            // TODO: Make SQL Connection
            Conn = new SqlConnection(connection);
            Cmd = new SqlCommand();
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Connection = Conn;
            Reader = null;
        }

        // Methods
        /// <summary>
        /// Calls open on the connection if the state is not open.
        /// </summary>
        public void Connect()
        {
            if (Conn.State != System.Data.ConnectionState.Open)
                Conn.Open();
        }

        /// <summary>
        /// Calls close on the connection if the state is not closed.
        /// </summary>
        public void Disconnect()
        {
            if (Conn.State != System.Data.ConnectionState.Closed)
                Conn.Close();
        }

        /// <summary>
        /// Dispose everything. I need to look into proper dispose patterns at some point.
        /// </summary>
        public void Dispose()
        {
            if (Conn.State != System.Data.ConnectionState.Closed)
                Conn.Close();
            Cmd = null;
            Conn = null;
        }
    }
}

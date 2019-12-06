using System;

namespace BackendAPI.Settings
{
    public class PostgresSettings
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString
        {
            get
            {
                return String.Format("User Id = {0}; Password = {1}; Host = {2}; Port = {3}; Database = {4}",
                    User, Password, Host, Port, DatabaseName);
            }
        }
    }
}

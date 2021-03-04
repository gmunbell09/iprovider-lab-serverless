using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public class Settings
    {
        public Settings()
        {
            ConnectionStrings = new ConnectionStrings();
        }

        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string OtherConnection { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Networking
{
    /// <summary>
    /// An interface reresenting a Server. 
    /// </summary>
    interface IServer
    {
        void Connect(string address, int port);

        void Disconnect();

        

    }
}

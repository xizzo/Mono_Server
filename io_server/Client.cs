using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace io_server
{
    class Client
    {
      public TcpClient clientSocket { get; set; }

      public Client(TcpClient clientSocket)
      {
         this.clientSocket = clientSocket;
      }

   }
}

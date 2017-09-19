using System;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;

namespace io_server
{
   class io_server
   {

      static Int32 serverPort = 7777;

      static TcpListener serverSocket;
      static TcpClient clientSocket;

      static Boolean serverIsActive = false;

      static List<Client> lstClients = new List<Client>();

      static void Main(string[] args)
      {
         try
         {
            StartServer();
            ServerThread().Wait();
         }
         catch (Exception)
         {
            throw;
         }
      }

      static void StartServer()
      {
         serverIsActive = true;

         clientSocket = default(TcpClient);

         serverSocket = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), serverPort));
         serverSocket.Start();
      }

      static async System.Threading.Tasks.Task ServerThread()
      {
         while (serverIsActive)
         {
            clientSocket = await serverSocket.AcceptTcpClientAsync();
            Client oClient = new Client(clientSocket);
            lstClients.Add(oClient);
         }
      }

   }
}
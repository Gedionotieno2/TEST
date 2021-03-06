using System;
using System.Threading;								// Sleeping
using System.Net;									// Used to local machine info
using System.Net.Sockets;							// Socket namespace
using System.Collections;							// Access to the Array list
using System.Windows.Forms;

namespace RAS_CORE
{
	class AppMain
	{
		private ArrayList	m_aryClients = new ArrayList();	// List of Client Connections
		private Thread listenerThread;
		private Socket listener;
		private Form m_InstanceRef = null;

		public Form InstanceRef
		{
			get 
			{
				return m_InstanceRef;
			}
			set 
			{
				m_InstanceRef = value;
			}
		}

		public void Listener()
		{
			AppMain app =new AppMain();
			// Welcome and Start listening
			WriteConsoleData( "RAS CORE Server Started " + DateTime.Now.ToString( "G" ) );

			const int nPortListen = 399;
			// Determine the IPAddress of this machine
			IPAddress [] aryLocalAddr = null;
			String strHostName = "";
			try
			{
				// NOTE: DNS lookups are nice and all but quite time consuming.
				strHostName = Dns.GetHostName();
				IPHostEntry ipEntry = Dns.GetHostByName( strHostName );
				aryLocalAddr = ipEntry.AddressList;
			}
			catch( Exception ex )
			{
				WriteConsoleData ("Error trying to get local address " + ex.Message );			}
	
			// Verify we got an IP address. Tell the user if we did
			if( aryLocalAddr == null || aryLocalAddr.Length < 1 )
			{
				WriteConsoleData( "Unable to get local address" );
				return;
			}
			WriteConsoleData( "Listening on : [" + strHostName + "] " + aryLocalAddr[0]+":" + nPortListen );

			// Create the listener socket in this machines IP address
			listener = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
			listener.Bind( new IPEndPoint( aryLocalAddr[0], 399 ) );
			listener.Listen( 10 );

			// Setup a callback to be notified of connection requests
			listener.BeginAccept( new AsyncCallback( app.OnConnectRequest ), listener );
		}

		//start the service
		public void Start()
		{
			listenerThread=new Thread(new ThreadStart(this.Listener));
			listenerThread.Start();
		}

		public void Stop()
		{
			listener.Close();
		}

		public void Suspend()
		{
			listenerThread.Suspend();
		}

		public void Resume()
		{
			listenerThread.Resume();
		}

		//try send some data from the server
		private void _SendData(string Data)
		{
			foreach( SocketChatClient clientSend in m_aryClients )
				try
				{
					byte [] arySend=System.Text.Encoding.ASCII.GetBytes(Data);
					clientSend.Sock.Send(arySend);
				}
				catch
				{
					// If the send fails the close the connection
					//lstConn.Items.Add( "Send to client "+client.Sock.RemoteEndPoint+ "failed" );
					//clientSend.Sock.Close();
					//m_aryClients.Remove( client );
					return;

				}
		}
		//write an error to the error log since we are not using console writelines...
		private void WriteErrorLog(string Error)
		{

		}

		public void WriteConsoleData(string Data)
		{
			//write status data to the main screen
			foreach (Control c in InstanceRef.Controls)
			{
				if (c.Name=="txtMsg")
				{
					c.Text=Data;
				}
			}
		}

		/// <summary>
		/// Callback used when a client requests a connection. 
		/// Accept the connection, adding it to our list and setup to 
		/// accept more connections.
		/// </summary>
		/// <param name="ar"></param>
		public void OnConnectRequest( IAsyncResult ar )
		{
			Socket listener = (Socket)ar.AsyncState;
			NewConnection( listener.EndAccept( ar ) );
			listener.BeginAccept( new AsyncCallback( OnConnectRequest ), listener );
		}

		/// <summary>
		/// Add the given connection to our list of clients
		/// Note we have a new client connection
		/// Send a welcome to the new client
		/// Setup a callback to recieve data
		/// </summary>
		/// <param name="sockClient">Connection to keep</param>
		public void NewConnection( Socket sockClient )
		{
			// Program blocks on Accept() until a client connects.
			//SocketChatClient client = new SocketChatClient( listener.AcceptSocket() );
			SocketChatClient client = new SocketChatClient( sockClient );
			m_aryClients.Add( client );
			Console.WriteLine( "Client {0}, joined", client.Sock.RemoteEndPoint );
 
			// Get current date and time.
			DateTime now = DateTime.Now;
			String strDateLine = "You are connected to RAS CORE " + now.ToString("G");

			// Convert to byte array and send.
			Byte[] byteDateLine = System.Text.Encoding.ASCII.GetBytes( strDateLine.ToCharArray() );
			client.Sock.Send( byteDateLine, byteDateLine.Length, 0 );

			client.SetupRecieveCallback( this );
		}

		/// <summary>
		/// Get the new data and send it out to all other connections. 
		/// Note: If not data was recieved the connection has probably 
		/// died.
		/// </summary>
		/// <param name="ar"></param>
		public void OnRecievedData( IAsyncResult ar )
		{
			SocketChatClient client = (SocketChatClient)ar.AsyncState;
			byte [] aryRet = client.GetRecievedData( ar );

			// If no data was recieved then the connection is probably dead
			if( aryRet.Length < 1 )
			{
				Console.WriteLine( "Client {0}, disconnected", client.Sock.RemoteEndPoint );
				client.Sock.Close();
				m_aryClients.Remove( client );      				
				return;
			}

			// Send the recieved data to all clients (including sender for echo)
			foreach( SocketChatClient clientSend in m_aryClients )
			{
				try
				{
					clientSend.Sock.Send( aryRet );
				}
				catch
				{
					// If the send fails the close the connection
					clientSend.Sock.Close();
					m_aryClients.Remove( client );
					return;
				}
			}
			client.SetupRecieveCallback( this );
		}
	}

	/// <summary>
	/// Class holding information and buffers for the Client socket connection
	/// </summary>
	internal class SocketChatClient
	{
		private Socket m_sock;						// Connection to the client
		private byte[] m_byBuff = new byte[50];		// Receive data buffer
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="sock">client socket conneciton this object represents</param>
		public SocketChatClient( Socket sock )
		{
			m_sock = sock;
		}

		// Readonly access
		public Socket Sock
		{
			get{ return m_sock; }
		}

		/// <summary>
		/// Setup the callback for recieved data and loss of connection
		/// </summary>
		/// <param name="app"></param>
		public void SetupRecieveCallback( AppMain app )
		{
			try
			{
				AsyncCallback recieveData = new AsyncCallback(app.OnRecievedData);
				m_sock.BeginReceive( m_byBuff, 0, m_byBuff.Length, SocketFlags.None, recieveData, this );
			}
			catch( Exception ex )
			{
				Console.WriteLine( "Recieve callback setup failed! {0}", ex.Message );
			}
		}

		/// <summary>
		/// Data has been recieved so we shall put it in an array and
		/// return it.
		/// </summary>
		/// <param name="ar"></param>
		/// <returns>Array of bytes containing the received data</returns>
		public byte [] GetRecievedData( IAsyncResult ar )
		{
			int nBytesRec = 0;
			try
			{
				nBytesRec = m_sock.EndReceive( ar );
			}
			catch{}
			byte [] byReturn = new byte[nBytesRec];
			Array.Copy( m_byBuff, byReturn, nBytesRec );
			return byReturn;
		}
	}
}

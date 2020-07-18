using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using stLib.Log;

namespace stLib.Net {
    public class IPPort {
        public string IP { get; set; }
        public string UdpPort { get; set; }
        public string TcpPort { get; set; }

        public string Readable()
        {
            return string.Format("{0}:[UDP:{1}][TCP:{2}]", IP, UdpPort, TcpPort );
        }
    }

    public static class DNSHelper { 
        public static string ParseIPFromDomain( string domain ) {
            try {
                IPHostEntry host = Dns.GetHostEntry( domain );
                IPAddress ip = host.AddressList[0];
                return ip.ToString();
            } catch {
                return "";
            }
        }
    }
}

namespace stLib.Net.Haste {
    public class UdpClient_ {
        public UdpClient sender;
        public UdpClient_()
        {
            sender = new UdpClient();
        }

        public string SendMessage( string message, IPPort ipport )
        {
            // var message = obj as string;
            byte[] sendbytes = Encoding.ASCII.GetBytes( message );

            IPEndPoint remoteIpep = new IPEndPoint(
                IPAddress.Parse( ipport.IP ), Convert.ToInt32( ipport.UdpPort ) ); // 发送到的IP地址和端口号

            sender.Send( sendbytes, sendbytes.Length, remoteIpep );
            byte[] bytRecv = sender.Receive( ref remoteIpep );
            string resp = Encoding.ASCII.GetString( bytRecv, 0, bytRecv.Length );
            return resp;
        }
    }

    public class TcpClient_ {
        static public string SendMessage_ShortConnect( string msg, IPPort ipport )
        {
            TcpClient tcpClient = new TcpClient();
            string Resp = "";
            try {
                tcpClient.Connect( IPAddress.Parse( ipport.IP ), Convert.ToInt32( ipport.TcpPort ) );
            } catch ( Exception ex ) {
                stLogger.Log( ex );
                return "";
            }

            NetworkStream ntwStream = tcpClient.GetStream();
            if ( ntwStream.CanWrite ) {
                Byte[] bytSend = Encoding.UTF8.GetBytes( msg );
                ntwStream.Write( bytSend, 0, bytSend.Length );
            } else {
                stLogger.Log( "Cannot write tcp stream." );
            }
            if ( ntwStream.CanRead ) {
                const int maxLength = 100000;
                Byte[] bytSend = new Byte[maxLength];
                Byte[] bytSend2 = new Byte[ntwStream.Read( bytSend, 0, maxLength )];
                for ( int i = 0; i < bytSend2.Length; i++ ) {
                    bytSend2[i] = bytSend[i];
                }
                Resp = Encoding.UTF8.GetString( bytSend2 );
            }
            ntwStream.Close();
            tcpClient.Close();
            return Resp;
        }
    }
}

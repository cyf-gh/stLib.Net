using stLib.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stLib.Config {

    public class IPPortConfig {
        static public List<IPPort> Load( string fileName = "" )
        {
            List<IPPort> iPPorts = new List<IPPort>();
            if ( fileName == "" ) {
                fileName = "./server.cfg";
            }
            string raw = File.ReadAllText( fileName );
            var ipportstrs = raw.Split( '\n' );
            foreach ( var ipport in ipportstrs ) {
                if ( ipport == "" ) {
                    continue;
                }
                var ip___ports = ipport.Split( ',' );
                iPPorts.Add( new IPPort {
                    IP = ip___ports[0],
                    UdpPort = ip___ports[1],
                    TcpPort = ip___ports[2],
                } );
            }
            return iPPorts;
        }
    }
}

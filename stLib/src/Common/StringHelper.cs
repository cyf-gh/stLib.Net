using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stLib.Common {
    public class StringHelper {
        public static int CountOfKeyIn( char key, string inStr )
        {
            int sum = 0;
            foreach ( var ch in inStr ) {
                sum += ch == key ? 1 : 0;
            }
            return sum;
        }

        public static string [] ParseComData( string data )
        {
            data.TrimEnd(',');
            var r = data.Split( ',' );
            return r;
        }

    }
}

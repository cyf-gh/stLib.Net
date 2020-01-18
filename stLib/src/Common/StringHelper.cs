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

        public static List<string> ParseComData( string data )
        {
            data.TrimEnd(',');
            var r = new List<string>( data.Split( ',' ) );
            r.RemoveAll( str => str == "" );
            return r;
        }

        public static string WrapWith( string raw, string left, string right )
        {
            return left + raw + right;
        }

        public static int SubstringCount( string str, string substring )
        {
            if ( str.Contains( substring ) ) {
                string strReplaced = str.Replace( substring, "" );
                return ( str.Length - strReplaced.Length ) / substring.Length;
            }
            return 0;
        }
    }
}

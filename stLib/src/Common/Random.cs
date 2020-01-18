using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stLib.Common {
    public class Random {
        System.Random rd;
        public Random()
        {
            rd = new System.Random( stLib.Common.Convert.Guid2Int( Guid.NewGuid() )[0] );
        }
        public int GetInt32()
        {
            return rd.Next();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stLib.Win32 {
    public class GlobalAtom {
        [System.Runtime.InteropServices.DllImport( "kernel32.dll" )]
        public static extern UInt32 GlobalAddAtom( String lpString ); //添加原子 
        [System.Runtime.InteropServices.DllImport( "kernel32.dll" )]
        public static extern UInt32 GlobalFindAtom( String lpString ); //查找原子 
        [System.Runtime.InteropServices.DllImport( "kernel32.dll" )]
        public static extern UInt32 GlobalDeleteAtom( UInt32 nAtom ); //删除原子
    }
}

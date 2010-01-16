using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haiti
{
    public class CharsComparer :IEqualityComparer<char>
    {
        bool IEqualityComparer<char>.Equals(char x, char y)
        {
            return (((byte)x).Equals(((byte)y)));            
        }

        int IEqualityComparer<char>.GetHashCode(char obj)
        {
            return obj.GetHashCode();
        }
    }
}

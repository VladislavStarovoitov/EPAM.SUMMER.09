using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTests
{
    public static class TestComparers
    {
        public static int IntComparer(int x, int y)
        {
            return x.CompareTo(y);
        }

        public static int BoxingIntComparer(object x, object y)
        {
            return ((int)x).CompareTo(y);
        }
    }
}

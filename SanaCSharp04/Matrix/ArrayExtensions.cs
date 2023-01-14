using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class ArrayExtensions
    {
        public static int Mul(this int[] arr)
        {
            int multiplication = 1;
            for (int i = 0; i < arr.Length; i++)
                multiplication *= arr[i];
            return multiplication;
        }
    }
}

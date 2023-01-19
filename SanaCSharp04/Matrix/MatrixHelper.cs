using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixHelper
    {
        public static bool CheckOccurrences(int[,] matrix, int currentElement)
        {
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == currentElement)
                        counter++;

                    if (counter > 1)
                        return true;
                }
            }
            return false;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class CreateMatrix
    {
        public uint Width;
        public uint Height;
        public int LeftBorderMatrix;
        public int RightBorderMatrix;

        public CreateMatrix(uint width, uint height, int leftBordermatrix, int rightBordermatrix)
        {
            Width = width;
            Height = height;
            LeftBorderMatrix = leftBordermatrix;
            RightBorderMatrix = rightBordermatrix;
        }
        public int[,] MatrixCreate()
        {
            int[,] matrix = new int[Height, Width];
            Random rhd = new Random();

            for (int line = 0; line < Height; line++)
                for (int column = 0; column < Width; column++)
                    matrix[line, column] = rhd.Next(LeftBorderMatrix, RightBorderMatrix);
            return matrix;
        }
    }
}

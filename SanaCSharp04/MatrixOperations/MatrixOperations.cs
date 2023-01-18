namespace MatrixOperations
{
    public class MatrixOperations
    {
        private int[,] _matrix;

        public MatrixOperations(int[,] matrix)
        {
            _matrix = matrix;
        }

        public int GetCountOfPositiveElements()
        {
            var counter = 0;

            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] > 0)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}